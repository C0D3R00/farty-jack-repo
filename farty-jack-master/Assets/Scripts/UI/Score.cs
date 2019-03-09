using UnityEngine;
using UnityEngine.UI;


using System.Collections;
using System.Collections.Generic;

using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI
        _textMesh;

    private int
        _currentScore = 0;

    private void Start()
    {
        _currentScore = 0;
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = _currentScore.ToString();

        DataManager.SaveIsNewBest(false);
    }

    private void OnEnable()
    {
        if(EventManager.Instance != null)
        {
            EventManager.Instance.StartListening(ActionNames.PASSED_COLUMN.ToString(), AddScore);
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.StopListening(ActionNames.PASSED_COLUMN.ToString(), AddScore);
        }
    }

    private void AddScore()
    {
        _currentScore++;
        _textMesh.text = _currentScore.ToString();

        var bestScore = DataManager.LoadBestScore();

        if (_currentScore > bestScore)
        {
            DataManager.SaveIsNewBest(true);
            DataManager.SaveBestScore(_currentScore);
        }

        DataManager.SaveCurrentScore(_currentScore);
    }
}
