using UnityEngine;
using System;

using System.Collections.Generic;

public class ActionParameter : ISingletonField 
{
	// Fields
	private static StaticSingletonTree<ActionParameter> CGADOKMOKLF; // 0x0
	private static IBattleManagerForActionParameter NCKEHKCEKEB; // 0x8
	private static IBattleEffectPool battleEffectPool; // 0x10
	private static IBattleLog CBEHNPBCALN; // 0x18
	public eActionType ActionType; // 0x50
	public delegate void ActionDelegate();
	public Dictionary<int, GameObject> CKJKJIOBLJE; // 0xF0
	public bool JAGJDFNJLDC; // 0x18C
	public bool OGCEDJEHPAI; // 0x198
	public double OANMFHPOLBE; // 0x1B0
	protected List<SkillEffectCtrl> EHOJGACKMLC; // 0x1B8
	
	protected IBattleManagerForActionParameter OHHDPGCOAKG { get; }
	protected IBattleEffectPool FNKIMHBNDHB { get; }
	protected IBattleLog KBEKLHMIHGD { get; }
	public eTargetAssignment TargetAssignment { get; set; }
	public eTargetType TargetType { get; set; }
	public int MPGNOCOHOIK { get; set; }
	public int AFLJOGINHNK { get; set; }
	public float LADGHOJMJOJ { get; set; }
	public GDCIMHECIFP BMJJBOGDEAL { get; set; }
	public float GKGONJPAKKJ { get; set; }
	public int DOLBJPAKHHN { get; set; }
	public int CGBFGPDMFBN { get; set; }
	public int CJNOGDAAKLI { get; set; }
	public int CIOEAFLNNKC { get; set; }
	public List<BasePartsData> OPEOAICBCPB { get; set; }
	public Dictionary<eActionValue, double> IDGLGOLAOMA { get; set; }
	public float[] JIKJHCPJLNL { get; set; }
	public List<ActionExecTime> HFIPPOPIOOF { get; set; }
	public double KOFNFGAPIHC { get; set; }
	public int PNEHMHHNLLO { get; set; }
	public bool NKPAMAFAEAO { get; set; }
	public bool PCBLPLNDMJI { get; set; }
	public List<int> PPDFODNDELJ { get; set; }
	public ActionParameter.BIOHAHKMJDF BADPIBIANHG { get; set; }
	public bool GNMDPAJPKPF { get; set; }
	public List<NormalSkillEffect> DNCAGPBJAMD { get; set; }
	public List<NormalSkillEffect> CCGGIAFIBMP { get; set; }
	public bool GHHOCCFFDFL { get; set; }
	public NAEFABEPMJF AIPFADHCIGA { get; set; }
	public FLJOBLLDDNF LJNOGGDFPEJ { get; set; }
	public bool MNEAFONJNAL { get; set; }
	public Action PPPCPFJAKFE { get; set; }
	public Action JKLEPGJIPHJ { get; set; }
	public bool DNBLPHHCOCK { get; set; }
	public Dictionary<BasePartsData, long> BJHCIFLOHPH { get; set; }
	public int FFOFFHLDOFE { get; set; }
	public GameObject KKPLFEEFGIN { get; set; }
	public AnimationCurve MOLJBLPCNCP { get; set; }
	public AnimationCurve DFBHOCHHEDB { get; set; }
	public Dictionary<BasePartsData, bool> CAHHJGDKDAP { get; set; }
	public Dictionary<UnitCtrl, Dictionary<int, ActionExecedData>> KHAEBLCNBAC { get; set; }
	public bool IAPDDJHDNGG { get; set; }
	public Dictionary<UnitCtrl, List<int>> ENEPHEJAFLL { get; set; }
	public List<BasePartsData> DKAGNHBMFBM { get; set; }
	public Dictionary<BasePartsData, List<CriticalData>> BJDPKNHAJKN { get; set; }
	public Dictionary<eStateIconType, List<UnitCtrl>> JLKBFNKGOKF { get; set; }
	public Dictionary<BasePartsData, long> NFKIGNPADOA { get; set; }
	public Dictionary<BasePartsData, long> MGMKBAEMGNF { get; set; }
	public Dictionary<BasePartsData, long> HFLNLPFPDJG { get; set; }
	public Dictionary<eActionValue, double> MPBNILHHAJL { get; set; }
	public Dictionary<eActionValue, double> EAMOEGLCMIE { get; set; }
	public Dictionary<UnitCtrl, double> NMCLGGDMNPL { get; set; }
	public double ADJCIINJPHB { get; set; }
	public Dictionary<eActionValue, double> JFDPEDIHNCM { get; set; }
	public PDBLHMLEOHA.FHHCALPOPAK ADFGPHIFLFB { get; set; }
	public eEffectType EBPCDCMINIH { get; set; }
	public bool LMKPHDDFIKA { get; set; }
	public List<UnitCtrl> EIKPEIBCFFM { get; set; }
	public BasePartsData IDFMDLLMAAL { get; set; }
	public bool HMMAHNCHDNH { get; set; }
	public bool PLGIFCNIOKD { get; set; }

