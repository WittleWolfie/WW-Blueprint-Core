using System.Collections.Generic;

namespace BlueprintCoreGen.Analysis
{
  internal static class BlueprintReferenceOverrides
  {
    internal static Dictionary<string, string> BlueprintNameByGuid =
      new()
      {
        /** Start Rampage **/

        { "747b767ba54a40af84cf3a83baae9ea6", "RampageEI_Acid" },
        { "1da8b2233d59448fa045d9c2f1b1e275", "RampageEI_Cold" },
        { "6f6c79ccdd794f91bbe069467e36762c", "RampageEI_Electric" },
        { "37f5b7c9baaf41e2a115263436213620", "RampageEI_Fire" },

        { "1679745f05164ae6bf7ecd470571b69c", "RampageER5_Acid" },
        { "1744efd76b9d4c67ab692a874f5f5c80", "RampageER5_Cold" },
        { "5c47d81e33a147b98b4d0cc2c8950bd5", "RampageER5_Electric" },
        { "06acd00ba8d34489baea16962cf937c9", "RampageER5_Fire" },

        { "679b30752cf74d6ea21d0dce8c24baab", "RampageER10_Acid" },
        { "96eee5429ac34130931628eab913587c", "RampageER10_Cold" },
        { "c8f919e1a60f4447b912b8a73cb50d8d", "RampageER10_Electric" },
        { "829a3a8bc2a841b9b77987d29b9008ae", "RampageER10_Fire" },

        { "7321a73805b44b8c8d73e1496bf65ffb", "RampageER20_Acid" },
        { "c820d19919964a38a903e4725a22a594", "RampageER20_Cold" },
        { "bc78f22ddef24d0daed007b89668add8", "RampageER20_Electric" },
        { "907e145125ea415695799212ee057530", "RampageER20_Fire" },

        { "66adf91730c6448d8821cd3a3c2be778", "RampageExtraEffect11_Acid" },
        { "df2076388506410e968a673946516611", "RampageExtraEffect11_Cold" },
        { "017ed1a0d47a422eab183a88084966b1", "RampageExtraEffect11_Electric" },
        { "b0e6b4d760eb47538f424ce313c47388", "RampageExtraEffect11_Fire" },

        { "b2fd72c5400740929b61520938da88aa", "RampageExtraEffect20_Acid" },
        { "e96fc2da3bfe42c780af21ae9a02a43f", "RampageExtraEffect20_Cold" },
        { "e6d0b262b3154bb3a6ce7c55a68286f1", "RampageExtraEffect20_Electric" },
        { "69004a7aa5914952af048dfd58fb89d4", "RampageExtraEffect20_Fire" },

        { "b55375fc8af84eebbb14f857f94daeac", "RampageOnHitDamage_Acid" },
        { "9b9d7408c30640ed9b8b158b706a98c2", "RampageOnHitDamage_Cold" },
        { "a0fbe19f87134774890d8f74c143a9b7", "RampageOnHitDamage_Electric" },
        { "0665256ed3804f03872928ad115652fe", "RampageOnHitDamage_Fire" },

        /** End Rampage **/

        /** Start Witch **/

        { "8821290b22ea5ea4a96d82be45f2bd61", "WitchPatronSpellLevel1_Ancestors" },
        { "ad7f803d19c18fc4f9c5ee65fc12a237", "WitchPatronSpellLevel1_Deception" },
        { "b50f42b1ef5334544862c3458d5b06cf", "WitchPatronSpellLevel1_Devotion" },
        { "394a16c90dcbd9242850248195490a7f", "WitchPatronSpellLevel1_Elements" },
        { "87107350a4f8c65458da367c102c610e", "WitchPatronSpellLevel1_Endurance" },
        { "5478de32d30eab3469981fa7396da80a", "WitchPatronSpellLevel1_Healing" },
        { "656268a8f122c0844b74a8d99e051d1d", "WitchPatronSpellLevel1_Insanity" },
        { "2e28c42c019f7174682c700046eb0e15", "WitchPatronSpellLevel1_Mercy" },
        { "c60530818159a304b8b21a8979e53776", "WitchPatronSpellLevel1_Shadow" },
        { "4f068ba134bcabf47a370c5ecde812c4", "WitchPatronSpellLevel1_Strength" },
        { "2e2f50be52f7ea245a4bc29fa2177cc4", "WitchPatronSpellLevel1_Transformation" },
        { "fb5ae7deb7cbfd94a85c986df8f47c20", "WitchPatronSpellLevel1_Winter" },

        { "e770cbbaf5948164f8995973f412cac9", "WitchPatronSpellLevel2_Ancestors" },
        { "d46fd148c1c4f9c42a7734d8476878f8", "WitchPatronSpellLevel2_Deception" },
        { "98ef9856915d231479c9744b341ce32a", "WitchPatronSpellLevel2_Devotion" },
        { "393c66ba0fdd5d048ace42eef4f1f213", "WitchPatronSpellLevel2_Elements" },
        { "e3d5551eb4f83dd4fba5f8e383114642", "WitchPatronSpellLevel2_Endurance" },
        { "04cba945e33f7db4daa8532477b0abeb", "WitchPatronSpellLevel2_Healing" },
        { "5cb9fb6181937914eb18bbee827a2890", "WitchPatronSpellLevel2_Insanity" },
        { "3b4f1cbcbb0a00b41b4c39f6185b1188", "WitchPatronSpellLevel2_Mercy" },
        { "6414624190cc33f4facc0db67374514b", "WitchPatronSpellLevel2_Shadow" },
        { "40ff77fb544b2f84ca34ee709580acea", "WitchPatronSpellLevel2_Strength" },
        { "dd33b6eb65ada894fbb991eb573092a7", "WitchPatronSpellLevel2_Transformation" },
        { "f4b39358356bf4b4d9cef1182dc792a8", "WitchPatronSpellLevel2_Winter" },

        { "9ca706b0ff28d984ab610135ef892ffd", "WitchPatronSpellLevel3_Ancestors" },
        { "53f733d1f1704a64cb896b984b1c06d5", "WitchPatronSpellLevel3_Deception" },
        { "240f0fac5f96ded4fb689640818153d3", "WitchPatronSpellLevel3_Devotion" },
        { "4945e9fe38f49ce488bfc796a1bd4da3", "WitchPatronSpellLevel3_Elements" },
        { "e5c954e6c9091c440adabc6be70a4a9e", "WitchPatronSpellLevel3_Endurance" },
        { "03df6cb9fdd13cb499cb390f7c119f59", "WitchPatronSpellLevel3_Healing" },
        { "a8302b15c2b26b84ea5f255b456e8b8d", "WitchPatronSpellLevel3_Insanity" },
        { "3f64af92e090f81418d267003d5ed0c7", "WitchPatronSpellLevel3_Mercy" },
        { "788e8aa1b5b0a4742a010d13383ad9b8", "WitchPatronSpellLevel3_Shadow" },
        { "188d61d3f5ac1874e8365f1b2bf940c4", "WitchPatronSpellLevel3_Strength" },
        { "040d5d2c03c6fe742834af9ec84bc859", "WitchPatronSpellLevel3_Transformation" },
        { "8a8f1bb088a9a9e4497eea6412180431", "WitchPatronSpellLevel3_Winter" },

        { "15dca01777ab73749bced5f5f582aa8a", "WitchPatronSpellLevel4_Ancestors" },
        { "fa7eafc737f43df4db9e896b0cb7a14b", "WitchPatronSpellLevel4_Deception" },
        { "67b193a85d73dd142b1de8eeba2647c6", "WitchPatronSpellLevel4_Devotion" },
        { "8dd29385bdf79094092cd90e4d9cd0a2", "WitchPatronSpellLevel4_Elements" },
        { "8c168bda09ca64d4c983acdd2f620adb", "WitchPatronSpellLevel4_Endurance" },
        { "2f2457040b93e884894f5891ab4eaa30", "WitchPatronSpellLevel4_Healing" },
        { "038f684bc9f52924ab82d60cfa365597", "WitchPatronSpellLevel4_Insanity" },
        { "3448b8790e5447c4ea78bdf7fdda4e5d", "WitchPatronSpellLevel4_Mercy" },
        { "2ad0c36d8d5b1b24d8328a8d9771ecad", "WitchPatronSpellLevel4_Shadow" },
        { "b65b8d9c577a39548b6ca4c6c74d4c3c", "WitchPatronSpellLevel4_Strength" },
        { "53167b837ba41284abd67f8be189e649", "WitchPatronSpellLevel4_Transformation" },
        { "dabf0576d727f9a4fb40c0b4acf03cf1", "WitchPatronSpellLevel4_Winter" },

        { "061f0afdb62334945a2a1be7be4c6597", "WitchPatronSpellLevel5_Ancestors" },
        { "57f0558877e728b409b9d11b8a3abb83", "WitchPatronSpellLevel5_Deception" },
        { "f9ee8eee80b93e640840ae87d9760623", "WitchPatronSpellLevel5_Devotion" },
        { "9b6482a26fbf38b4abed7896718a8183", "WitchPatronSpellLevel5_Elements" },
        { "89c3d83e6ccac754cbb07152dd4b19a9", "WitchPatronSpellLevel5_Endurance" },
        { "bb76d9b9332f42141b13a818f87fb9e0", "WitchPatronSpellLevel5_Healing" },
        { "e475fb2cf16248b479254d970b7d43ad", "WitchPatronSpellLevel5_Insanity" },
        { "f0aa1997efdba6246b7b8a8acc9de92e", "WitchPatronSpellLevel5_Mercy" },
        { "056a13563b658254bae138d71b97faa7", "WitchPatronSpellLevel5_Shadow" },
        { "8dbb2e686b793a2459d3b21181ed2c15", "WitchPatronSpellLevel5_Strength" },
        { "a6f14ca03face8048904c92518677e89", "WitchPatronSpellLevel5_Transformation" },
        { "7c042e2ede1e0b540865c11221d28816", "WitchPatronSpellLevel5_Winter" },

        { "59691a0b57baee54192d4c8a17e75b77", "WitchPatronSpellLevel6_Ancestors" },
        { "429a261686c7c5742a610a92b41601d1", "WitchPatronSpellLevel6_Deception" },
        { "1fe59c0c5a60557438e9211e04328068", "WitchPatronSpellLevel6_Devotion" },
        { "8a0b860669f60714f8ebf7285bb81535", "WitchPatronSpellLevel6_Elements" },
        { "b2f582468e52b5c4fbda00215479a818", "WitchPatronSpellLevel6_Endurance" },
        { "7a9e7eaf9d8c3b14e802c9cb0aa382d7", "WitchPatronSpellLevel6_Healing" },
        { "8978b46115e80c64ba09d8e45cab6870", "WitchPatronSpellLevel6_Insanity" },
        { "62a358b0b5bb36349b330ea40d7ea573", "WitchPatronSpellLevel6_Mercy" },
        { "792e5fded79f3db4785e2592644bfb76", "WitchPatronSpellLevel6_Shadow" },
        { "d905e4e477a6c8d4ea09906d35e14261", "WitchPatronSpellLevel6_Strength" },
        { "68027fbdb1cdf43439e79f0336c2a4c5", "WitchPatronSpellLevel6_Transformation" },
        { "1f18168f5112b494ca3e9cbd58956f87", "WitchPatronSpellLevel6_Winter" },

        { "2d011ba269fb19344a1d0aeecd005aee", "WitchPatronSpellLevel7_Ancestors" },
        { "16fff96e05cd1a24db1e0254894d74e3", "WitchPatronSpellLevel7_Deception" },
        { "a7844d165e9ab7e4aa1113df7beb4167", "WitchPatronSpellLevel7_Devotion" },
        { "6e349aacc60b5b54ebd132fdc65c17bf", "WitchPatronSpellLevel7_Elements" },
        { "15f01e7b13cd26f48acf521a7f3d937b", "WitchPatronSpellLevel7_Endurance" },
        { "1a8eb95a1381eec48859b691c002f327", "WitchPatronSpellLevel7_Healing" },
        { "2b25d85f5cac64247b02fdc29d50ef45", "WitchPatronSpellLevel7_Insanity" },
        { "fa3585ef505ebd847b377a20d5c2e485", "WitchPatronSpellLevel7_Mercy" },
        { "e435cd96feb0a67428bd44fbd2619111", "WitchPatronSpellLevel7_Shadow" },
        { "67bafbb5f78e34545a0c1f0335b98c5a", "WitchPatronSpellLevel7_Strength" },
        { "c2b9cadeb701a104f8a27852aab98d76", "WitchPatronSpellLevel7_Transformation" },
        { "86cf4e8935e5f5e43bf31fd6c3c66525", "WitchPatronSpellLevel7_Winter" },

        { "937c6595be0888749ab5fe3b10c358fb", "WitchPatronSpellLevel8_Ancestors" },
        { "82f76f119c9bf4045a49ebe981cfe0d0", "WitchPatronSpellLevel8_Deception" },
        { "52e1cff2a17a0a044b1306962ab6f1fd", "WitchPatronSpellLevel8_Devotion" },
        { "fa87073eb39634141a289e8ffe50a99a", "WitchPatronSpellLevel8_Elements" },
        { "2f4098d98f92ba1488c58d91fb3df780", "WitchPatronSpellLevel8_Endurance" },
        { "972153fdefa0e994e8c0f0c1b977a496", "WitchPatronSpellLevel8_Healing" },
        { "d2cac6ebfff96d04284d9893c4833cd8", "WitchPatronSpellLevel8_Insanity" },
        { "d81e17108e77cb847a1ae1cd8a55383e", "WitchPatronSpellLevel8_Mercy" },
        { "537afa5b4ab46fd45897a20f6690b337", "WitchPatronSpellLevel8_Shadow" },
        { "b15ac28bffa3ca64b9297f8d2a80c435", "WitchPatronSpellLevel8_Strength" },
        { "799a0b3658f7af24ca125f4d7a2b8a69", "WitchPatronSpellLevel8_Transformation" },
        { "a519ac6294927b74fa3abcc451732a2b", "WitchPatronSpellLevel8_Winter" },

        { "6dde63856e5db5d45ac71dfb4775c61d", "WitchPatronSpellLevel9_Ancestors" },
        { "c586b9b7c4b48054bbfb7f67a28b18ad", "WitchPatronSpellLevel9_Deception" },
        { "5e1ff08d0d520ec458f4c72d8e396bc1", "WitchPatronSpellLevel9_Devotion" },
        { "391a6ff799fa6da40becedf4f5460be5", "WitchPatronSpellLevel9_Elements" },
        { "060f73b067ea43946985530258e53d85", "WitchPatronSpellLevel9_Endurance" },
        { "107c8557267fd534091c8fd0eb76bc3a", "WitchPatronSpellLevel9_Healing" },
        { "0cedb51c1da1897408efc9ffb37603c1", "WitchPatronSpellLevel9_Insanity" },
        { "d148fe7ea7478234a830498773ab9ae4", "WitchPatronSpellLevel9_Mercy" },
        { "160d0bf31f229c8488f3a889d3f45b9a", "WitchPatronSpellLevel9_Shadow" },
        { "a9a8a35b1ac265b44b13a282ca1b3e95", "WitchPatronSpellLevel9_Strength" },
        { "8fcbe0b311ed75c4eadd4789f0e78f70", "WitchPatronSpellLevel9_Transformation" },
        { "b148f0d1925de18449bbf22b7cf7a8e3", "WitchPatronSpellLevel9_Winter" },

        /** End Witch **/
      };
  }
}
