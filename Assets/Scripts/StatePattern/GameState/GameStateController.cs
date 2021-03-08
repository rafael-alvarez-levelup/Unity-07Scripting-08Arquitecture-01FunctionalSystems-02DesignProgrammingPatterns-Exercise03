public class GameStateController : StateController
{
    private IState setupState;
    private IState finishState;

    private void Start()
    {
        SwitchState<GameSetupState>();
    }

    private void Awake()
    {
        setupState = new GameSetupState(this);
        finishState = new GameSetupState(this);

        states.Add(typeof(GameSetupState), setupState);
        states.Add(typeof(GameFinishState), finishState);
    }
}