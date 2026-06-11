using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager: MonoBehaviour
{
    public static BattleManager Instance;
    public static float TickTime => 1 / 60f;

    public List<string> FriendUnitsId = new();
    public List<string> EnemyUnitsId = new();

    private int tick = 0;
    private float timer = 0;

    private List<BaseUnit> friendUnits = new();
    private List<BaseUnit> enemyUnits = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < FriendUnitsId.Count; i++)
        {
            friendUnits.Add(new BaseUnit(FriendUnitsId[i], CampType.Friend));
        }
        for (int i = 0; i < EnemyUnitsId.Count; i++)
        {
            enemyUnits.Add(new BaseUnit(EnemyUnitsId[i], CampType.Enemy));
        }

        friendUnits.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));
        enemyUnits.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));

        for (int i = 0; i < friendUnits.Count; i++)
        {
            friendUnits[i].Init(i);
        }
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            enemyUnits[i].Init(i);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        while(timer > TickTime)
        {
            timer -= TickTime;
            tick++;
            Tick();
        }
    }

    private void Tick()
    {
        for(int i = 0;i < friendUnits.Count; i++)
        {
            BaseUnit unit = friendUnits[i];
            unit.Tick();
        }
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            BaseUnit unit = enemyUnits[i];
            unit.Tick();
        }
    }

    public List<BaseUnit> GetOppositeUnits(CampType campType)
    {
        return campType == CampType.Friend ? enemyUnits : friendUnits;
    }

    public List<BaseUnit> GetAllies(CampType campType)
    {
        return campType == CampType.Friend ? friendUnits : enemyUnits;
    }

    /// <summary>暂停除 activeUnit 外的所有单位</summary>
    public void PauseAllExcept(BaseUnit activeUnit)
    {
        foreach (var u in friendUnits)
            if (u != activeUnit) u.IsPaused = true;
        foreach (var u in enemyUnits)
            if (u != activeUnit) u.IsPaused = true;
    }

    /// <summary>恢复所有单位</summary>
    public void ResumeAll()
    {
        foreach (var u in friendUnits) u.IsPaused = false;
        foreach (var u in enemyUnits) u.IsPaused = false;
    }
}
