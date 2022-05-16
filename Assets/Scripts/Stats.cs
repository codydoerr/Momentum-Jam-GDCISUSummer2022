using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    private static float momentum = 10;
    private static int stamina = 5;
    private static int difficulty = 1;
    private static int score = 0;

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
        return score;
    }
    public static float UpgradeDifficulty(int change)
    {
        difficulty += change;
        return difficulty;
    }


}
