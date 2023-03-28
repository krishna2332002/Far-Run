using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text coinsText;
    public Text starText;
    public Text enemyText;
    public Text powerUpText;
    public float enemies;
    public float powerUps;
    public float distance;
    public float coins;
    public float stars;
    public bool isScoreIncreasing;
    public ResumeMenu resumeMenu;
    public GameObject pauseMenuUi;
    public player player;
    public GameObject PowerUpButton;
    void Start()
    {
        if(PlayerPrefs.HasKey("Stars"))
        stars=PlayerPrefs.GetFloat("Stars");
        if(PlayerPrefs.HasKey("PowerUps"))
        powerUps=PlayerPrefs.GetFloat("PowerUps");
        if(powerUps>0)
        {
            PowerUpButton.SetActive(true);
        }
        else
        {
            PowerUpButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing)
            {
                distance=player.transform.position.x+7;
            }
        scoreText.text= Mathf.Round(distance).ToString();
        coinsText.text= Mathf.Round(coins).ToString();
        starText.text=Mathf.Round(stars).ToString();
        powerUpText.text=Mathf.Round(powerUps).ToString();
        enemyText.text=Mathf.Round(enemies).ToString();
        if(powerUps>0)
        {
            PowerUpButton.SetActive(true);
        }
        else
        {
            PowerUpButton.SetActive(false);
        }
    }
    public void pauseButton()
    {
        resumeMenu.pause();
    }
    public void PowerUpButtonClick()
    {
        if(powerUps>0)
        {
            player.curSpeed*=1.5f;
            powerUps--;
            PlayerPrefs.SetFloat("PowerUps",powerUps);
        }
    }
}
