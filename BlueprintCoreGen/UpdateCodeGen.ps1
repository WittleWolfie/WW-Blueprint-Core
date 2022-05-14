remove-item ..\..\..\..\BlueprintCore\BlueprintCore\Blueprints\Configurators -force -recurse
copy-item .\Configurators\ ..\..\..\..\BlueprintCore\BlueprintCore\Blueprints -force -recurse -verbose

remove-item ..\..\..\..\BlueprintCore\BlueprintCore\Actions\Builder -force -recurse -exclude ActionsBuilder.cs
copy-item .\Actions\Builder\ ..\..\..\..\BlueprintCore\BlueprintCore\Actions -force -recurse -verbose

remove-item ..\..\..\..\BlueprintCore\BlueprintCore\Conditions\Builder -force -recurse -exclude ConditionsBuilder.cs
copy-item .\Conditions\Builder\ ..\..\..\..\BlueprintCore\BlueprintCore\Conditions -force -recurse -verbose