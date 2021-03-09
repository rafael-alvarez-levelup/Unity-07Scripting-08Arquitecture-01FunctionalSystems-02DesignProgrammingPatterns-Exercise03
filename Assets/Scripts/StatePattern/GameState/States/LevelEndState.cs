public class LevelEndState : State
{
    public LevelEndState(GameStateController controller) : base(controller)
    {

    }

    public override void Enter()
    {
        // If enemy is alive (!null), switch to player turn state
        // Else, switch to level setup state

        // Handle player death

        UnityEngine.Debug.Log($"Enter {typeof(LevelEndState)}");

        // TODO: Remove this test
        int randomNumber = UnityEngine.Random.Range(0, 2);

        if (randomNumber == 0)
        {
            controller.SwitchState<PlayerTurnState>();
        }
        else
        {
            controller.SwitchState<LevelSetupState>();
        }
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(LevelEndState)}");
    }
}