	public ActionParameter() { }

	[CompilerGenerated]
	// RVA: 0x36BAB4C Offset: 0x36BAB4C VA: 0x36BAB4C
	public void GCANHLCEMAO(Dictionary<eActionValue, double> param) { }

	// RVA: 0x36BAB5C Offset: 0x36BAB5C VA: 0x36BAB5C
	public void FHHNKMGLNNH(Action param) { }

	[CompilerGenerated]
	// RVA: 0x36BAB64 Offset: 0x36BAB64 VA: 0x36BAB64
	public void EEKNONFBJAJ(bool param) { }

	// RVA: 0x36BAB6C Offset: 0x36BAB6C VA: 0x36BAB6C
	public static void BFFFNOLCGJI() { }

	// RVA: 0x36BAC00 Offset: 0x36BAC00 VA: 0x36BAC00
	public bool EHBMAJDAFJL(UnitCtrl BEBLHLKLOPK, int FCEMMMPDGCC) { }

	// RVA: 0x36BACBC Offset: 0x36BACBC VA: 0x36BACBC
	public Dictionary<eActionValue, double> CMDPMFFKDJH() { }

	[CompilerGenerated]
	// RVA: 0x36BACCC Offset: 0x36BACCC VA: 0x36BACCC
	public int OGEOLGPLMNN() { }

	// RVA: 0x36BACD4 Offset: 0x36BACD4 VA: 0x36BACD4
	protected IBattleLog ADCGHFFLPCK() { }

	[CompilerGenerated]
	// RVA: 0x36BAD20 Offset: 0x36BAD20 VA: 0x36BAD20
	public float NLKJEMJCCDA() { }

	[CompilerGenerated]
	// RVA: 0x36BAD28 Offset: 0x36BAD28 VA: 0x36BAD28
	public int MNBMFMMDNPA() { }

	[CompilerGenerated]
	// RVA: 0x36BAD30 Offset: 0x36BAD30 VA: 0x36BAD30
	public List<BasePartsData> FODPBDHJEIF() { }

	[CompilerGenerated]
	// RVA: 0x36BAD38 Offset: 0x36BAD38 VA: 0x36BAD38
	public void GEBBHNDPHOE(List<int> param) { }

	// RVA: 0x36BAD40 Offset: 0x36BAD40 VA: 0x36BAD40
	public List<BasePartsData> GDPIGIKBJMB() { }

	[CompilerGenerated]
	// RVA: 0x36BAD48 Offset: 0x36BAD48 VA: 0x36BAD48
	public NAEFABEPMJF INBMMEBJHBH() { }

	[CompilerGenerated]
	// RVA: 0x36BAD50 Offset: 0x36BAD50 VA: 0x36BAD50
	public Action HMMCMNLPMAC() { }

	[CompilerGenerated]
	// RVA: 0x36BAD58 Offset: 0x36BAD58 VA: 0x36BAD58
	public PDBLHMLEOHA.FHHCALPOPAK BAEKOIDHGKA() { }

	// RVA: 0x36BAD60 Offset: 0x36BAD60 VA: 0x36BAD60
	public bool ODLGHPOBHHE(UnitCtrl BEBLHLKLOPK, int FCEMMMPDGCC) { }

	[CompilerGenerated]
	// RVA: 0x36BAE00 Offset: 0x36BAE00 VA: 0x36BAE00
	public bool FHGEHABNNKB() { }

	[CompilerGenerated]
	// RVA: 0x36BAE08 Offset: 0x36BAE08 VA: 0x36BAE08
	public void ENGMLKFMPJD(bool param) { }

	// RVA: 0x36BAE10 Offset: 0x36BAE10 VA: 0x36BAE10
	public void OODNCOPLHJC(UnitCtrl BEBLHLKLOPK, int FCEMMMPDGCC) { }

	[CompilerGenerated]
	// RVA: 0x36BB1D0 Offset: 0x36BB1D0 VA: 0x36BB1D0
	public void NEBAPEFJHAN(GDCIMHECIFP param) { }

