using UnityEngine;

using System.Collections;

public class HUDScreen : MonoBehaviour
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
           GameManager.Instance.State == GameStates.PLAY)
            ShowHUDScreen();
        else if (_isVisible &&
                 GameManager.Instance.State != GameStates.PLAY)
            HideHUDScreen();
    }

    private void ShowHUDScreen()
    {
        StartCoroutine(ShowHUDScreenCo());
    }

    private void HideHUDScreen()
    {
        StartCoroutine(HideHUDScreenCo());
    }

    private IEnumerator ShowHUDScreenCo()
    {
        _isVisible = true;

        while (!GameManager.Instance.PreviousScreenHidden)
            yield return null;

        _animator.SetBool("IsVisible", true);

        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    }

    private IEnumerator HideHUDScreenCo()
    {
        _isVisible = false;
        _animator.SetBool("IsVisible", false);

        while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("default"))
            yield return null;

        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    }
}
