// TODO: Do an action and reset it?

public class TurnResolutionState : State
{
    private readonly ICommandProcessor playerProcessor;
    private readonly ICommandProcessor enemyProcessor;
    private readonly IActionSelector playerSelector;
    private readonly IActionSelector enemySelector;

    public TurnResolutionState(IStateController controller, ICommandProcessor playerProcessor,
        ICommandProcessor enemyProcessor, IActionSelector playerSelector,
        IActionSelector enemySelector) : base(controller)
    {
        this.playerProcessor = playerProcessor;
        this.enemyProcessor = enemyProcessor;
        this.playerSelector = playerSelector;
        this.enemySelector = enemySelector;
    }

    public override void Enter()
    {
        // Start command processor coroutine
        // When finished, switch to level end state

        UnityEngine.Debug.Log($"Enter {typeof(TurnResolutionState)}");

        while (playerProcessor.GetCommandQueueCount() != 0 || enemyProcessor.GetCommandQueueCount() != 0)
        {
            enemyProcessor.RunNext();
            playerProcessor.RunNext();
        }

        controller.SwitchState<LevelEndState>();
    }

    public override void Exit()
    {
        enemySelector.ResetActions();
        playerSelector.ResetActions();

        UnityEngine.Debug.Log($"Exit {typeof(TurnResolutionState)}");
    }
}