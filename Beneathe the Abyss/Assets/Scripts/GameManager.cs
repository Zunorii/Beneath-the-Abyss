using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool paused;

    public GameObject PausedText;
    public GameObject QuitButton;
    public GameObject RestartButton;
    public GameObject ResumeButton;
    public GameObject MainMenuButton;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
            {
                paused = true;
                Time.timeScale = 0;

                PausedText.SetActive(true);
                QuitButton.SetActive(true);
                RestartButton.SetActive(true);
                ResumeButton.SetActive(true);
                MainMenuButton.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && paused)
            {
                paused = false;
                Time.timeScale = 1;

                PausedText.SetActive(false);
                QuitButton.SetActive(false);
                RestartButton.SetActive(false);
                ResumeButton.SetActive(false);
                MainMenuButton.SetActive(false);
            }
        }
    }
    public IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Unpause()
    {
        paused = false;
        Time.timeScale = 1;
        PausedText.SetActive(false);
        QuitButton.SetActive(false);
        RestartButton.SetActive(false);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);
    }
}
