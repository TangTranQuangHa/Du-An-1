using UnityEngine;

public class ManagerBattle : MonoBehaviour
{
    [SerializeField] private BoxDataBattle boxDataBattle;
    [SerializeField] private ManagerEnemyBattle managerEnemyBattle;
    [SerializeField] private ManagerHeroBattle managerHeroBattle;
    [SerializeField] private ManagerUIBar managerUIBar;
    [SerializeField] private ManagerPosCharacter managerPosCharacter;
    [SerializeField] private RewardUI winPanel;

    [SerializeField] private StartBattle startBattle;
    [SerializeField] private BattleRun battleRun;
    [SerializeField] private BattleEnd battleEnd;
    [SerializeField] private btn_Play btn_Play;

    private void Awake()
    {
        startBattle = GetComponent<StartBattle>();
        battleRun = GetComponent<BattleRun>();
        battleEnd = GetComponent<BattleEnd>();
    }
    private void OnEnable()
    {
        battleRun.IsResult += EndTurnBase;
    }
    private void OnDisable()
    {
        battleRun.IsResult -= EndTurnBase;
    }
    private void Start()
    {
        btn_Play.startBattle += StartTurnBase;
        startBattle.SetBattle(managerEnemyBattle, managerHeroBattle, managerUIBar, managerPosCharacter);
    }

    private void StartTurnBase()
    {
        boxDataBattle = startBattle.SetFight();
        battleRun.RunBattle(boxDataBattle);
        
    }
    private void EndTurnBase(bool result)
    {
        if (result)
            battleEnd.Win(winPanel);
        else
            battleEnd.Lose();
    }
}
