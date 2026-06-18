using Sqlite3Plugin;

namespace Elements.Data
{
    public class MasterSkillDatabase : AbstractMasterDatabase 
    {
        private PreparedQuery _selectQuery_masterSkillAction; 
        private PreparedQuery _selectQuery_masterSkillData; 
        private PreparedQuery _selectQuery_masterSkillCost; 
        private PreparedQuery _selectQuery_masterSpskillLabelData; 
        private PreparedQuery _selectQuery_masterDefineSpskill; 
        private PreparedQuery _selectQuery_masterSpskillLvInitializeData; 
        private PreparedQuery _selectQuery_masterUbAutoDefine; 
        private PreparedQuery _selectQuery_masterUbAutoData; 
        private PreparedQuery _selectQuery_masterMetamorphose; 
        private PreparedQuery _selectQuery_masterUnitSkillDataRf; 
        private PreparedQuery _selectQuery_masterHpDrainAt; 
        private PreparedQuery _selectQuery_masterTpRecoveryAt; 
        private PreparedQuery _selectQuery_masterEnvironmentSkillDetail; 
        private PreparedQuery _indexedSelectQuery_defineSpskill_spSkillId; 
        private PreparedQuery _indexedSelectQuery_metamorphose_typeId; 
        private PreparedQuery _indexedSelectQuery_unitSkillDataRf_skillId; 
        private PreparedQuery _indexedSelectQuery_unitSkillDataRf_rfSkillId; 
        private DBProxy _dbProxy; 
        private const string _commonSelectPrefixSkillAction = "SELECT `action_id`,`class_id`,`action_type`,`action_detail_1`,`action_detail_2`,`action_detail_3`,`action_value_1`,`action_value_2`,`action_value_3`,`action_value_4`,`action_value_5`,`action_value_6`,`action_value_7`,`target_assignment`,`target_area`,`target_range`,`target_type`,`target_number`,`target_count`,`description`,`level_up_disp` FROM `skill_action`";
        private const string _commonSelectPrefixSkillData = "SELECT `360fb26f3712f7996aa5c4c15d044cc135bf8a93fac98b753fe3bd7e6ca06d91`,`028941137f996b1a9aa5403529c415bfb27fa82717eac98de945da1341b3b38a`,`3d08bb68e13b0147c4907f5e5768178ee6ae1bcf5b856a1081ae0edf27e5f5bb`,`573c19e2c8494d92eec8c567d1a2fdc4480cb0a9c1b9ac34afcbc890f4401103`,`3d192dd05d2eee9c79d8f0f2d080ee6469995fd7bf7976990d25baf5e7f39f9d`,`c34defee46ea9f5488fad1b2113450eba1b98a588fb27b0322365ded4ce5ac45`,`8ee92b36c72a01f0c2f93ea4a1ec213ca70cb2ca01c35d58868ea5887ce8ce6b`,`12f7ee648689492077cf91531d4870cac5e5815dcb614c78aa86e97dc4f7d463`,`2fbb7b91f7db516bb382afa0b5d2041580e5b75e12f833e8da65d8b7b3f35153`,`52f65053d11162e1bd450df099f5ce0c25be5a8075a10ef617a4a2b6010068b9`,`959a823bce3db2fb6b06240f70cd49c2bc2dc79a54ab4b7a6ecd2d98c404837e`,`2f3b6ae17349f27a20b15444c66dd3bbc33188452ddf64ac74ca8be6e22a2af5`,`5d85d4ca24e80ce0419a442ae72391d181e3812fe7ed0988cb891e3e6baf420b`,`f821cac650456817386238cc9f3e83bfd5f9fc7bf9e107740efa93c726c9cc1a`,`44cffc8630485ea4afbafa9a127d8c028b719e7b3af614d523e514617cd2dc46`,`0cd299280bf2dc1be84a290cb80765e2f39067e838829a07fd59a3168febdf1e`,`30a0c3602113afade31c4f8f535d7efcff7ad9a2edb6622e7e50da01df4a1a7c`,`fc5e4bbe18cca78ea4cc06e5502e2419f71a0856fba75408012b5255f6dfb1f8`,`c8934f1ec179bc13d31269bb7b12c0135ac2eb0f7b59c49a81a5366952d92475`,`e128951014197efd080fc67f209cc561709d0d6d4b55edfae95a3f5e5bd58046`,`6bc6f80d99479caacbd7b26847a171e35c686e731fa38f3ff8e8126e7b79790e`,`0c72244080970448c50a55098c67c4f7d3c72a51d1672f3fe9da644e9d7f3335`,`dea99fd1fe10b0aea7c597a044a6b06df4c1e78dba8de232332ae9446f125d80`,`6774846f519c1794cec0b791e3d65ab422001001d9c21ee59458c1540ebc960f`,`c422afb04c886bf918325c760f6aeabc87fddb4fdf67699fa9583c5b0f631abf`,`c1ca8632422ce331e3ddc59dcb067372149e532f2d38b65b8ec91ab5d464c3a5`,`1f9e93924935d42658fe43da9a686ebbbcb857e3ec301fe29fc346f964e70101`,`8fecc18da1171154a1f0e78904278f8413ac2faa52ed895104af4cbdcb378d33` FROM `v1_6a2d07172ddded9f4726f652dfdbd318dd2d280010be8f8ef44271acc1fe0da7`";
        private const string _commonSelectPrefixSkillCost = "SELECT `90b606e67c0e9bc7f884cf612a360c7e2d145ff36e90f222b2079cb21172dc3a`,`60208b8a3d65736afd3076c475fb787a955ca73b6d490df0751b972b38e8b2ec` FROM `v1_46fe8c702e1710f7e36c259a8f60c8d4bace3391781aac8d4abdbcaae5da7fa2`";
        private const string _commonSelectPrefixSpskillLabelData = "SELECT `a448303bc5b581fbf8ce31bc95d50c3ce66fdd810dffc723e1210fadeb7ab1a1`,`2f6c27c1b22c727134c5463e64d212cf151c3de84f1e77c74bbbcdfa286d2752`,`701b61348bbdffd891d43319671d71791f654f2b01c4db0b2cfdd1f12b669ee9` FROM `v1_530c7a943417d6a9d70fe3f527b49bbed67700967f06954b16bb28976f9c9aaa`";
        private const string _commonSelectPrefixDefineSpskill = "SELECT `89f5b88c3a1e75185a50585db42c5d59c7815946f3916c35fa98276da24338c3`,`9bdca04c3e96f2ba6c9c26b4076fcceb84ee0fbbcedaec334dc8f24ec7622854`,`94f065238f7a320461399f2797a17e56f9c3da2a3df5dc399593c7026d2b3db9`,`e10d9d86d7040545b0e0aaf76eb0f293cb8678911b96c5da77e22a4a07b80493` FROM `v1_15a2ecf2a538dfc410a9a522cae907f94a64a5c347f8580d829718ce96488955`";
        private const string _commonSelectPrefixSpskillLvInitializeData = "SELECT `9e5cde9bec649c7be58abdf95e246bb02fc9371f9884c1ce36a394f193bcaa7c`,`6b27657b3abfcd5a6b763b889f19dec62d55394c0f6ebfcd7e87a324b68ac303` FROM `v1_d414136e28757199007032475e1f3bc63fcd441928be1c951acb165db4e10bf5`";
        private const string _commonSelectPrefixUbAutoDefine = "SELECT `c357139132dbfc89c5be89256594f0f78dcd102866e6ee0de7c64608d319a307`,`3e5e1038cbb521b58e43eb94136a35a7a55fb33e26317fd47ce864f6bc7fde11`,`7e9eb061c3d87e33c8c425180fa28a51c8543451f14bf6e82862ca0773bcde08`,`9644ed4fa88a7080844d6c07d3855f5d75c0ebca7269d511b686e054470595d3`,`646bf717033ab1b6a9b86a2220b9353695e00f3634a3f2c130b75b73e1700df8`,`a90f6540f15910e3fa76635d818394b3b46bfb8604ac3d786709be50654e92a1` FROM `v1_bc197e0fb0ebace90adf3a86b88a99fe7cf5ccd5f87d9cba1db0094f23e1f696`";
        private const string _commonSelectPrefixUbAutoData = "SELECT `f7814af91816a1e52ed0393daf6631ca35fd9a520820be804b7516c51eef523a`,`b9856eb373f4f2ce97b2b15e0cf896a032cfc6bc6656f4ff16d4468e3ff808fe`,`2c91a583d1ed756650389e24539fd1f1b7ea2007be78504be96b8045fda204bd`,`d9d34dc92ec7e5e4acbc908248b5f2807bd5d8ff26b8d4ac37cb067c4c4df5d9`,`069c754b4a3571cdd576168eab7067eecf12fc07d1f40c0110992ca0dd8610f4`,`2137dcf6ca539a0d857bf44cd36aeca91de2a9758bb01e07a5e2b1adb649638d`,`6d4b51f1be9627fe3b5b8fa4496b9ee13b6770d9da8693cb32cd1b96b692a960`,`33ce20baf465e93dff76b62514d7f07ba9ba44b47555b3f83b29dd0da2bd17d3`,`73c0e84b8706416273eff54e4c03d58a4a1b004cf6f79511f6e5f6a8d103bec1`,`7954d10e4419996613fe340c6dd20b2d2c1bdf45940f918ab2d9c3c8003dd22a`,`97dac4f0f1f22fe0067276b6f238c299a980f6eae0e3e71686f5752ea4e9601c`,`c26389ba32a1e5637c2c7fd212dadfe0e5e8170345bc564412bf8a579942fc0c` FROM `v1_8e046d0b6fb4d2d1837f7fbb350d2e30cc5e5faaa1bca9fafbfeba01c9cbd028`";
        private const string _commonSelectPrefixMetamorphose = "SELECT `749e347e5a3abcebf7360be1e1d412e1b06e54d6018563ef384161274fd78508`,`702a21091f94dabc146a6dd3efc9b2700a32ed3b249dc9e298d2769d0b20912a`,`fa6651b4babf2fce5990c97f83e24b8a53516912cb16f2ed9e2c7326707a36d2` FROM `v1_ad1f877bcd757087d4c38423d59a456f0d1ac7abfdd6237705669fc52a9ccbf4`";
        private const string _commonSelectPrefixUnitSkillDataRf = "SELECT `7d960dd40916bad8c3a3df9ab74b04839301482dbbe357b81073d5117aa54545`,`90b0f5dc032d4db8b572c5606f51521509b600bd161a4ca3f812a632725a598a`,`a4e3a76f64f5a9da4986695aebdc3cafbcd45cb0e7c2ae9efb38673b4bb809cc`,`9a729831bdf89de1e90d98345a72033801499b01c358dc5bdb15c7fc6d2e1a74`,`41fd8f4e71254d9537514adfb13b3686a68240896ff6f30d1091adfdb9014604` FROM `v1_3bf2d4f76f7f7dff36e29646f0977e4d9404fd6ff1d8e53ae2f0b98fe8678059`";
        private const string _commonSelectPrefixHpDrainAt = "SELECT `6e9b4f9cfab05692b752f56fb48bf2e4d7469c6258d40015c0378a86b210f2f2`,`f067d0bdff70aa1642fd1eff44b91bd9806b68c2bfba1b5a897a546c58ceee9e`,`7a5e25a666a0eb3d4826ec439ef14e8ca4ad918a344a3534001fa8a001d26b31` FROM `v1_d51a7043a03cfe575e2a23d145fd4b6bbd7e7dead71f9fc5595b65a05858b070`";
        private const string _commonSelectPrefixTpRecoveryAt = "SELECT `31567cb604b616a8defc22b17ba32aed2edc542d6cf5ca18790209cbc036d76d`,`c24dec01ebc8d72a136020881d964ef1c6b83b9a5513acd3de1dd7c3a25c7768`,`5ac997b100c554d061ef5759b1d0d6947ef12f8ba6dd9e174f18875904afca5f` FROM `v1_3f5f3553fc899c3914724543493ed5044552af2c58a291301bae4fba9d916999`";
        private const string _commonSelectPrefixEnvironmentSkillDetail = "SELECT `93461da61099c70a11bed3a062aaa1769b8ebabca1f98c1acce8db1230f7cc60`,`ac71ce78d6f39a9ca29fc41c01fb7f03aa838219d1e434b45979b00d9a3b783d`,`7b051fe0590fc600484609ebdfa2fd55a164c838ee27cc8933c2db771547148d`,`225cfefa87ab39228ff6d24841a755ea7ccbff613979984dd8a68cae3881f2b1` FROM `v1_15d3f2e6772dc11b31f149bc1e4443b1960dc0a7865de8809860ab952878cece`";

