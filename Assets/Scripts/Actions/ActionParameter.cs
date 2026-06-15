using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActionParameter : ISingletonField
{
    public eActionType ActionType;
    public delegate void ActionDelegate();
    public Dictionary<int, GameObject> CKJKJIOBLJE; 
    public bool JAGJDFNJLDC;
    public bool OGCEDJEHPAI; 
    public double OANMFHPOLBE; 
    protected List<SkillEffectCtrl> EHOJGACKMLC;
    public eTargetAssignment TargetAssignment { get; set; }
    public eTargetType TargetType { get; set; }
    public eAttackSide AttackSide { get; set; }
    public Dictionary<eActionValue, double> IDGLGOLAOMA { get; set; }
    public float[] JIKJHCPJLNL { get; set; }
    public List<ActionExecTime> HFIPPOPIOOF { get; set; }
    public List<int> PPDFODNDELJ { get; set; }
    public Action BADPIBIANHG { get; set; }
    public bool GNMDPAJPKPF { get; set; }
    public List<NormalSkillEffect> DNCAGPBJAMD { get; set; }
    public List<NormalSkillEffect> CCGGIAFIBMP { get; set; }
    public eAbnormalStateType AbnormalState { get; set; }
    public Dictionary<UnitCtrl, Dictionary<int, ActionExecedData>> KHAEBLCNBAC { get; set; }
    public Dictionary<UnitCtrl, List<int>> ENEPHEJAFLL { get; set; }
    public Dictionary<eStateIconType, List<UnitCtrl>> JLKBFNKGOKF { get; set; }
    public Dictionary<eActionValue, double> MPBNILHHAJL { get; set; }
    public Dictionary<eActionValue, double> EAMOEGLCMIE { get; set; }
    public eEffectType EBPCDCMINIH { get; set; }
    public List<UnitCtrl> EIKPEIBCFFM { get; set; }

    public ActionParameter() { }

    public virtual void SetLevel(int DMGAJDMAJDG) { }

    public virtual void ExecAction(UnitCtrl unitCtrl, int FCEMMMPDGCC, UnitActionController FGOOFCFHNGI, Skill JEAKGDPMIMJ, float BENNEEONMBO, Dictionary<int, bool> FLOGCBFIMPC, Dictionary<eActionValue, double> DNODKADFNCO)
    {
    }
}