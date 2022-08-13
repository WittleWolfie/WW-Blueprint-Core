# Advanced Feat: Hurtful

This tutorial assumes you've gone through [Adding a Feat](~/articles/tutorials/feat.md) and [Skald's Vigor](skalds_vigor.md), or are familiar with the basics of adding a feat and using BPCore.

We'll be adding [Hurtful](https://www.d20pfsrd.com/feats/combat-feats/hurtful-combat/).

Go through the basic setup steps:

1. Create the `Hurtful` class
2. Create the `Configure` method
3. Create the feat, setting the name and description

```C#
public class Hurtful
{
  public static void Configure()
  {
    FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
      .SetDisplayName(FeatDisplayName)
      .SetDescription(FeatDescription)
      .Configure();
  }
}
```

Go ahead and configure the prerequisites and feature tags as well:

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
  .SetDisplayName(FeatDisplayName)
  .SetDescription(FeatDescription)
  .SetIcon(IconName)
  .AddFeatureTagsComponent(featureTags: FeatureTag.Melee | FeatureTag.Attack | FeatureTag.Skills)
  .AddPrerequisiteStatValue(StatType.Strength, 13)
  .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
  .Configure();
```

## Adding a Demoralize Trigger (Transpilers 101)

Searching the game blueprints for a "Demoralize" blueprint doesn't return anything, but searching the assembly returns the `Demoralize` class. If you use BubblePrints to find usages, search "?Demoralize", you'll find `PersuasionUseAbility` which is the standard way to demoralize.

This doesn't look good: all demoralize logic is implemented in a special component and there are no events. You _could_ use `AddInitiatorSkillRollTrigger` and handle `StatType.CheckIntimidate` but it will trigger out of combat and potentially for other abilities. Also, `RuleSkillCheck` event doesn't indicate whether the target is affected by demoralize, just whether the roll was successful.

To solve this we're going to have to write a [Transpiler](https://harmony.pardeike.net/articles/patching-transpiler.html). A transpiler is a Harmony patch that actually edits the assembly code, changing the behavior of existing methods.

First let's define the API: hurtful triggers on a successful demoralize. We'll define a successful demoralize as a successful skill check where a debuff is applied, specifically either `Demoralize.Buff` or `Demoralize.GreaterBuff`. Whenever `Demoralize` runs this data needs to be passed to our code which will trigger the attack.

This can be done using the game's event system, but we need to define an interface which implements `IGlobalSubscriber`. Create a new class file called `DemoralizeEvents` and define an interface:

```C#
public interface IDemoralizeHandler : IGlobalSubscriber
{
    /// <summary>
    /// Triggers when Demoralize finishes resolving.
    /// </summary>
    /// <param name="demoralize">The component executing demoralize</param>
    /// <param name="intimidateCheck">The intimidate skill check</param>
    void OnDemoralizeResolved(Demoralize demoralize, RuleSkillCheck intimidateCheck);
}

public class DemoralizeEvents
{
  private static readonly LogWrapper Logger = LogWrapper.Get("DemoralizeEvents");

  // TODO
}
```

Transpilers require editing the code in the form of [CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language) which reads more like assembly than C#. This makes it tricky to work with so you want to avoid writing a lot of code in transpilers. Add a method to `DemoralizeEvents` to raise the event:

```C#
public static void NotifySubscribers(Demoralize demoralize, RuleSkillCheck intimidateCheck)
{
  Logger.Verbose($"Notifying Demoralize Subscribers: {demoralize.Owner.name}, {intimidateCheck.RollResult}");
  EventBus.RaiseEvent<IDemoralizeHandler>(h => h.OnDemoralizeResolved(demoralize, intimidateCheck));
}
```

Now we just need the transpiler to call `NotifySubscribers` when run.

The basic definition of a transpiler is the same as a Harmony postfix or prefix:

```C#
[HarmonyPatch(typeof(Demoralize))]
static class Demoralize_Patch
{
  [HarmonyPatch(nameof(Demoralize.RunAction)), HarmonyTranspiler]
  static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
  {
    try
    {
      var code = new List<CodeInstruction>(instructions);
      // TODO
      return code;
    }
    catch (Exception e)
    {
      Logger.Error("Transpiler failed.", e);
      return instructions;
    }
  }
}
```

### Reading IL

Now open up `Demoralize.RunAction()` in dnSpy. If you're using another decompiler you'll need to figure out the equivalent steps. In the top bar you'll see a dropdown showing "C#". Click it and select "IL" and you should see something like this:

![Switch view to IL](~/images/advanced_feat/run_il.png)

The top section is the method declaration and defines a list of local variables. Starting at `IL_0000: call` each line is an instruction, represented by a `CodeInstruction` in the transpiler. An instruction consists of a label, opcode, and operand.

Take the first line:

```
IL_0000: call !0 class Kingmaker.ElementsSystem.ContextData`1<class Kingmaker.UnitLogic.Mechanics.MechanicsContext/Data>::get_Current()
```

