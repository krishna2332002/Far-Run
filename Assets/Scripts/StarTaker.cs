using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTaker : MonoBehaviour
{
    private GameManager gameManager;
    private ScoreManager ScoreManager;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        ScoreManager=FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer==7){
            gameObject.SetActive(false);
            ScoreManager.stars+=1;
            PlayerPrefs.SetFloat("Stars",ScoreManager.stars);
        }
    }
}
