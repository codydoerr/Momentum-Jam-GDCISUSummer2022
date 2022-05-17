using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int curScore;
    int totalScore;

    public GameObject staminaAmt;
    public GameObject scoreAmt;

    public LevelSelection lvl;

    public GameObject PopupMenu;

    public GameObject player;

    public GameObject exit;
    private void Awake()
    {
        curScore = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        lvl = GetComponent<LevelSelection>();
        totalScore = Stats.GetScore();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        scoreAmt.GetComponent<TMP_Text>().text = ""+curScore;
        staminaAmt.GetComponent<TMP_Text>().text = "" + player.GetComponent<PlayerBehavior>().curStamina;
    }
    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            PopupMenu.SetActive(true);
        }else if(Time.timeScale == 1)
        {
            PopupMenu.SetActive(false);
        }
    }
    public void AddScore(int reward)
    {
        curScore += reward;
        Debug.Log(curScore);
    }
    public void LoadLevel()
    {
        if(Stats.GetDifficulty() == 0)
        {

        }
        else if (Stats.GetDifficulty() == 1)
        {

        }
        else if (Stats.GetDifficulty() == 2)
        {

        }
    }
    public void LoseGame()
    {
        curScore /= 2;
        Stats.UpdateScore(curScore);
        
        //end game
        //load menu
    }
}
