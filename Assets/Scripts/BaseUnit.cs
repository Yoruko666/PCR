using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BaseUnit
{
    public CampType CampType;
    public SkeletonAnimation spine;

    private GameObject gameObject;

    protected StateMachine stateMachine;

    public float LogicX;
    public int XDir => CampType == CampType.Friend ? 1 : -1;

    private int HP;

    private int MaxHP;

    private int TP;

    private int MaxTP;

    public int AttackRange = 200;

    public BaseUnit(string id, CampType campType)
    {
        GameObject goPrefab = Addressables.LoadAssetAsync<GameObject>(id).WaitForCompletion();
        gameObject = GameObject.Instantiate<GameObject>(goPrefab);
        spine = gameObject.GetComponent<SkeletonAnimation>();
        CampType = campType;

        InitLogicPosition();
        InitTransform();

        stateMachine = new StateMachine(this);
        stateMachine.SetDefaultState(StateType.Run);

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

    public void Move()
    {
        LogicX += 7.5f * XDir;
        SetLogicPosition(LogicX);
    }

    // 战斗场景设置x坐标限定为-15~15
    // 逻辑坐标限定为-1080~1080
    public void SetLogicPosition(float x)
    {
        this.LogicX = x;
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = new Vector3(x * 15 / 1080, position.y, position.z);
    }

    public void InitLogicPosition()
    {
        SetLogicPosition(-1080 * XDir);
    }

    public void InitTransform()
    {
        gameObject.transform.localScale = new Vector3(XDir, 1, 1);
        float offset = Random.Range(-1.5f, 1.5f);
        gameObject.transform.Translate(0, offset, offset);
    }
}

public enum CampType
{
    Friend,  
    Enemy 
}