using UnityEngine;

public class InputState : MonoBehaviour
{
    public InputTypes CurrentState { get; private set; }

    private void Update()
    {
        CurrentState = InputTypes.NONE;

        if ((GameManager.Instance.State == GameStates.TUTORIAL ||
            GameManager.Instance.State == GameStates.PLAY) &&            
            Input.GetMouseButtonDown(0))
            CurrentState = InputTypes.TAP;
    }
}
