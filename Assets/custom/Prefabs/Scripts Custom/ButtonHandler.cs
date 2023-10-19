using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public enum SceneToLoad
    {
        Intro,
        SpookyForest,
        Opening,
        // Add more scenes here if needed
    }

    public SceneToLoad targetScene;

    public void changeScenes()
    {
        string sceneName = targetScene.ToString();
        SceneManager.LoadScene(sceneName);
    }
}
