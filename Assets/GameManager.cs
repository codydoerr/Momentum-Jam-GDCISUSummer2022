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
    public MenuController mC;

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
        currentLevel = Instantiate(lvl.UnloadLevel(), transform.position, Quaternion.identity);
        lvl.levelLoaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            scoreAmt.GetComponent<TMP_Text>().text = "" + curScore;
            staminaAmt.GetComponent<TMP_Text>().text = "" + player.GetComponent<PlayerBehavior>().curStamina;
        }
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
        Stats.runs++;
        Time.timeScale = 1;
        curScore = 0;
        Destroy(currentLevel);
        if(Stats.GetDifficulty() == 0)
        {
            currentLevel = Instantiate(lvl.LoadEasyScene(Random.Range(0, lvl.easyScenes.Length - 1)),Vector2.zero,Quaternion.identity);
            player = GameObject.Find("Player");
            lvl.levelLoaded = true;
        }
        else if (Stats.GetDifficulty() == 1)
        {
            currentLevel = Instantiate(lvl.LoadMediumScene(Random.Range(0, lvl.mediumScenes.Length - 1)), Vector2.zero, Quaternion.identity);
            player = GameObject.Find("Player");
            lvl.levelLoaded = true;
        }
        else if (Stats.GetDifficulty() == 2)
        {
            currentLevel = Instantiate(lvl.LoadHardScene(Random.Range(0, lvl.hardScenes.Length - 1)), Vector2.zero, Quaternion.identity);
            player = GameObject.Find("Player");
            lvl.levelLoaded = true;
        }
        PauseGame();
    }
    public void LoadTutorial()
    {
        Time.timeScale = 1;
        Destroy(currentLevel);
        Instantiate(lvl.LoadTutorialScene(Stats.GetCurrentTutorialScene()), Vector2.zero, Quaternion.identity);
        lvl.levelLoaded = true;
        PauseGame();
    }
    public void LoseGame()
    {
        Time.timeScale = 0;
        PauseGame();
        curScore /= 2;
        mC.lastRunScore.text = ""+curScore;
        Stats.UpdateScore(curScore);
        curScore = 0;
        Destroy(currentLevel);
        currentLevel = Instantiate(lvl.UnloadLevel(),transform.position,Quaternion.identity);
        lvl.levelLoaded = false;
    }
    public void WinGame()
    {
        Time.timeScale = 0;
        PauseGame();
        Stats.UpdateScore(curScore);
        mC.lastRunScore.text = "" + curScore;
        curScore = 0;
        Destroy(currentLevel);
        currentLevel = Instantiate(lvl.UnloadLevel(), transform.position, Quaternion.identity);
        lvl.levelLoaded = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
