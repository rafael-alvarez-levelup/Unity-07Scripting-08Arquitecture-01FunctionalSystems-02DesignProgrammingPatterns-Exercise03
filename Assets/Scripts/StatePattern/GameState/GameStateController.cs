using UnityEngine;
using UnityEngine.UI;

public class GameStateController : StateController
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private ButtonEndController buttonEndController;
    [SerializeField] private Button[] playerButtons;
    [SerializeField] private EnemyActionController[] enemySlots;

    private IState levelSetupState;
    private IState playerTurnState;
    private IState enemyTurnState;
    private IState turnResolutionState;
    private IState levelEndState;

    private void Awake()
    {
        levelSetupState = new LevelSetupState(this, levelManager);
        playerTurnState = new PlayerTurnState(this, buttonEndController, playerButtons);
        enemyTurnState = new EnemyTurnState(this, enemySlots);
        turnResolutionState = new TurnResolutionState(this);
        levelEndState = new LevelEndState(this);

        states.Add(typeof(LevelSetupState), levelSetupState);
        states.Add(typeof(PlayerTurnState), playerTurnState);
        states.Add(typeof(EnemyTurnState), enemyTurnState);
        states.Add(typeof(TurnResolutionState), turnResolutionState);
        states.Add(typeof(LevelEndState), levelEndState);
    }

    private void Start()
    {
        // Initial state
        SwitchState<LevelSetupState>();
    }
}