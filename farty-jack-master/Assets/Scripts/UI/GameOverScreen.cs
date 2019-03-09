using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using TMPro;

// show game over text first
// then summary bg
// then buttons
// then animate score and best

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI
        _currentScore,
        _bestScore;

    [SerializeField]
    private Image
        _medalImage,
        _newImage;

    [SerializeField]
    private List<Sprite>
        _medals;

    [SerializeField]
    private float
        _timeToAnimateScore = 1f;

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
           GameManager.Instance.State == GameStates.GAME_OVER)
            ShowGameOverScreen();
        else if (_isVisible &&
                 GameManager.Instance.State != GameStates.GAME_OVER)
            HideGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        StartCoroutine(ShowGameOverScreenCo());
    }

    private void HideGameOverScreen()
    {
        StartCoroutine(HideGameOverScreenCo());
    }

    private IEnumerator ShowGameOverScreenCo()
    {
        _isVisible = true;

        while (!GameManager.Instance.PreviousScreenHidden)
            yield return null;

        _animator.SetBool("IsVisible", true);

        yield return new WaitForSeconds(1f);

        // animate score and best score
        var timer = 0f;
        var currentScore = DataManager.LoadCurrentScore();
        var bestScore = DataManager.LoadBestScore();

        if (currentScore >= 10 && currentScore < 20)
            _medalImage.sprite = _medals[0];
        else if (currentScore >= 20 && currentScore < 30)
            _medalImage.sprite = _medals[1];
        else if (currentScore >= 30 && currentScore < 40)
            _medalImage.sprite = _medals[2];
        else if (currentScore >= 40)
            _medalImage.sprite = _medals[3];
        
        if(currentScore < 10)
        {
            _medalImage.color = new Color(1f, 1f, 1f, 0f);
            _medalImage.sprite = null;
        }
        else
            _medalImage.color = new Color(1f, 1f, 1f, 1f);

        if (DataManager.LoadIsNewBest())
            _newImage.gameObject.SetActive(true);
        else
            _newImage.gameObject.SetActive(false);

        while (timer < _timeToAnimateScore)
        {
            timer += Time.deltaTime;

            _currentScore.text = ((int)Mathf.Lerp(0, currentScore, timer / _timeToAnimateScore)).ToString();
            _bestScore.text = ((int)Mathf.Lerp(0f, bestScore, timer / _timeToAnimateScore)).ToString();

            yield return null;
        }

        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    }

    private IEnumerator HideGameOverScreenCo()
    {
        _isVisible = false;
        _animator.SetBool("IsVisible", false);

        while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("default"))
            yield return null;

        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    }

    public void Ok()
    {
        // go to home screen
        EventManager.Instance.TriggerOnSetNextScene(SceneNames.HOME);

        EventManager.Instance.TriggerOnUpdateState(GameStates.UNLOADING);
        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(false);
    }
}
