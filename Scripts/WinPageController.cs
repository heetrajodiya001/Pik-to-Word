using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPageController : MonoBehaviour
{
    public void ReplayLevel()
    {
        // Current scene ne reload kare
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check ke next scene index valid chhe ke nai
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No next level available!");
            // Optional: main menu ya first level ma lai jawu
            // SceneManager.LoadScene(0);
        }
    }
}
