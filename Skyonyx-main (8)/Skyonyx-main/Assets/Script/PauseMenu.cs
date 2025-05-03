using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string menuSceneName = "Menu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