        public MasterSkillAction masterSkillAction { get; set; }
        public Elements.Data.MasterSkillData masterSkillData { get; set; }
        public Elements.Data.MasterSkillCost masterSkillCost { get; set; }
        public Elements.Data.MasterSpskillLabelData masterSpskillLabelData { get; set; }
        public Elements.Data.MasterDefineSpskill masterDefineSpskill { get; set; }
        public Elements.Data.MasterSpskillLvInitializeData masterSpskillLvInitializeData { get; set; }
        public Elements.Data.MasterUbAutoDefine masterUbAutoDefine { get; set; }
        public Elements.Data.MasterUbAutoData masterUbAutoData { get; set; }
        public Elements.Data.MasterMetamorphose masterMetamorphose { get; set; }
        public Elements.Data.MasterUnitSkillDataRf masterUnitSkillDataRf { get; set; }
        public Elements.Data.MasterHpDrainAt masterHpDrainAt { get; set; }
        public Elements.Data.MasterTpRecoveryAt masterTpRecoveryAt { get; set; }
        public Elements.Data.MasterEnvironmentSkillDetail masterEnvironmentSkillDetail { get; set; }

        public MasterSkillDatabase(DBProxy dbProxy)
        {
            _dbProxy = dbProxy;
        }

        public override Query Query(string sql)
        {
            return _dbProxy.Query(sql);
        }

