using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    [SerializeField]
    private GameStates
        _defaultGameState;

    public GameStates State { get; private set; }

    public bool PreviousScreenHidden { get; private set; }

    private void Start()
    {
        State = _defaultGameState;
        PreviousScreenHidden = true;
    }

    private void OnEnable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.OnUpdateState += UpdateState;
            EventManager.OnUpdatePreviousScreenHidden += UpdatePreviousScreenHidden;
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.OnUpdateState -= UpdateState;
            EventManager.OnUpdatePreviousScreenHidden -= UpdatePreviousScreenHidden;
        }
    }

    private void UpdateState(GameStates state)
    {
        State = state;
    }

    private void UpdatePreviousScreenHidden(bool hidden)
    {
        PreviousScreenHidden = hidden;
    }
}