	[CompilerGenerated]
	// RVA: 0x36BB1D8 Offset: 0x36BB1D8 VA: 0x36BB1D8
	public Action MNKOGPGMFNA() { }

	[CompilerGenerated]
	// RVA: 0x36BB1E0 Offset: 0x36BB1E0 VA: 0x36BB1E0
	public BasePartsData FCNLKKHDLDP() { }

	[CompilerGenerated]
	// RVA: 0x36BB1E8 Offset: 0x36BB1E8 VA: 0x36BB1E8
	public void OFOOMINIHJD(double param) { }

	// RVA: 0x36BB1F0 Offset: 0x36BB1F0 VA: 0x36BB1F0
	public float[] IFMJKCHMFCK() { }

	// RVA: 0x36BB1F8 Offset: 0x36BB1F8 VA: 0x36BB1F8
	public Dictionary<BasePartsData, List<CriticalData>> MFKBNLFPLDC() { }

	[CompilerGenerated]
	// RVA: 0x36BB200 Offset: 0x36BB200 VA: 0x36BB200
	public void EAPKIEGLLGE(AnimationCurve param) { }

	// RVA: 0x36BB210 Offset: 0x36BB210 VA: 0x36BB210
	public void KJBAHALFOPI(double param) { }

	// RVA: 0x36BB218 Offset: 0x36BB218 VA: 0x36BB218
	public void AJJHLMMCIFO(Dictionary<BasePartsData, long> param) { }