        public override void Unload() { }

        public Query GetSelectAllQuery_SkillAction()
        {
            return Query(_commonSelectPrefixSkillAction);
        }

        public Query GetSelectAllQuery_SkillData()
        {
            return Query(_commonSelectPrefixSkillData);
        }

        public Query GetSelectAllQuery_SkillCost()
        {
            return Query(_commonSelectPrefixSkillCost);
        }

        public Query GetSelectAllQuery_SpskillLabelData()
        {
            return Query(_commonSelectPrefixSpskillLabelData);
        }

        public Query GetSelectAllQuery_DefineSpskill()
        {
            return Query(_commonSelectPrefixDefineSpskill);
        }

        public Query GetSelectAllQuery_SpskillLvInitializeData()
        {
            return Query(_commonSelectPrefixSpskillLvInitializeData);
        }

        public Query GetSelectAllQuery_UbAutoDefine()
        {
            return Query(_commonSelectPrefixUbAutoDefine);
        }

        public Query GetSelectAllQuery_UbAutoData()
        {
            return Query(_commonSelectPrefixUbAutoData);
        }

        public Query GetSelectAllQuery_Metamorphose()
        {
            return Query(_commonSelectPrefixMetamorphose);
        }

        public Query GetSelectAllQuery_UnitSkillDataRf()
        {
            return Query(_commonSelectPrefixUnitSkillDataRf);
        }

