using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Scene[] tutorialScenes;
    public Scene[] easyScenes;
    public Scene[] mediumScenes;
    public Scene[] hardScenes;

    public Scene LoadTutorialScene(int index)
    {
        return tutorialScenes[index];
        Stats.SetTutorialScene();
    }
    public Scene LoadEasyScene(int index)
    {
        return easyScenes[index];
    }
    public Scene LoadMediumScene(int index)
    {
        return mediumScenes[index];
    }
    public Scene LoadHardScene(int index)
    {
        return hardScenes[index];
    }
}
