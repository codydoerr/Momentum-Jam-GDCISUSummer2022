using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public int[] momUpCost;
    public int[] stamUpCost;
    public int[] diffUpCost;

    public GameObject upgradeMomentum, momentumAvailable, momentumRestricted;
    public GameObject upgradeStamina, staminaAvailable, staminaRestricted;
    public GameObject upgradeDifficulty, difficultyAvailable, difficultyRestricted;


    public void CheckCost(string upgrade)
    {
        if(upgrade.Equals("Momentum"))
        {
            if (Stats.GetScore() > momUpCost[Stats.currentMomentumUpgrade])
            {
                UpgradeMomAvailable();
            }
            else
            {
                UpgradeMomRestricted();
            }
        }
        else if (upgrade.Equals("Stamina"))
        {
            if (Stats.GetScore() > stamUpCost[Stats.currentStaminaUpgrade])
            {
                UpgradeStamAvailable();
            }
            else
            {
                UpgradeStamRestricted();
            }

        }
        else if (upgrade.Equals("Difficulty"))
        {
            if (Stats.GetScore() > diffUpCost[Stats.currentDifficultyUpgrade])
            {
                UpgradeDiffAvailable();
            }
            else
            {
                UpgradeDiffRestricted();
            }

        }
        //compare current score to cost, if cost is lower, offer upgrade available, else offer upgrade restricted
    }
    public void ClearAllSelections()
    {
        upgradeMomentum.SetActive(true);
        upgradeStamina.SetActive(true);
        upgradeDifficulty.SetActive(true);
        momentumAvailable.SetActive(false);
        momentumRestricted.SetActive(false);
        staminaAvailable.SetActive(false);
        staminaRestricted.SetActive(false);
        difficultyAvailable.SetActive(false);
        difficultyRestricted.SetActive(false);
    }
    public void UpgradeMomAvailable()
    {
        momentumAvailable.SetActive(true);
        upgradeMomentum.SetActive(false);

        upgradeStamina.SetActive(true);
        upgradeDifficulty.SetActive(true);
        staminaAvailable.SetActive(false);
        staminaRestricted.SetActive(false);
        difficultyAvailable.SetActive(false);
        difficultyRestricted.SetActive(false);
    }
    public void BuyMomUpgrade()
    {
        Stats.UpgradeMomentum(5);
        Stats.UpdateScore(-1 * momUpCost[Stats.currentMomentumUpgrade]);
        Stats.currentMomentumUpgrade++;
    }
    public void UpgradeMomRestricted()
    {
        momentumRestricted.SetActive(true);
        upgradeMomentum.SetActive(false);

        upgradeStamina.SetActive(true);
        upgradeDifficulty.SetActive(true);
        staminaAvailable.SetActive(false);
        staminaRestricted.SetActive(false);
        difficultyAvailable.SetActive(false);
        difficultyRestricted.SetActive(false);
    }
    public void UpgradeStamAvailable()
    {
        staminaAvailable.SetActive(true);
        upgradeStamina.SetActive(false);

        upgradeMomentum.SetActive(true);
        upgradeDifficulty.SetActive(true);
        momentumAvailable.SetActive(false);
        momentumRestricted.SetActive(false);
        difficultyAvailable.SetActive(false);
        difficultyRestricted.SetActive(false);
    }
    public void BuyStamUpgrade()
    {
        Stats.UpgradeStamina(1);
        Stats.UpdateScore(-1 * stamUpCost[Stats.currentStaminaUpgrade]);
        Stats.currentStaminaUpgrade++;
    }
    public void UpgradeStamRestricted()
    {
        staminaRestricted.SetActive(true);
        upgradeStamina.SetActive(false);

        upgradeMomentum.SetActive(true);
        upgradeDifficulty.SetActive(true); 
        momentumAvailable.SetActive(false);
        momentumRestricted.SetActive(false);
        difficultyAvailable.SetActive(false);
        difficultyRestricted.SetActive(false);
    }
    public void UpgradeDiffAvailable()
    {
        difficultyAvailable.SetActive(true);
        upgradeDifficulty.SetActive(false);

        upgradeMomentum.SetActive(true);
        upgradeStamina.SetActive(true);
        momentumAvailable.SetActive(false);
        momentumRestricted.SetActive(false);
        staminaAvailable.SetActive(false);
        staminaRestricted.SetActive(false);
    }
    public void BuyDiffUpgrade()
    {
        Stats.UpgradeDifficulty(1);
        Stats.UpdateScore(-1 * diffUpCost[Stats.currentDifficultyUpgrade]);
        Stats.currentDifficultyUpgrade++;
    }
    public void UpgradeDiffRestricted()
    {
        difficultyRestricted.SetActive(true);
        upgradeDifficulty.SetActive(false);

        upgradeMomentum.SetActive(true);
        upgradeStamina.SetActive(true);
        momentumAvailable.SetActive(false);
        momentumRestricted.SetActive(false);
        staminaAvailable.SetActive(false);
        staminaRestricted.SetActive(false);
    }



}