The label is `IL_0000`, the opcode is `call`, and everything else is the operand. The label is a reference to a specific instruction which can be used in branching operations for control flow, think `goto`. The opcode indicates the operation to perform, and the operand the argument used by the operation.

The operand is stored as a list of objects and can be just about anything. In this case it is a method reference to `ContextData<MechanicsContext.Data>.getCurrent()`. Put simply the first line calls that method.

Look at the next few lines:

```
IL_0000: call     !0 class Kingmaker.ElementsSystem.ContextData`1<class Kingmaker.UnitLogic.Mechanics.MechanicsContext/Data>::get_Current()
IL_0005: dup
IL_0006: brtrue.s IL_000C
IL_0008: pop
IL_0009: ldnull
IL_000A: br.s     IL_0011
IL_000C: call     instance class Kingmaker.UnitLogic.Mechanics.MechanicsContext Kingmaker.UnitLogic.Mechanics.MechanicsContext/Data::get_Context()
IL_0011: stloc.0
```

Execution goes in order so after `IL_0000`, `IL_0005` and then `IL_0006` are executed. In dnSpy you can mouse over each instruction to get an explanation of what it does. For `dup` it says: "Copies the current topmost value on the evaluation stack, and then pushes the copy onto the evaluation stack".

IL is stack based so generally operations read from values on top of the evaluation stack and store results on top of the evaluation stack. After `IL_0000` the top of the stack contains the current `MechanicsContext.Data`. `dup` duplicates this and pushes it onto the stack.

The next line, `brtrue.s`, checks the value on top of the stack and if it is not null moves execution to the instruction with label `IL_000C`. This means `IL_0008` and `IL_000A` will not execute.  If it is null then the reference is removed and replaced with a null reference by `ldnull`. I don't know exactly why the compiler chose to do the operations this way, so don't ask.

The last line, `stloc.0`, removes the value at the top of the stack and stores it in the local variable with index 0:

```
[0] class Kingmaker.UnitLogic.Mechanics.MechanicsContext,
```

In C# this is all two lines:

```C#
MechanicsContext.Data data = ContextData<MechanicsContext.Data>.Current;
MechanicsContext mechanicsContext = (data != null) ? data.Context : null;
```

### Writing IL

Now that you've read some IL, let's figure out what the new IL looks like.

Switch the view in dnSpy back to C#, right click, and select `Edit Class`. Looking through the entire function the intimidate skill check is triggered here:

```C#
RuleSkillCheck ruleSkillCheck2 = GameHelper.TriggerSkillCheck(ruleSkillCheck, mechanicsContext, true);
```

After the skill check there's a big `if` block which executes on success before closing out the `try` block. Our event should fire as the last step in the `try` block to make sure any state changes from demoralize are applied when it triggers.

In the editor below `RunAction()` add a new method, then call it from within `RunAction()`:

```C#
public override void RunAction()
{
  try
  {
    // ...
    if (ruleSkillCheck2.Success)
    {
    // ...
    }
    NotifySubscribers(this, ruleSkillCheck2);
  }
  finally
  {
    // ...
  }
}