        public Query GetSelectAllQuery_HpDrainAt()
        {
            return Query(_commonSelectPrefixHpDrainAt);
        }

        public Query GetSelectAllQuery_TpRecoveryAt()
        {
            return Query(_commonSelectPrefixTpRecoveryAt);
        }

        public Query GetSelectAllQuery_EnvironmentSkillDetail()
        {
            return Query(_commonSelectPrefixEnvironmentSkillDetail);
        }

        public PreparedQuery GetSelectQuery_SkillAction()
        {
            if (_selectQuery_masterSkillAction == null)
                _selectQuery_masterSkillAction = _dbProxy.PreparedQuery(_commonSelectPrefixSkillAction + " WHERE `action_id` = ?");
            return _selectQuery_masterSkillAction;
        }

        public PreparedQuery GetSelectQuery_SkillData()
        {
            if (_selectQuery_masterSkillData == null)
                _selectQuery_masterSkillData = _dbProxy.PreparedQuery(_commonSelectPrefixSkillData + " WHERE `360fb26f3712f7996aa5c4c15d044cc135bf8a93fac98b753fe3bd7e6ca06d91` = ?");
            return _selectQuery_masterSkillData;
        }

        public PreparedQuery GetSelectQuery_SkillCost()
        {
            if (_selectQuery_masterSkillCost == null)
                _selectQuery_masterSkillCost = _dbProxy.PreparedQuery(_commonSelectPrefixSkillCost + " WHERE `90b606e67c0e9bc7f884cf612a360c7e2d145ff36e90f222b2079cb21172dc3a` = ?");
            return _selectQuery_masterSkillCost;
        }

