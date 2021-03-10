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
            UnityEngine.Debug.Log("Enemy is still alive. Player turn");

            controller.SwitchState<PlayerTurnState>();
        }
        else
        {
            UnityEngine.Debug.Log("Enemy dead. Next level");

            controller.SwitchState<LevelSetupState>();
        }
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(LevelEndState)}");
    }
}