// TODO: Could use update to implement a timer

public class LevelSetupState : State
{
    private readonly IIncrementLevel levelIncrementer;

    public LevelSetupState(GameStateController controller, IIncrementLevel levelIncrementer) : base(controller)
    {
        this.levelIncrementer = levelIncrementer;
    }

    public override void Enter()
    {
        // Implement events or behaviours
        // Suscribe to events

        UnityEngine.Debug.Log($"Enter {typeof(LevelSetupState)}");

        levelIncrementer.IncrementLevel();

        // Instantiate new enemy

        controller.SwitchState<PlayerTurnState>();
    }

    public override void Exit()
    {
        // Implement events
        // Unsuscribe from events

        UnityEngine.Debug.Log($"Exit {typeof(LevelSetupState)}");
    }
}