public static void NotifySubscribers(Demoralize demoralize, RuleSkillCheck initimidateCheck) {}
```

When you're done select `Compile` and you should see the new code. Switch back to IL and scroll to the bottom of the method and you should see something similar:

![New IL code](~/images/advanced_feat/new_il.png)

Using dnSpy this way makes it easier to figure out what the new IL should be. The three new lines are:

```
IL_0411: ldarg.0
IL_0412: ldloc.s   ruleSkillCheck2
IL_0414: call      void Kingmaker.UnitLogic.Mechanics.Actions.Demoralize::NotifySubscribers(class Kingmaker.UnitLogic.Mechanics.Actions.Demoralize, class Kingmaker.RuleSystem.Rules.RuleSkillCheck)
```

Back in your transpiler create a new `CodeInstruction` list and add three entries:

```C#
var newCode =
  new List<CodeInstruction>()
  {
    new CodeInstruction(OpCodes.Ldarg_0),
    new CodeInstruction(OpCodes.Ldloc_S),
    CodeInstruction.Call(typeof(DemoralizeEvents), nameof(DemoralizeEvents.NotifySubscribers)),
  };
```

You can also use `AccessTools` to reference `NotifySubscribers` but I find Harmony's `CodeInstruction` extension methods easier to use.

### Inserting New Code

Now that we have new instructions they need to be inserted into the existing instructions, but where?

One option is to count the number of instructions before our new instructions and just insert there. However, if the assembly changes because of a game update or another transpiler, this is likely to break. For this reason choosing where to insert new code is critical.

The goal is to minimize the chance your transpiler breaks, and you do that by anchoring to instructions. In our case we always want the event to be the last statement in the `try` block, so the new code should go just before the corresponding statement.

In dnSpy's IL view the end of the `try` block is called out clearly in the comments: `} // end .try`. So the line before that is the last statement:

```
IL_0419: leave.s   IL_0428
```

To find the insertion point, find this _specific_ `leave.s` instruction. If you search the IL you'll see another `leave.s` instruction so checking the opcode is not sufficient. Thankfully we know that we always want to be called near the end of the method, so just search for last `leave.s` instruction:

```C#
var insertIndex = 0;
for (int index = code.Count - 1; index >= 0; index--)
{
  if (code[index].opcode == OpCodes.Leave_S)
  {
    insertIndex = index;
    break;
  }
}
if (insertIndex == 0)
{
  throw new InvalidOperationException("Unable to find the insertion index.");
}
```

Searching backwards is not required but it will make sense further on. With the insertion index available you can insert the new code:

```C#
code.InsertRange(insertIndex, newCode);
```

### Handling Labels

Unfortunately there is still a problem. Remember how branching operations jump to specific instructions, potentially skipping some? That is going to skip our newly inserted code.

First figure out which statements _after_ the new code are jump targets. In dnSpy just search for the labels of each instruction starting with the `leave.s` used as the insertion point. **Important**: make sure you do this in the _unedited_ assembly. You can reload or undo your changes; nothing is saved to disk unless you did so explicitly.

You should see two statements used as jump targets:

```
IL_0403: leave.s   IL_0410
IL_0410: ret
```

Anything that jumps to these skips our code! We should redirect those jumps to the first line of our code instead. To do that we'll first need to capture the labels for those instructions, then redirect any jumps. Update our search loop to store the labels:

```C#
var insertIndex = 0;
List<Label> leaveLabel = new();
var retLabel = code[index].labels;
for (var index = code.Count - 1; index >= 0; index--)
{
  if (code[index].opcode == OpCodes.Leave_S)
  {
    insertIndex = index;
    leaveLabel = code[index].labels;
    break;
  }
}
if (insertIndex == 0)
{
  throw new InvalidOperationException("Unable to find the insertion index.");
}
```

Since the return instruction is always last you just take the label of the last instruction. Now we have our two labels that need redirection, but we don't have a label to redirect to.

When you create a new `CodeInstruction` Harmony dynamically handles generating and updating labels. If you want to jump to a new instruction you have to explicitly generate a label. This is done by adding a new parameter to the transpiler, `ILGenerator il`, and using it to create a new label:

```C#
[HarmonyPatch(nameof(Demoralize.RunAction)), HarmonyTranspiler]
static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
{
  try
  {
    var code = new List<CodeInstruction>(instructions);
    Label newJumpTarget = il.DefineLabel();

    // Insertion logic here

    var newCode =
      new List<CodeInstruction>()
      {
        new CodeInstruction(OpCodes.Ldarg_0).WithLabels(newJumpTarget),
        new CodeInstruction(OpCodes.Ldloc_S, skillCheckResult),
        CodeInstruction.Call(typeof(DemoralizeEvents), nameof(DemoralizeEvents.NotifySubscribers)),
      };
    code.InsertRange(insertIndex, newCode);
    return code;
  }
  catch (Exception e)
  {
    Logger.Error("Transpiler failed.", e);
    return instructions;
  }
}
```

