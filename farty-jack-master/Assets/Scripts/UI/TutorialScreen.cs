using UnityEngine;

using System.Collections;

public class TutorialScreen : MonoBehaviour
{
    private Animator
        _animator;

    private bool
        _isVisible = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isVisible &&
           GameManager.Instance.State == GameStates.TUTORIAL)
            ShowTutorialScreen();
        else if (_isVisible &&
                 GameManager.Instance.State != GameStates.TUTORIAL)
            HideTutorialScreen();
    }

    private void ShowTutorialScreen()
    {
        StartCoroutine(ShowTutorialScreenCo());
    }

    private void HideTutorialScreen()
    {
        StartCoroutine(HideTutorialScreenCo());
    }

    private IEnumerator ShowTutorialScreenCo()
    {
        _isVisible = true;

        while (!GameManager.Instance.PreviousScreenHidden)
            yield return null;

        _animator.SetBool("IsVisible", true);

        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    }

    private IEnumerator HideTutorialScreenCo()
    {
        _isVisible = false;
        _animator.SetBool("IsVisible", false);

        while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("default"))
            yield return null;

        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    }

    public void Play()
    {
        EventManager.Instance.TriggerEvent(ActionNames.START_GAME.ToString());
        EventManager.Instance.TriggerOnUpdateState(GameStates.PLAY);
        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(false);
    }
}
