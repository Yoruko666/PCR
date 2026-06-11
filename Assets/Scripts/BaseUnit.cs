using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;

public class BaseUnit
{
    public SkeletonAnimation spine;

    public UnitConfig Config;
    public string Id => Config.Id;
    public CampType CampType;
    public int Number;
    public float LogicX;
    public int XDir => CampType == CampType.Friend ? 1 : -1;

    protected StateMachine stateMachine;

    private GameObject gameObject;

    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int TP { get; private set; }
    public int MaxTP { get; private set; }
    public int AttackPower { get; private set; }
    public float AttackRange { get; private set; }
    public readonly float HitRange = 112;

    public BaseUnit(string id, CampType campType)
    {
        Config = ConfigManager.Instance.GetConfig(id);
        if (Config == null)
        {
            Debug.LogError($"[BaseUnit] 找不到角色配置: {id}");
            return;
        }

        gameObject = new GameObject(Config.Name ?? id);
        gameObject.AddComponent<AudioSource>();
        spine = gameObject.AddComponent<SkeletonAnimation>();
        spine.skeletonDataAsset = Addressables.LoadAssetAsync<SkeletonDataAsset>(Config.SpineDataAddr).WaitForCompletion();
        spine.Initialize(true);

        CampType = campType;

        MaxHP = Config.MaxHP;
        HP = Config.MaxHP;
        MaxTP = 1000;
        TP = 0;
        AttackPower = Config.AttackPower;
        AttackRange = Config.AttackRange;

        stateMachine = new StateMachine(this);
        stateMachine.SetDefaultState(StateType.RunGameStart);
    }

    public void Init(int orderNumber)
    {
        Number = orderNumber;
        InitLogicPosition();
        InitTransform();
    }

    public void Tick()
    {
        stateMachine.CheckSwitchState();
        stateMachine.OnTick();
    }

    public void PlayAnim(string animName, bool loop)
    {
        spine.AnimationState.SetAnimation(0, animName, loop);
    }

    public string GetAnimName(string animKey)
    {
        return animKey switch
        {
            "run_game_start"    => Config.AnimRunGameStart,
            "stand_by"          => Config.AnimStandBy,
            "run"               => Config.AnimRun,
            "attack"            => Config.AnimAttack,
            "idle"              => Config.AnimIdle,
            _                   => animKey
        };
    }

    public void Move()
    {
        LogicX += 7.5f * XDir;
        SetLogicPosition(LogicX);
    }

    // 战斗场景设置x坐标限定为-15~15
    // 逻辑坐标总宽为2320
    // 逻辑坐标限定为-1360~960
    public void SetLogicPosition(float x)
    {
        this.LogicX = x;
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = new Vector3((x + 200) * 15 / 1160, position.y, position.z);
    }

    public void InitLogicPosition()
    {
        float spawnX = -(660 + 200 * Number) * XDir - 100;
        SetLogicPosition(spawnX);
    }

    public void InitTransform()
    {
        gameObject.transform.localScale = new Vector3(XDir, 1, 1);
        float offset = Random.Range(-1.5f, 1.5f);
        gameObject.transform.Translate(0, offset, offset);
    }

    public bool Detect()
    {
        List<BaseUnit> targets = BattleManager.Instance.GetOppositeUnits(CampType);
        foreach (BaseUnit enemy in targets)
        {
            float distance = Mathf.Abs(enemy.LogicX - LogicX);
            if (AttackRange >= distance - HitRange / 2) return true;
        }
        return false;
    }
}

public enum CampType
{
    Friend,
    Enemy
}
