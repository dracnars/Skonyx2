using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    if (scene.name == "Menu")
    {
        // Trouver les nouveaux boutons dans la scène Menu
        playButton = GameObject.Find("PlayButton")?.GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton")?.GetComponent<Button>();

        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(PlayGame);
        }

        if (quitButton != null)
        {
            quitButton.onClick.RemoveAllListeners();
            quitButton.onClick.AddListener(QuitGame);
        }
    }
}

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