	// RVA: 0x36BB228 Offset: 0x36BB228 VA: 0x36BB228
	public void FJDDAIEJOBD(Dictionary<BasePartsData, long> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB238 Offset: 0x36BB238 VA: 0x36BB238
	public bool PADAECPCENB() { }

	// RVA: 0x36BB240 Offset: 0x36BB240 VA: 0x36BB240
	public bool GFMEEGKAIEI() { }

	// RVA: 0x36BB26C Offset: 0x36BB26C VA: 0x36BB26C
	public Dictionary<eActionValue, double> BCNMCGEGOKL() { }

	// RVA: 0x36BB274 Offset: 0x36BB274 VA: 0x36BB274
	public List<BasePartsData> NJEBENEGJOA() { }

	[CompilerGenerated]
	// RVA: 0x36BB27C Offset: 0x36BB27C VA: 0x36BB27C
	public void IENHDKCLLMP(eTargetType param) { }

	// RVA: 0x36BB284 Offset: 0x36BB284 VA: 0x36BB284
	public void MDMDDDEMBLL(bool param) { }

	// RVA: 0x36BB28C Offset: 0x36BB28C VA: 0x36BB28C
	public Dictionary<UnitCtrl, List<int>> HKNDNAPKPMM() { }

	[CompilerGenerated]
	// RVA: 0x36BB294 Offset: 0x36BB294 VA: 0x36BB294
	public Dictionary<BasePartsData, long> ENKCNNIEBFN() { }

	[CompilerGenerated]
	// RVA: 0x36BB29C Offset: 0x36BB29C VA: 0x36BB29C
	public void ADMJIMLNAFH(double param) { }

	[CompilerGenerated]
	// RVA: 0x36BB2A4 Offset: 0x36BB2A4 VA: 0x36BB2A4
	public void BPFKDGIDJFG(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BB2AC Offset: 0x36BB2AC VA: 0x36BB2AC
	public void GIIFGDKBIPA(Dictionary<eStateIconType, List<UnitCtrl>> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB2BC Offset: 0x36BB2BC VA: 0x36BB2BC
	public void LHFFOPALAJG(List<BasePartsData> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB2CC Offset: 0x36BB2CC VA: 0x36BB2CC
	public void JMMEMCLIKGF(NAEFABEPMJF param) { }

	[CompilerGenerated]
	// RVA: 0x36BB2D4 Offset: 0x36BB2D4 VA: 0x36BB2D4
	public void EGNJPHCLMPE(Dictionary<BasePartsData, long> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB2E4 Offset: 0x36BB2E4 VA: 0x36BB2E4
	public bool OHCMDJDNBOJ() { }

	[CompilerGenerated]
	// RVA: 0x36BB2EC Offset: 0x36BB2EC VA: 0x36BB2EC
	public void FJGOPEMDJEF(Dictionary<BasePartsData, long> param) { }

	// RVA: 0x36BB2FC Offset: 0x36BB2FC VA: 0x36BB2FC Slot: 4
	public virtual void SetLevel(int DMGAJDMAJDG) { }

	[CompilerGenerated]
	// RVA: 0x36BB300 Offset: 0x36BB300 VA: 0x36BB300
	public double NCOKHPEKEEB() { }

	// RVA: 0x36BB308 Offset: 0x36BB308 VA: 0x36BB308
	protected IBattleManagerForActionParameter IDOPGINLPBF() { }

	[CompilerGenerated]
	// RVA: 0x36BB354 Offset: 0x36BB354 VA: 0x36BB354
	public AnimationCurve IDKBDPNIMAM() { }

	[CompilerGenerated]
	// RVA: 0x36BB35C Offset: 0x36BB35C VA: 0x36BB35C
	public void JHCOOBFJMCG(eTargetAssignment param) { }

	[CompilerGenerated]
	// RVA: 0x36BB364 Offset: 0x36BB364 VA: 0x36BB364
	public Dictionary<eActionValue, double> MHBGIHHOHBF() { }

	// RVA: 0x36BB36C Offset: 0x36BB36C VA: 0x36BB36C
	public int ICOMPKNCOEC() { }

	// RVA: 0x36BB374 Offset: 0x36BB374 VA: 0x36BB374
	public void APPFDEMDIMI(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BB37C Offset: 0x36BB37C VA: 0x36BB37C
	public Dictionary<UnitCtrl, Dictionary<int, ActionExecedData>> EBKBDJPHHGG() { }

	[CompilerGenerated]
	// RVA: 0x36BB384 Offset: 0x36BB384 VA: 0x36BB384
	public void CLNEKCLAOCM(GameObject param) { }

	// RVA: 0x36BB38C Offset: 0x36BB38C VA: 0x36BB38C
	public void CNPDIPCCIJH(double param) { }

	[CompilerGenerated]
	// RVA: 0x36BB394 Offset: 0x36BB394 VA: 0x36BB394
	public void LKHIIDGJLJF(int param) { }

	// RVA: 0x36BB39C Offset: 0x36BB39C VA: 0x36BB39C
	public int DGOANDNBGED() { }

	[CompilerGenerated]
	// RVA: 0x36BB3A4 Offset: 0x36BB3A4 VA: 0x36BB3A4
	public eTargetAssignment GKBNJDJKMCG() { }

	[CompilerGenerated]
	// RVA: 0x36BB3AC Offset: 0x36BB3AC VA: 0x36BB3AC
	public Dictionary<eActionValue, double> GIJDGNOLGAN() { }

	[CompilerGenerated]
	// RVA: 0x36BB3B4 Offset: 0x36BB3B4 VA: 0x36BB3B4
	public void JPKCBNBPIHO(Dictionary<eActionValue, double> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3C4 Offset: 0x36BB3C4 VA: 0x36BB3C4
	public void PEEECDNEGPI(List<ActionExecTime> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3CC Offset: 0x36BB3CC VA: 0x36BB3CC
	public bool HCJKDPBEAIC() { }

	[CompilerGenerated]
	// RVA: 0x36BB3D4 Offset: 0x36BB3D4 VA: 0x36BB3D4
	public void IFGLCHHHGLN(AnimationCurve param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3DC Offset: 0x36BB3DC VA: 0x36BB3DC
	public void HIOCMHLNNCH(FLJOBLLDDNF param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3E4 Offset: 0x36BB3E4 VA: 0x36BB3E4
	public void HDNHNNDFGCP(Action param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3EC Offset: 0x36BB3EC VA: 0x36BB3EC
	public void BBEJOJGFHDF(int param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3F4 Offset: 0x36BB3F4 VA: 0x36BB3F4
	public void NJDFOEOIODC(ActionParameter.BIOHAHKMJDF param) { }

	[CompilerGenerated]
	// RVA: 0x36BB3FC Offset: 0x36BB3FC VA: 0x36BB3FC
	public bool MGBHJGBOFKE() { }

	[CompilerGenerated]
	// RVA: 0x36BB404 Offset: 0x36BB404 VA: 0x36BB404
	public bool JGAICOJHEAM() { }

	[CompilerGenerated]
	// RVA: 0x36BB40C Offset: 0x36BB40C VA: 0x36BB40C
	public List<ActionExecTime> GLMGKPIMDOL() { }

	[CompilerGenerated]
	// RVA: 0x36BB414 Offset: 0x36BB414 VA: 0x36BB414
	public int BHMNAOPJOOA() { }

	[CompilerGenerated]
	// RVA: 0x36BB41C Offset: 0x36BB41C VA: 0x36BB41C
	public void ODNIAJJFHEJ(int param) { }

	[CompilerGenerated]
	// RVA: 0x36BB424 Offset: 0x36BB424 VA: 0x36BB424
	public bool AGHIGONBEIO() { }

	[CompilerGenerated]
	// RVA: 0x36BB42C Offset: 0x36BB42C VA: 0x36BB42C
	public eEffectType EffectType() { }

	// RVA: 0x36BB434 Offset: 0x36BB434 VA: 0x36BB434
	protected IBattleEffectPool FAKGMMDDEBI() { }

	[CompilerGenerated]
	// RVA: 0x36BB480 Offset: 0x36BB480 VA: 0x36BB480
	public void GLNJOGMJOBE(int param) { }

	[CompilerGenerated]
	// RVA: 0x36BB488 Offset: 0x36BB488 VA: 0x36BB488
	public void CJEPCAOFIOG(int param) { }

	[CompilerGenerated]
	// RVA: 0x36BB490 Offset: 0x36BB490 VA: 0x36BB490
	public void IOIFPIAGKOI(Dictionary<BasePartsData, long> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB498 Offset: 0x36BB498 VA: 0x36BB498
	public bool BKMMFMGGHGA() { }

	// RVA: 0x36BB4A0 Offset: 0x36BB4A0 VA: 0x36BB4A0
	public Dictionary<UnitCtrl, List<int>> PGICKPFJIPN() { }

	// RVA: 0x36BB4A8 Offset: 0x36BB4A8 VA: 0x36BB4A8
	public void FGCLCAEMJNJ(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BB4B0 Offset: 0x36BB4B0 VA: 0x36BB4B0
	public GameObject JBHLJOPELII() { }

	// RVA: 0x36BB4B8 Offset: 0x36BB4B8 VA: 0x36BB4B8
	public Dictionary<BasePartsData, long> KGACEAHGEHO() { }

	[CompilerGenerated]
	// RVA: 0x36BB4C0 Offset: 0x36BB4C0 VA: 0x36BB4C0
	public Dictionary<BasePartsData, long> EHAMIDBPBGP() { }

	// RVA: 0x36BB4C8 Offset: 0x36BB4C8 VA: 0x36BB4C8
	public float FJKODGMJPPN() { }

	// RVA: 0x36BB4D0 Offset: 0x36BB4D0 VA: 0x36BB4D0
	public void DIEBCDDBFEB(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BB4D8 Offset: 0x36BB4D8 VA: 0x36BB4D8
	public Dictionary<BasePartsData, List<CriticalData>> IKJHGJIDIGH() { }

	[CompilerGenerated]
	// RVA: 0x36BB4E0 Offset: 0x36BB4E0 VA: 0x36BB4E0
	public List<UnitCtrl> DLIFPDKIAEB() { }

	// RVA: 0x36BB4E8 Offset: 0x36BB4E8 VA: 0x36BB4E8
	public void FJHMAMINGAP(Dictionary<eActionValue, double> param) { }

	// RVA: 0x36BB4F8 Offset: 0x36BB4F8 VA: 0x36BB4F8
	public void CDDKDFIBCDP(int param) { }

	// RVA: 0x36BB500 Offset: 0x36BB500 VA: 0x36BB500 Slot: 5
	public virtual void EILONGIMJMK(UnitCtrl NIOEPBALBCG) { }

	[CompilerGenerated]
	// RVA: 0x36BB50C Offset: 0x36BB50C VA: 0x36BB50C
	public void NFECFLFLCHI(int param) { }

	// RVA: 0x36BB514 Offset: 0x36BB514 VA: 0x36BB514 Slot: 6
	public virtual void BMNEADLCKPB(UnitCtrl unitCtrl, UnitActionController FGOOFCFHNGI, Skill JEAKGDPMIMJ) { }

	// RVA: 0x36BB7FC Offset: 0x36BB7FC VA: 0x36BB7FC
	public List<NormalSkillEffect> ENNDPKEPKIP() { }

	[CompilerGenerated]
	// RVA: 0x36BB804 Offset: 0x36BB804 VA: 0x36BB804
	public void LBPIMFLEKKL(List<NormalSkillEffect> param) { }

	[CompilerGenerated]
	// RVA: 0x36BB80C Offset: 0x36BB80C VA: 0x36BB80C
	public int KKBNGLCEACI() { }

	[CompilerGenerated]
	// RVA: 0x36BB814 Offset: 0x36BB814 VA: 0x36BB814
	public void KBIMPIDFHKH(float param) { }

	[CompilerGenerated]
	// RVA: 0x36BB81C Offset: 0x36BB81C VA: 0x36BB81C
	public float[] HFONIGFBICI() { }

	[CompilerGenerated]
	// RVA: 0x36BB824 Offset: 0x36BB824 VA: 0x36BB824
	public int NNHKENLKAFM() { }

	// RVA: 0x36BB82C Offset: 0x36BB82C VA: 0x36BB82C Slot: 7
	public virtual void ExecActionOnStart(Skill JEAKGDPMIMJ, UnitCtrl unitCtrl, UnitActionController FGOOFCFHNGI) { }

	[CompilerGenerated]
	// RVA: 0x36BB830 Offset: 0x36BB830 VA: 0x36BB830
	public void FLAOEBPHBMF(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BB838 Offset: 0x36BB838 VA: 0x36BB838
	public bool JDLEOCFIALA() { }

	// RVA: 0x36BB840 Offset: 0x36BB840 VA: 0x36BB840
	public void JIIGBALFEEI(Dictionary<eActionValue, double> param) { }

	// RVA: 0x36BB850 Offset: 0x36BB850 VA: 0x36BB850
	public int MKHOGEHCHHB() { }

	[CompilerGenerated]
	// RVA: 0x36BB858 Offset: 0x36BB858 VA: 0x36BB858
	public int EKFEBAAHJLN() { }

	// RVA: 0x36BB860 Offset: 0x36BB860 VA: 0x36BB860
	public void GGFJJBBOJDF(int param) { }

	// RVA: 0x36BB868 Offset: 0x36BB868 VA: 0x36BB868 Slot: 8
	public virtual void CKIAPLKIKGE(Skill JEAKGDPMIMJ, UnitCtrl unitCtrl, UnitActionController FGOOFCFHNGI) { }

	// RVA: 0x36BB86C Offset: 0x36BB86C VA: 0x36BB86C
	public List<BasePartsData> MPIAAFANDEH() { }

	[CompilerGenerated]
	// RVA: 0x36BB874 Offset: 0x36BB874 VA: 0x36BB874
	public Dictionary<UnitCtrl, List<int>> CBHIALPMKJH() { }

	// RVA: 0x36BB87C Offset: 0x36BB87C VA: 0x36BB87C
	public void AAJEKJHJLGK(float param) { }

	// RVA: 0x36BB884 Offset: 0x36BB884 VA: 0x36BB884 Slot: 9
	public virtual void OPOEDGKNIEA(UnitCtrl NIOEPBALBCG) { }

	[CompilerGenerated]
	// RVA: 0x36BB890 Offset: 0x36BB890 VA: 0x36BB890
	public Dictionary<eStateIconType, List<UnitCtrl>> EEGFCOLKANH() { }

	// RVA: 0x36BB5B4 Offset: 0x36BB5B4 VA: 0x36BB5B4
	public void HLJIIIEKDDM() { }

	// RVA: 0x36BB898 Offset: 0x36BB898 VA: 0x36BB898 Slot: 10
	public virtual void EILONGIMJMK() { }

	[CompilerGenerated]
	// RVA: 0x36BBA10 Offset: 0x36BBA10 VA: 0x36BBA10
	public void BNINFFDLMCG(bool param) { }

	// RVA: 0x36BBA18 Offset: 0x36BBA18 VA: 0x36BBA18
	public void GFAPBEAEEOH(UnitCtrl BEBLHLKLOPK, int FCEMMMPDGCC) { }

	[CompilerGenerated]
	// RVA: 0x36BBABC Offset: 0x36BBABC VA: 0x36BBABC
	public void FBIGLAOIIJG(bool param) { }

	// RVA: 0x36BBAC4 Offset: 0x36BBAC4 VA: 0x36BBAC4
	public int PJKLGFGIPMB() { }

	[CompilerGenerated]
	// RVA: 0x36BBACC Offset: 0x36BBACC VA: 0x36BBACC
	public Dictionary<BasePartsData, long> NNEIMJFLBCG() { }

	[CompilerGenerated]
	// RVA: 0x36BBAD4 Offset: 0x36BBAD4 VA: 0x36BBAD4
	public void LCOGBDPBKHO(int param) { }

	[CompilerGenerated]
	// RVA: 0x36BBADC Offset: 0x36BBADC VA: 0x36BBADC
	public Dictionary<eActionValue, double> DIGNNBOMJBN() { }

	[CompilerGenerated]
	// RVA: 0x36BBAE4 Offset: 0x36BBAE4 VA: 0x36BBAE4
	public void GJECDIJEPGN(PDBLHMLEOHA.FHHCALPOPAK param) { }

	[CompilerGenerated]
	// RVA: 0x36BBAF4 Offset: 0x36BBAF4 VA: 0x36BBAF4
	public bool CDFDIOBFDND() { }

	// RVA: 0x36BBAFC Offset: 0x36BBAFC VA: 0x36BBAFC
	public bool BCHCKJABJKM(UnitCtrl BEBLHLKLOPK) { }

	[CompilerGenerated]
	// RVA: 0x36BBB60 Offset: 0x36BBB60 VA: 0x36BBB60
	public Dictionary<BasePartsData, bool> DOOEAOEJAOG() { }

	// RVA: 0x36BBB68 Offset: 0x36BBB68 VA: 0x36BBB68 Slot: 11
	public virtual void IOJMCFEEMIO() { }

	[CompilerGenerated]
	// RVA: 0x36BBCE0 Offset: 0x36BBCE0 VA: 0x36BBCE0
	public void AFBDNHEBKFL(List<NormalSkillEffect> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBCE8 Offset: 0x36BBCE8 VA: 0x36BBCE8
	public void MACOAIJNCPG(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BBCF0 Offset: 0x36BBCF0 VA: 0x36BBCF0
	public void EGPHCMKIIME(bool param) { }

	// RVA: 0x36BBCF8 Offset: 0x36BBCF8 VA: 0x36BBCF8
	public Dictionary<eActionValue, double> NEKPLNLFIJM() { }

	// RVA: 0x36BBD00 Offset: 0x36BBD00 VA: 0x36BBD00 Slot: 12
	public virtual void DIEEPOHHJHP(UnitCtrl unitCtrl, UnitActionController FGOOFCFHNGI, Skill JEAKGDPMIMJ) { }

	// RVA: 0x36BBDA8 Offset: 0x36BBDA8 VA: 0x36BBDA8
	public void GCBKILMCJDM(AnimationCurve param) { }

	[CompilerGenerated]
	// RVA: 0x36BBDB0 Offset: 0x36BBDB0 VA: 0x36BBDB0
	public void SetActionValue(Dictionary<eActionValue, double> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBDB8 Offset: 0x36BBDB8 VA: 0x36BBDB8
	public void BCCOLCELKDI(Dictionary<UnitCtrl, List<int>> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBDC8 Offset: 0x36BBDC8 VA: 0x36BBDC8
	public AnimationCurve DOAJFJGECFP() { }

	[CompilerGenerated]
	// RVA: 0x36BBDD0 Offset: 0x36BBDD0 VA: 0x36BBDD0
	public void MDOPBIFFFHG(List<BasePartsData> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBDD8 Offset: 0x36BBDD8 VA: 0x36BBDD8
	public void FDDEEEGPMHI(Dictionary<BasePartsData, long> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBDE8 Offset: 0x36BBDE8 VA: 0x36BBDE8
	public int EEKKCKBBBEH() { }

	[CompilerGenerated]
	// RVA: 0x36BBDF0 Offset: 0x36BBDF0 VA: 0x36BBDF0
	public Dictionary<BasePartsData, long> EIFIABLKGJC() { }

	// RVA: 0x36BBDF8 Offset: 0x36BBDF8 VA: 0x36BBDF8
	public bool AIDKJCACNKP(UnitCtrl BEBLHLKLOPK) { }

	[CompilerGenerated]
	// RVA: 0x36BBE5C Offset: 0x36BBE5C VA: 0x36BBE5C
	public void APLBKMHMMHB(float[] param) { }

	[CompilerGenerated]
	// RVA: 0x36BBE64 Offset: 0x36BBE64 VA: 0x36BBE64
	public Dictionary<eActionValue, double> PJJKKGKHAHD() { }

	[CompilerGenerated]
	// RVA: 0x36BBE6C Offset: 0x36BBE6C VA: 0x36BBE6C
	public GDCIMHECIFP OLIPCDOEAID() { }

	[CompilerGenerated]
	// RVA: 0x36BBE74 Offset: 0x36BBE74 VA: 0x36BBE74
	public void OPOHIPJKEPE(float param) { }

	// RVA: 0x36BBE7C Offset: 0x36BBE7C VA: 0x36BBE7C
	public HBLIDNMCGII DFLNNBIBOFH() { }

	[CompilerGenerated]
	// RVA: 0x36BBF9C Offset: 0x36BBF9C VA: 0x36BBF9C
	public List<int> AIBDAGGNOKL() { }

	[CompilerGenerated]
	// RVA: 0x36BBFA4 Offset: 0x36BBFA4 VA: 0x36BBFA4
	public void NIAOMGONCOL(Action param) { }

	// RVA: 0x36BBFAC Offset: 0x36BBFAC VA: 0x36BBFAC
	public ActionParameter.BIOHAHKMJDF LBBIKCEBCNF() { }

	[CompilerGenerated]
	// RVA: 0x36BBFB4 Offset: 0x36BBFB4 VA: 0x36BBFB4
	public void MINOFHFGNEN(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BBFBC Offset: 0x36BBFBC VA: 0x36BBFBC
	public Dictionary<UnitCtrl, double> BPHCJDAMHAC() { }

	[CompilerGenerated]
	// RVA: 0x36BBFC4 Offset: 0x36BBFC4 VA: 0x36BBFC4
	public void FGHDAOIIGCC(List<UnitCtrl> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBFD4 Offset: 0x36BBFD4 VA: 0x36BBFD4
	public int GIDKHAMFAIB() { }

	[CompilerGenerated]
	// RVA: 0x36BBFDC Offset: 0x36BBFDC VA: 0x36BBFDC
	public void OFMMGAPMNHP(Dictionary<UnitCtrl, double> param) { }

	[CompilerGenerated]
	// RVA: 0x36BBFEC Offset: 0x36BBFEC VA: 0x36BBFEC
	public void CKGPDGDCFKD(BasePartsData param) { }

	[CompilerGenerated]
	// RVA: 0x36BBFFC Offset: 0x36BBFFC VA: 0x36BBFFC
	public float PCKFIEJPOHL() { }

	[CompilerGenerated]
	// RVA: 0x36BC004 Offset: 0x36BC004 VA: 0x36BC004
	public void MEJBBPAANHJ(eEffectType param) { }

	[CompilerGenerated]
	// RVA: 0x36BC00C Offset: 0x36BC00C VA: 0x36BC00C
	public List<NormalSkillEffect> EMAEOILBBFL() { }

	// RVA: 0x36BC014 Offset: 0x36BC014 VA: 0x36BC014
	public void GJDCLDMPHKM(ActionParameter.BIOHAHKMJDF param) { }

	[CompilerGenerated]
	// RVA: 0x36BC01C Offset: 0x36BC01C VA: 0x36BC01C
	public List<NormalSkillEffect> KCGAILHCHKK() { }

	[CompilerGenerated]
	// RVA: 0x36BC024 Offset: 0x36BC024 VA: 0x36BC024
	public double JODMFMNDHOL() { }

	[CompilerGenerated]
	// RVA: 0x36BC02C Offset: 0x36BC02C VA: 0x36BC02C
	public void JKBDINNFAHP(Dictionary<BasePartsData, List<CriticalData>> param) { }

	[CompilerGenerated]
	// RVA: 0x36BC03C Offset: 0x36BC03C VA: 0x36BC03C
	public void PDJBBKOIGOB(Dictionary<UnitCtrl, Dictionary<int, ActionExecedData>> param) { }

	[CompilerGenerated]
	// RVA: 0x36BC04C Offset: 0x36BC04C VA: 0x36BC04C
	public void GKLFGLHOMJK(bool param) { }

	[CompilerGenerated]
	// RVA: 0x36BC054 Offset: 0x36BC054 VA: 0x36BC054
	public void MIKMLCOAEAF(Dictionary<eActionValue, double> param) { }

	// RVA: 0x36BC064 Offset: 0x36BC064 VA: 0x36BC064
	public List<NormalSkillEffect> MOFBBPPLNFG() { }

	[CompilerGenerated]
	// RVA: 0x36BC06C Offset: 0x36BC06C VA: 0x36BC06C
	public void MBJMGIGNGHO(int param) { }

	[CompilerGenerated]
	// RVA: 0x36BC074 Offset: 0x36BC074 VA: 0x36BC074
	public ActionParameter.BIOHAHKMJDF GPOEMBDJOCK() { }

	[CompilerGenerated]
	// RVA: 0x36BC07C Offset: 0x36BC07C VA: 0x36BC07C
	public FLJOBLLDDNF HNMFIIAHBAF() { }

	// RVA: 0x36BC084 Offset: 0x36BC084 VA: 0x36BC084 Slot: 13
	public virtual void ExecAction(UnitCtrl unitCtrl, BasePartsData BEBLHLKLOPK, int FCEMMMPDGCC, UnitActionController FGOOFCFHNGI, Skill JEAKGDPMIMJ, float BENNEEONMBO, Dictionary<int, bool> FLOGCBFIMPC, Dictionary<eActionValue, double> DNODKADFNCO)
	{
		
	}
}