Now you need to update the operands of instructions using `retLabel` or `leaveLabel` to use `newJumpTarget` instead. Except there's a problem: if you update _all_ operands using `retLabel` it includes early returns before `TriggerSkillCheck` is called, so `ruleSkillCheck2` doesn't exist.

Rather than updating all operands using `retLabel` or `leaveLabel`, search backwards and update only until `TriggerSkillCheck` is called:

```C#
var code = new List<CodeInstruction>(instructions);
Label newJumpTarget = il.DefineLabel();

// Search back to front for OpCodes.Leave_S which is where the new code is inserted. In the next loop the
// any code before Leave_S and after the skill check that jumps to either Leave_S or Ret will be redirected
// to newJumpTarget.
var index = code.Count - 1;
var insertIndex = 0;
List<Label> leaveLabel = new();
var retLabel = code[index].labels;
for (; index >= 0; index--)
{
  if (code[index].opcode == OpCodes.Leave_S)
  {
    Logger.Info($"Found OpCodes.Leave_S at {index}: {code[index]}");
    insertIndex = index;
    leaveLabel = code[index].labels;
    break;
  }
}
if (insertIndex == 0)
{
  throw new InvalidOperationException("Unable to find the insertion index.");
}

// Keep searching backwards replacing all jumps to retLabel / leaveLable, until TriggerSkillCheck is found.
index--; // Make sure we don't redirect Leave_S or there's an infinite loop
for (; index >= 0; index--)
{
  if (code[index].Calls(AccessTools.Method(typeof(GameHelper), nameof(GameHelper.TriggerSkillCheck))))
  {
    break; // Don't mess w/ jumps before the skill check result is generated
  }

  // Doesn't matter what the operation is, if the operand is a Label it's some kind of jump
  if (code[index].operand is Label jumpTarget)
  {
    if (leaveLabel.Contains(jumpTarget))
    {
      Logger.Info($"Found jump to OpCodes.Leave_S at {index}: {code[index]}");
      code[index].operand = newJumpTarget;
    }
    if (retLabel.Contains(jumpTarget))
    {
      Logger.Info($"Found jump to OpCodes.Ret at {index}: {code[index]}");
      code[index].operand = newJumpTarget;
    }
  }
}

var newCode =
  new List<CodeInstruction>()
  {
    new CodeInstruction(OpCodes.Ldarg_0).WithLabels(newJumpTarget),
    new CodeInstruction(OpCodes.Ldloc_S),
    CodeInstruction.Call(typeof(DemoralizeEvents), nameof(DemoralizeEvents.NotifySubscribers)),
  };
code.InsertRange(insertIndex, newCode);
return code;
```

### Finding the Operand

The last step to finish the transpiler is to populate the operand for `Ldloc_S`. When we looked at the edited IL in dnSpy it had an operand `ruleSkillCheck2` but that doesn't exist in our C# method. Instead we need to find the operand in the existing code and copy it over to our new code.

Looking in dnSpy the skill check is stored just after `TriggerSkillCheck` is called:

```
IL_0158: call      class Kingmaker.RuleSystem.Rules.RuleSkillCheck Kingmaker.Designers.GameHelper::TriggerSkillCheck(class Kingmaker.RuleSystem.Rules.RuleSkillCheck, class Kingmaker.UnitLogic.Mechanics.MechanicsContext, bool)
IL_015D: stloc.s   V_4
```

As long as the skill check result is being used this should always be true, because the result of `TriggerSkillCheck` is on the stack and needs to be stored for reference.

Now update the transpiler to capture and use the operand:

