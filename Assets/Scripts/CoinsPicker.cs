using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPicker : MonoBehaviour
{
    private AudioSource coinPickSound; 
    
    private float coinPoints=15f;
    private ScoreManager ScoreManager;
    void Start()
    {
        coinPickSound= GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        ScoreManager=FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer==7){
            gameObject.SetActive(false);
            if(coinPickSound.isPlaying){
                coinPickSound.Stop();
            }
            if(PlayerPrefs.GetInt("IsMuted")==0)
            coinPickSound.Play();
            ScoreManager.coins++;
        }
    }
}
