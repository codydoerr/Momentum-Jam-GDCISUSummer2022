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

    GameObject currentLevel;

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
        if (Time.timeScale == 0 && lvl.levelLoaded)
        {
            PopupMenu.SetActive(true);
            PopupMenu.GetComponent<MenuController>().startText.text = "NEW RUN";
        }
        else if (Time.timeScale == 0 && !lvl.levelLoaded)
        {
            PopupMenu.SetActive(true);
            PopupMenu.GetComponent<MenuController>().startText.text = "START RUN";
        }
        else if(Time.timeScale == 1)
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
        curScore = 0;
        if(Stats.GetDifficulty() == 0)
        {
            lvl.LoadEasyScene(Random.Range(0, lvl.easyScenes.Length - 1));
            lvl.levelLoaded = true;
        }
        else if (Stats.GetDifficulty() == 1)
        {
            lvl.LoadMediumScene(Random.Range(0, lvl.mediumScenes.Length - 1));
            lvl.levelLoaded = true;
        }
        else if (Stats.GetDifficulty() == 2)
        {
            Instantiate(lvl.LoadHardScene(Random.Range(0, lvl.hardScenes.Length - 1)),transform.position,Quaternion.identity);
            lvl.levelLoaded = true;
        }
    }
    public void LoadTutorial()
    {
        Instantiate(lvl.LoadTutorialScene(0),transform.position,Quaternion.identity);
        lvl.levelLoaded = true;
    }
    public void LoseGame()
    {
        curScore /= 2;
        Stats.UpdateScore(curScore);
        curScore = 0;
        Instantiate(lvl.UnloadLevel(),transform.position,Quaternion.identity);
        lvl.levelLoaded = false;
    }
    public void WinGame()
    {
        Stats.UpdateScore(curScore);
        curScore = 0;
        Instantiate(lvl.UnloadLevel(), transform.position, Quaternion.identity);
        lvl.levelLoaded = false;
    }
}
