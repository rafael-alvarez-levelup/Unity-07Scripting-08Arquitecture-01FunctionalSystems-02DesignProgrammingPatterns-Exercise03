// TODO: Reset the actions here, now the player actions are being reset in PlayerActionController
// Do an action and reset it?

public class TurnResolutionState : State
{
    public TurnResolutionState(IStateController controller) : base(controller)
    {

    }

    public override void Enter()
    {
        // Start command processor coroutine
        // When finished, switch to level end state

        UnityEngine.Debug.Log($"Enter {typeof(TurnResolutionState)}");

        UnityEngine.Debug.Log($"Processing commands...");

        controller.SwitchState<LevelEndState>();
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(TurnResolutionState)}");
    }
}