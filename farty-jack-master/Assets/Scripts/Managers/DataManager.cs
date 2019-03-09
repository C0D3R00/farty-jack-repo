using UnityEngine;

using System;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    // SCORE
    public static void SaveCurrentScore(int score)
    {
        PlayerPrefs.SetInt("CURRENT_SCORE", score);
    }

    public static int LoadCurrentScore()
    {
        return PlayerPrefs.GetInt("CURRENT_SCORE", 0);
    }

    // BEST SCORE
    public static void SaveBestScore(int score)
    {
        PlayerPrefs.SetInt("BEST_SCORE", score);
    }

    public static int LoadBestScore()
    {
        return PlayerPrefs.GetInt("BEST_SCORE", 0);
    }

    // NEW BEST
    public static void SaveIsNewBest(bool isNewBest)
    {
        PlayerPrefs.SetInt("NEW_BEST_SCORE", isNewBest ? 1 : 0);
    }

    public static bool LoadIsNewBest()
    {
        return PlayerPrefs.GetInt("NEW_BEST_SCORE", 0) == 0 ? false : true;
    }
}
