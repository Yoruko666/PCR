using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager: MonoBehaviour
{
    public static BattleManager Instance;

    public List<string> FriendUnitsId = new();
    public List<string> EnemyUnitsId = new();

    private int tick = 0;
    private float timer = 0;
    private readonly float TICKTIME = 1 / 60f;

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
    }

    private void Update()
    {
        timer += Time.deltaTime;
        while(timer > TICKTIME)
        {
            timer -= TICKTIME;
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
}
