using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{ 
    // Transition Scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAdditive(string sceneName)
    {
        // Checks if scene is loaded
        if (!(SceneManager.GetSceneByName(sceneName).isLoaded))
        {
            // Adds new scene on top of current scene
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else
        {
            // Unload the scene in the background (game does not stop to wait for it to unload)
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
