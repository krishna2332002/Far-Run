using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public player player;
    public ScoreManager scoreManager;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartingPoint;
    private Vector3 groundGenerationStartPoint;

    public groundGenerator groundGenerator;
    public GameObject largeGround;
    public GameObject mediumGround;

    public GameObject gameOverScreen;
     public GameObject highScorerScreen;
 
    public bool isScoreIncreasing;
    private float noOfCoins;
    public InsectGenerator insectGenerator;
    public InputField iField;
    private string LastPlayer;
    void Start()
    {
        playerStartingPoint= player.transform.position;
        groundGenerationStartPoint=groundGenerator.transform.position;
        gameOverScreen.SetActive(false);
        highScorerScreen.SetActive(false);
        LastPlayer=PlayerPrefs.GetString("HiScorer","Player");
    }
    public void GameOver(){
        noOfCoins=PlayerPrefs.GetFloat("Coins",0);
        PlayerPrefs.SetFloat("Coins",noOfCoins+scoreManager.coins);
        if(scoreManager.distance>PlayerPrefs.GetFloat("HiScore",0))
        {
            PlayerPrefs.SetFloat("HiScore",scoreManager.distance);
            highScorerScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(true);
        }
        scoreManager.isScoreIncreasing=false;
        backgroundSound.Stop();
        if(PlayerPrefs.GetInt("IsMuted")==0)
        deathSound.Play();
    }
    public void Quit(){
        SceneManager.LoadScene(0);
    }
    public void Restart(){
        insectGenerator.noOfInsects=0;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SelectedStage",1));
    }
    public void GameOverScreen()
    {
        if(iField.text=="" || iField==null)
        PlayerPrefs.SetString("HiScorer",LastPlayer);
        PlayerPrefs.SetString("HiScorer",iField.text);
        highScorerScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
