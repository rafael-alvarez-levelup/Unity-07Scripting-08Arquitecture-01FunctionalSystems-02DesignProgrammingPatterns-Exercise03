using UnityEngine;

public class EnemyTurnState : State
{
    private readonly IActionSelector actionSelector;

    public EnemyTurnState(IStateController controller, IActionSelector actionSelector) : base(controller)
    {
        this.actionSelector = actionSelector;
    }

    public override void Enter()
    {
        // Start enemy selection coroutine
        // Needs a monobehaviour for the coroutine
        // When finished, switch to turn resolution state

        actionSelector.SelectActions();

        Debug.Log($"Enter {typeof(EnemyTurnState)}");

        controller.SwitchState<TurnResolutionState>();
    }

    public override void Exit()
    {
        Debug.Log($"Exit {typeof(EnemyTurnState)}");
    }
}