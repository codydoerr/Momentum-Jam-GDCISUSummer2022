using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int curScore;
    int totalScore;

    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = Stats.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int reward)
    {
        curScore += reward;
        Debug.Log(curScore);
    }
    public void loseGame()
    {
        curScore /= 2;
        Stats.UpdateScore(curScore);
        
        //end game
        //load menu
    }
}
