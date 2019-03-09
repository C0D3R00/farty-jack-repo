using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    //private Animator
    //    _animator;

    //private bool
    //    _isVisible = false;

    //private void Start()
    //{
    //    _animator = GetComponent<Animator>();

    //    HideLoadingScreen();
    //}

    //private void HideLoadingScreen()
    //{
    //    StartCoroutine(HideLoadingScreenCo());
    //}

    //private IEnumerator HideLoadingScreenCo()
    //{
    //    yield return new WaitForSeconds(.01f);

    //    _isVisible = false;
    //    _animator.SetBool("IsVisible", false);

    //    while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("default"))
    //        yield return null;

    //    EventManager.Instance.TriggerOnUpdateState(GameStates.TUTORIAL);
    //    EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);
    //}

    [SerializeField]
    private GameStates
        _nextState;

    [SerializeField]
    private float
        _timeToFade = .5f;

    private RectTransform
        _rectTransform;

    private Image
        _imageOverlay;

    private SceneNames
        _nextScene;

    private bool
        _isFading = false;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _imageOverlay = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (EventManager.Instance != null)
            EventManager.OnSetNextScene += SetNextScene;
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
            EventManager.OnSetNextScene -= SetNextScene;
    }

    private void Update()
    {
        if (!_isFading &&
            GameManager.Instance.State == GameStates.LOADING)
            StartCoroutine(FadeOutCo());
        else if (!_isFading &&
            GameManager.Instance.State == GameStates.UNLOADING)
            StartCoroutine(FadeInCo());
    }

    private void SetNextScene(SceneNames sceneName)
    {
        _nextScene = sceneName;
    }


    private IEnumerator FadeOutCo()
    {
        _isFading = true;

        var timer = 0f;
        var color = _imageOverlay.color;

        _rectTransform.anchorMin = new Vector2(0f, 0f);
        _rectTransform.anchorMax = new Vector2(1f, 1f);

        while(timer < _timeToFade)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / _timeToFade);

            _imageOverlay.color = color;

            yield return null;
        }

        color.a = 0f;

        _imageOverlay.color = color;
        _rectTransform.anchorMin = new Vector2(0f, 1f);
        _rectTransform.anchorMax = new Vector2(1f, 2f);

        EventManager.Instance.TriggerOnUpdateState(_nextState);
        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(true);

        _isFading = false;
    }

    private IEnumerator FadeInCo()
    {
        _isFading = true;

        var timer = 0f;
        var color = _imageOverlay.color;

        _rectTransform.anchorMin = new Vector2(0f, 0f);
        _rectTransform.anchorMax = new Vector2(1f, 1f);

        while (timer < _timeToFade)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / _timeToFade);

            _imageOverlay.color = color;

            yield return null;
        }

        color.a = 1f;

        _imageOverlay.color = color;

        SceneManager.LoadScene((int)_nextScene);

        _isFading = false;
    }
}
