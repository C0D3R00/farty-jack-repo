using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

public class HomeScreen : MonoBehaviour
{
    public void Play()
    {
        EventManager.Instance.TriggerOnSetNextScene(SceneNames.GAME);

        EventManager.Instance.TriggerOnUpdateState(GameStates.UNLOADING);
        EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(false);
    }

    public void Score()
    {

    }

    public void Rate()
    {

    }
}
