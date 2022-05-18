using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject[] tutorialScenes;
    public GameObject[] easyScenes;
    public GameObject[] mediumScenes;
    public GameObject[] hardScenes;

    public bool levelLoaded;

    public GameObject unloadedLevel;

    public GameObject LoadTutorialScene(int index)
    {
        int currentIndex = index;
        Stats.SetTutorialScene();
        return tutorialScenes[currentIndex];
    }
    public GameObject LoadEasyScene(int index)
    {
        return easyScenes[index];
    }
    public GameObject LoadMediumScene(int index)
    {
        return mediumScenes[index];
    }
    public GameObject LoadHardScene(int index)
    {
        return hardScenes[index];
    }
    public GameObject UnloadLevel()
    {
        levelLoaded = false;
        return unloadedLevel; 
    }
}
