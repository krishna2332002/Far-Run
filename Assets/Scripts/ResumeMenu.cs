using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeMenu : MonoBehaviour
{
   public GameObject pauseMenuUi;
   public AudioSource backgroundSound;
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale=1f;
        backgroundSound.Play();
    }
    public void pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale=0f;
        backgroundSound.Stop();
    }
    public void Menu()
    {
        Debug.Log("Menu");
        Time.timeScale=1f;
        SceneManager.LoadScene("MenuScene");
    }
    public void Quit()
    {
        Time.timeScale=1f;
        Application.Quit();
    }
}
