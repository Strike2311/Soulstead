using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameOverMenu;
    public GameObject player;

    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 0f; // Pause game initially
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f; // Unpause game
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f; // Pause game
        gameOverMenu.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        startMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