```C#
// Keep searching backwards replacing all jumps to retLabel / leaveLable, until TriggerSkillCheck is found.
// Capture the operand for referencing the result which will be passed to NotifySubscribers.
object skillCheckResult = null;
index--; // Make sure we don't redirect Leave_S or there's an infinite loop
for (; index >= 0; index--)
{
  if (code[index].Calls(AccessTools.Method(typeof(GameHelper), nameof(GameHelper.TriggerSkillCheck))))
  {
    Logger.Info($"Found skill check result at {index + 1}: {code[index + 1]}");
    skillCheckResult = code[index + 1].operand;
    break; // Don't mess w/ jumps before the skill check result is generated
  }

  // Doesn't matter what the operation is, if the operand is a Label it's some kind of jump
  if (code[index].operand is Label jumpTarget)
  {
    if (leaveLabel.Contains(jumpTarget))
    {
      Logger.Info($"Found jump to OpCodes.Leave_S at {index}: {code[index]}");
      code[index].operand = newJumpTarget;
    }
    if (retLabel.Contains(jumpTarget))
    {
      Logger.Info($"Found jump to OpCodes.Ret at {index}: {code[index]}");
      code[index].operand = newJumpTarget;
    }
  }
}

var newCode =
  new List<CodeInstruction>()
  {
    new CodeInstruction(OpCodes.Ldarg_0).WithLabels(newJumpTarget),
    new CodeInstruction(OpCodes.Ldloc_S, skillCheckResult),
    CodeInstruction.Call(typeof(DemoralizeEvents), nameof(DemoralizeEvents.NotifySubscribers)),
  };
code.InsertRange(insertIndex, newCode);
return code;
```

The transpiler is done and ready for use! To test it you can enable verbose logging and make sure the log statement in `NotifySubscribers()` triggers when you use the demoralize action in game.

### Transpilers Summary

To write a transpiler:

1. Write as much code as possible in your own C# methods and call them from the transpiler
2. Use a decompiler to view and edit IL
3. Identify anchor instructions in the code that are unlikely to change
4. Use anchor instructions to find insertion points and any operands you need to copy
5. Define new labels for your instructions
6. Redirect existing labels to use your new labels, if necessary

> [!TIP]
> Use transpilers sparingly. If it's useful for other modders consider contributing to a common mod such as [TabletopTweaks-Core](https://github.com/Vek17/TabletopTweaks-Core). Transpilers are a good use case for centralized code.

## Implementing IDemoralizeHandler

Now that we have a demoralize event it's time to write a handler. Since Hurtful triggers an attack that has a miss effect, the logic cannot be easily reproduced using `GameAction` and `Condition`. As a result the handler will be a component unique to Hurtful. Go back to Hurtful and add a private class `HurtfulComponent`:

```C#
private class HurtfulComponent : UnitFactComponentDelegate, IDemoralizeHandler
{
  private readonly ConditionsChecker Conditions;

  public HurtfulComponent(ConditionsBuilder conditions)
  {
    Conditions = conditions.Build();
  }

  public void OnDemoralizeResolved(Demoralize demoralize, RuleSkillCheck intimidateCheck)
  {
    if (intimidateCheck.Success)
    {
      if (!Conditions.Check())
      {
        Logger.Verbose($"Conditions not met");
        return;
      }

      var target = ContextData<MechanicsContext.Data>.Current?.CurrentTarget?.Unit;
      if (target is null)
      {
        Logger.Warn($"No target for demoralize.");
        return;
      }

      // Make sure target is not immune to demoralize, indicated by the presence of either Buff or GreaterBuff
      if (!(target.HasFact(demoralize.Buff) || target.HasFact(demoralize.GreaterBuff)))
      {
        Logger.Verbose($"{target.CharacterName} immune to demoralize");
        return;
      }

      Logger.Verbose($"{target.CharacterName} demoralized");

      // TODO: Attack!
    }
    else
    {
      Logger.Verbose($"Intimidate check failed");
    }
  }
}
```

> [!TIP]
> Finding the target was copied from Demoralize. Originally I tried using the `Context` but it didn't work so I looked for existing references.

I chose to accept a `ConditionsBuilder` because triggering hurtful requires the target to be in melee range and uses a swift action. While you could add that logic here I thought it was easier to re-use the existing conditions in BPCore, [TargetInMeleeRange](xref:BlueprintCore.Conditions.New.TargetInMeleeRange) and [HasActionsAvailable](xref:BlueprintCore.Conditions.New.HasActionsAvailable).

In addition to any specified conditions this obviously doesn't work if there is no target and there is a check to see if demoralize applied any buff. If the target is immune to demoralize then they should not be a valid target. If you see problems with this implementation, you're not alone! This is discussed further at the end of the tutorial.

