using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEater : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    public float Damage;
    private Animator animator;

    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer==7){
            other.gameObject.GetComponent<Animator>().SetBool("isHurt",true);
            other.gameObject.GetComponent<Animator>().SetBool("isAttack",false);
            gameManager.player.TakeDamage(Damage);
        }
    }
}

