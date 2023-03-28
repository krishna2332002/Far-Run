using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureEater : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer==7){
        
            gameManager.GameOver();
        }
    }
}
