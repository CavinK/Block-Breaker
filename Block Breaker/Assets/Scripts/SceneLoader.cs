using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() // always be public!
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // index of each scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame(); // reset the score
    }

    public void QuitGame()
    {
        Application.Quit(); // this method is not limited to the button for use!
    }
}
