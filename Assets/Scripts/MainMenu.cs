using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text coinText;
    public Text hiScoreText;
    public Text starText;
    public Text hiScorerText;
    public float coins;
    public float hiScore;
    public float stars;
    public int nextGame=1;
    public int isMuted;
    public string hiScorer;
    public GameObject rewardScreen;
    public GameObject muteButton;
    public GameObject unMuteButton;
    void Start()
    {
        nextGame=PlayerPrefs.GetInt("SelectedStage",1);
        stars=PlayerPrefs.GetFloat("Stars",0);
        hiScore=PlayerPrefs.GetFloat("HiScore",0);
        hiScorer=PlayerPrefs.GetString("HiScorer","Player");
        coins=PlayerPrefs.GetFloat("Coins",0);
        coinText.text= Mathf.Round(coins).ToString();
        hiScoreText.text= Mathf.Round(hiScore).ToString();
        starText.text=Mathf.Round(stars).ToString();
        hiScorerText.text=hiScorer.ToString();
        if(!PlayerPrefs.HasKey("SelectedStage"))
        {
            PlayerPrefs.SetInt("SelectedStage",1);
        }
        if(!PlayerPrefs.HasKey("IsMuted"))
        {
            PlayerPrefs.SetInt("IsMuted",0);
        }
        isMuted=PlayerPrefs.GetInt("IsMuted");
        if(PlayerPrefs.GetInt("IsMuted")==1)
        {
            unMuteButton.SetActive(true);
            muteButton.SetActive(false);
        }
        else
        {
            unMuteButton.SetActive(false);
            muteButton.SetActive(true);
        }
        
    }
    void Update()
    {
        nextGame=PlayerPrefs.GetInt("SelectedStage");
        stars=PlayerPrefs.GetFloat("Stars",0);
        hiScore=PlayerPrefs.GetFloat("HiScore",0);
        coins=PlayerPrefs.GetFloat("Coins",0);
        hiScorer=PlayerPrefs.GetString("HiScorer","Player");
        coinText.text= Mathf.Round(coins).ToString();
        hiScoreText.text= Mathf.Round(hiScore).ToString();
        starText.text=Mathf.Round(stars).ToString();
        hiScorerText.text=hiScorer.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(nextGame);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ShopSelect()
    {
        SceneManager.LoadScene("Shop");
    }
    public void RewardScreenOpen()
    {
        rewardScreen.SetActive(true);
    }
    public void RewardScreenClose()
    {
        rewardScreen.SetActive(false);
    }
    public void MuteButton()
    {
        if(PlayerPrefs.GetInt("IsMuted")==0)
        {
            PlayerPrefs.SetInt("IsMuted",1);
            unMuteButton.SetActive(true);
            muteButton.SetActive(false);
            Debug.Log("Mute");
        }
        else
        {
            PlayerPrefs.SetInt("IsMuted",0);
            unMuteButton.SetActive(false);
            muteButton.SetActive(true);
            Debug.Log("UnMute");
        }
    }
}