        public PreparedQuery GetSelectQuery_SpskillLabelData()
        {
            if (_selectQuery_masterSpskillLabelData == null)
                _selectQuery_masterSpskillLabelData = _dbProxy.PreparedQuery(_commonSelectPrefixSpskillLabelData + " WHERE `a448303bc5b581fbf8ce31bc95d50c3ce66fdd810dffc723e1210fadeb7ab1a1` = ?");
            return _selectQuery_masterSpskillLabelData;
        }

        public PreparedQuery GetSelectQuery_DefineSpskill()
        {
            if (_selectQuery_masterDefineSpskill == null)
                _selectQuery_masterDefineSpskill = _dbProxy.PreparedQuery(_commonSelectPrefixDefineSpskill + " WHERE `89f5b88c3a1e75185a50585db42c5d59c7815946f3916c35fa98276da24338c3` = ?");
            return _selectQuery_masterDefineSpskill;
        }

        public PreparedQuery GetSelectQuery_SpskillLvInitializeData()
        {
            if (_selectQuery_masterSpskillLvInitializeData == null)
                _selectQuery_masterSpskillLvInitializeData = _dbProxy.PreparedQuery(_commonSelectPrefixSpskillLvInitializeData + " WHERE `9e5cde9bec649c7be58abdf95e246bb02fc9371f9884c1ce36a394f193bcaa7c` = ?");
            return _selectQuery_masterSpskillLvInitializeData;
        }

        public PreparedQuery GetSelectQuery_UbAutoDefine()
        {
            if (_selectQuery_masterUbAutoDefine == null)
                _selectQuery_masterUbAutoDefine = _dbProxy.PreparedQuery(_commonSelectPrefixUbAutoDefine + " WHERE `c357139132dbfc89c5be89256594f0f78dcd102866e6ee0de7c64608d319a307` = ?");
            return _selectQuery_masterUbAutoDefine;
        }

        public PreparedQuery GetSelectQuery_UbAutoData()
        {
            if (_selectQuery_masterUbAutoData == null)
                _selectQuery_masterUbAutoData = _dbProxy.PreparedQuery(_commonSelectPrefixUbAutoData + " WHERE `f7814af91816a1e52ed0393daf6631ca35fd9a520820be804b7516c51eef523a` = ?");
            return _selectQuery_masterUbAutoData;
        }

        public PreparedQuery GetSelectQuery_Metamorphose()
        {
            if (_selectQuery_masterMetamorphose == null)
                _selectQuery_masterMetamorphose = _dbProxy.PreparedQuery(_commonSelectPrefixMetamorphose + " WHERE `749e347e5a3abcebf7360be1e1d412e1b06e54d6018563ef384161274fd78508` = ?");
            return _selectQuery_masterMetamorphose;
        }

