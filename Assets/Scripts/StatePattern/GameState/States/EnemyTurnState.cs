using UnityEngine;

public class EnemyTurnState : State
{
    private readonly IActionController[] actionControllers;

    public EnemyTurnState(IStateController controller, IActionController[] actionControllers) : base(controller)
    {
        this.actionControllers = actionControllers;
    }

    public override void Enter()
    {
        // Start enemy selection coroutine
        // Needs a monobehaviour for the coroutine
        // When finished, switch to turn resolution state

        Debug.Log($"Enter {typeof(EnemyTurnState)}");

        RandomizeActions();

        controller.SwitchState<TurnResolutionState>();
    }

    public override void Exit()
    {
        Debug.Log($"Exit {typeof(EnemyTurnState)}");
    }

    private void RandomizeActions()
    {
        foreach (var controller in actionControllers)
        {
            controller.ResetAction();
        }

        foreach (var controller in actionControllers)
        {
            ICommand command = controller.GetCurrentCommand();

            Debug.Log($"Enemy command selected: {command.GetType()}");
        }
    }
}