For the attack itself look at `ContextActionMeleeAttack` for pointers. If there were no miss effect you could just take an `ActionsBuilder` and use it directly, but we need to check the result of the attack and take an action:

```C#
var attack =
  Context.TriggerRule<RuleAttackWithWeapon>(
    new(caster, target, threatHandMelee.Weapon, attackBonusPenalty: 0));

if (!attack.AttackRoll.IsHit)
{
  Logger.Verbose($"Attack missed, removing demoralize effects");
  target.RemoveFact(demoralize.Buff);
  target.RemoveFact(demoralize.GreaterBuff);
}
```

Finally the attack itself consumes a swift:

```C#
caster.SpendAction(UnitCommand.CommandType.Swift, isFullRound: False, timeSinceCommandStart: 0);
var attack =
  Context.TriggerRule<RuleAttackWithWeapon>(
    new(caster, target, threatHandMelee.Weapon, attackBonusPenalty: 0));
```

## Adding a Toggle

Since Wrath can be played in either turn-based or real-time mode, triggered abilities typically have a toggle which can disable them. This is particularly important because Hurtful uses a resource, a swift action, the player may not want to spend.

This is done using `BlueprintActivatableAbility`. Activatable abilities are generally simple blueprints without components that specify a `BlueprintBuff` which is applied when toggled on and removed when toggled off. Create a buff with the `HurtfulComponent` to trigger the attack and an activatable ability using that buff:

```C#
var buff =
  BuffConfigurator.New(BuffName, BuffGuid)
    .SetFlags(BlueprintBuff.Flags.HiddenInUi)
    .AddComponent(
      new HurtfulComponent(ConditionsBuilder.New().TargetInMeleeRange().HasActionsAvailable(requireSwift: true)))
    .Configure();

var ability =
  ActivatableAbilityConfigurator.New(AbilityName, AbilityGuid)
    .SetDisplayName(FeatDisplayName)
    .SetDescription(FeatDescription)
    .SetIcon(IconName)
    .SetBuff(buff)
    .Configure();
```

There's no need to have a buff icon so just skip all of that and set `BlueprintBuff.Flags.HiddenInUi`. The same icon, name, and description used for the feat can apply to the activatable ability.

Finally update the feature to grant the activatable ability using `AddFacts()`:

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
  .SetDisplayName(FeatDisplayName)
  .SetDescription(FeatDescription)
  .SetIcon(IconName)
  .AddFeatureTagsComponent(featureTags: FeatureTag.Melee | FeatureTag.Attack | FeatureTag.Skills)
  .AddPrerequisiteStatValue(StatType.Strength, 13)
  .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
  .AddFacts(new() { ability })
  .Configure();
```

It was a long road to get here thanks to the transpiler, but everything should be ready for testing:

![Smacking Camellia with hurtful](~/images/advanced_feat/hurtful_attack.png)

## Finishing Touches

There is no solution for this feat. Functionally the feat is complete but there are a variety of changes you might consider for your own implementation such as recommendations for intimidate related feats.

In particular you might want to address the elephant in the room: the way Hurtful detects immunity to demoralize and removes buffs is up for debate.

Maybe a creature is specifically immune to Shaken but not Frightened, but the character's demoralize only applies Shaken. Is the creature immune to demoralize? According to this implementation it is.

As written Hurtful only makes mention of Shaken. By that definition a missed attack should have no impact on other conditions applied. In fact, if a blueprint used `Demoralize` with a buff other than Shaken, Hurtful should have no effect on miss. While we're at it, the rules actually say if Hurtful fails to cause damage, not if the attack misses.

Also, Hurtful should only remove effects caused by Hurtful. The current implementation will remove them even if they were caused by something else.

I chose the implementation based on my interpretation of Hurtful's intent, and because I didn't want to spend too much time trying to perfectly implement the functionality. It was a feat created early in Pathfinder 1e at a time when there weren't many things that could change the effect caused by demoralize. 

I did not include any of the myriad of other effects like Shatter Confidence and Swordlord Prowess either. I felt the main features were the Buff and Greater Buff, and those should be removed on a miss. Everything else is its own rider effect that has no interaction with Hurtful.

You may feel differently and can implement it the way you want in your mod.