        public PreparedQuery GetSelectQuery_UnitSkillDataRf()
        {
            if (_selectQuery_masterUnitSkillDataRf == null)
                _selectQuery_masterUnitSkillDataRf = _dbProxy.PreparedQuery(_commonSelectPrefixUnitSkillDataRf + " WHERE `7d960dd40916bad8c3a3df9ab74b04839301482dbbe357b81073d5117aa54545` = ?");
            return _selectQuery_masterUnitSkillDataRf;
        }

        public PreparedQuery GetSelectQuery_HpDrainAt()
        {
            if (_selectQuery_masterHpDrainAt == null)
                _selectQuery_masterHpDrainAt = _dbProxy.PreparedQuery(_commonSelectPrefixHpDrainAt + " WHERE `6e9b4f9cfab05692b752f56fb48bf2e4d7469c6258d40015c0378a86b210f2f2` = ?");
            return _selectQuery_masterHpDrainAt;
        }

        public PreparedQuery GetSelectQuery_TpRecoveryAt()
        {
            if (_selectQuery_masterTpRecoveryAt == null)
                _selectQuery_masterTpRecoveryAt = _dbProxy.PreparedQuery(_commonSelectPrefixTpRecoveryAt + " WHERE `31567cb604b616a8defc22b17ba32aed2edc542d6cf5ca18790209cbc036d76d` = ?");
            return _selectQuery_masterTpRecoveryAt;
        }

        public PreparedQuery GetSelectQuery_EnvironmentSkillDetail()
        {
            if (_selectQuery_masterEnvironmentSkillDetail == null)
                _selectQuery_masterEnvironmentSkillDetail = _dbProxy.PreparedQuery(_commonSelectPrefixEnvironmentSkillDetail + " WHERE `93461da61099c70a11bed3a062aaa1769b8ebabca1f98c1acce8db1230f7cc60` = ?");
            return _selectQuery_masterEnvironmentSkillDetail;
        }

        public PreparedQuery GetSelectQueryWithIndex_DefineSpskill_SpSkillId()
        {
            if (_indexedSelectQuery_defineSpskill_spSkillId == null)
                _indexedSelectQuery_defineSpskill_spSkillId = _dbProxy.PreparedQuery(_commonSelectPrefixDefineSpskill + " WHERE `9bdca04c3e96f2ba6c9c26b4076fcceb84ee0fbbcedaec334dc8f24ec7622854` = ?");
            return _indexedSelectQuery_defineSpskill_spSkillId;
        }

        public PreparedQuery GetSelectQueryWithIndex_Metamorphose_TypeId()
        {
            if (_indexedSelectQuery_metamorphose_typeId == null)
                _indexedSelectQuery_metamorphose_typeId = _dbProxy.PreparedQuery(_commonSelectPrefixMetamorphose + " WHERE `749e347e5a3abcebf7360be1e1d412e1b06e54d6018563ef384161274fd78508` = ?");
            return _indexedSelectQuery_metamorphose_typeId;
        }

        public PreparedQuery GetSelectQueryWithIndex_UnitSkillDataRf_SkillId()
        {
            if (_indexedSelectQuery_unitSkillDataRf_skillId == null)
                _indexedSelectQuery_unitSkillDataRf_skillId = _dbProxy.PreparedQuery(_commonSelectPrefixUnitSkillDataRf + " WHERE `90b0f5dc032d4db8b572c5606f51521509b600bd161a4ca3f812a632725a598a` = ?");
            return _indexedSelectQuery_unitSkillDataRf_skillId;
        }

        public PreparedQuery GetSelectQueryWithIndex_UnitSkillDataRf_RfSkillId()
        {
            if (_indexedSelectQuery_unitSkillDataRf_rfSkillId == null)
                _indexedSelectQuery_unitSkillDataRf_rfSkillId = _dbProxy.PreparedQuery(_commonSelectPrefixUnitSkillDataRf + " WHERE `a4e3a76f64f5a9da4986695aebdc3cafbcd45cb0e7c2ae9efb38673b4bb809cc` = ?");
            return _indexedSelectQuery_unitSkillDataRf_rfSkillId;
        }
    }
}