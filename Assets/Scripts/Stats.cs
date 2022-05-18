using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{

    public static int currentMomentumUpgrade, currentStaminaUpgrade, currentDifficultyUpgrade;
    public static int runs;
    private static float momentum = 10f;
    private static int stamina = 5;
    private static int difficulty = 0;
    private static int score = 0;
    private static int currentTutorialScene = 0;

    public static int GetCurrentTutorialScene()
    {
        return currentTutorialScene;
    }
    public static void SetTutorialScene()
    {
        currentTutorialScene++;
        if (currentTutorialScene > 4)
        {
            currentTutorialScene = 0;
        }
    }
    public static float GetMomentum()
    {
        return momentum;
    }
    public static int GetStamina()
    {
        return stamina;
    }
    public static int GetScore()
    {
        return score;
    }
    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static float UpgradeMomentum(float change)
    {
        momentum += change;
        return momentum;
    }
    public static int UpgradeStamina(int change)
    {
        stamina += change;
        return stamina;
    }
    public static int UpdateScore(int change)
    {

        score += change;
        if (score < 0)
        {
            score = 0;
        }
        return score;
    }
    public static float UpgradeDifficulty(int change)
    {
        difficulty += change;
        return difficulty;
    }
}
