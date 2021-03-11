﻿using UnityEngine.UI;

public class PlayerTurnState : State, IObserver
{
    private readonly ISubject playerTurnEnder;
    private readonly Button[] playerButtons;

    public PlayerTurnState(IStateController controller, ISubject playerTurnEnder, Button[] playerButtons) : base(controller)
    {
        this.playerTurnEnder = playerTurnEnder;
        this.playerButtons = playerButtons;
    }

    public override void Enter()
    {
        playerTurnEnder.Add(this);

        // TODO: Abstract with interfaces
        foreach (var button in playerButtons)
        {
            button.interactable = true;
        }

        UnityEngine.Debug.Log($"Enter {typeof(PlayerTurnState)}");
    }

    public override void Exit()
    {
        // This change the iterator in the observers list while it is still iterating => use for loop
        playerTurnEnder.Remove(this);

        foreach (var button in playerButtons)
        {
            button.interactable = false;
        }

        UnityEngine.Debug.Log($"Exit {typeof(PlayerTurnState)}");
    }

    public void OnNotify()
    {
        controller.SwitchState<EnemyTurnState>();
    }
}