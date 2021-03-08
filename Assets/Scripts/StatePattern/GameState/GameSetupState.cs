public class GameSetupState : State
{
    public GameSetupState(GameStateController controller) : base(controller)
    {
        // Inject necessary behaviours.
    }

    public override void Enter()
    {
        // Implement events or behaviours.
        // Suscribe to events.
    }

    public override void Update()
    {
        // Implement checks and transitions.
        controller.SwitchState<GameFinishState>(); // Example
    }

    public override void Exit()
    {
        // Implement events.
        // Unsuscribe from events.
    }
}