using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;
    public ScoreManager scoreManager;
    private void Awake()
    {
        anim=GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(hit)
        return ;
        float movementSpeed=(speed+scoreManager.player.curSpeed)*Time.deltaTime;
        transform.Translate(movementSpeed,0,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer!=7)
        {
            hit=true;
        if(other.gameObject.layer==9)
        {
            other.gameObject.GetComponent<Animator>().SetBool("isDead",true);
            other.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            if(other.gameObject.GetComponent<Vulture>().isContainsSuperPower)
                {
                    scoreManager.powerUps=scoreManager.powerUps+1;
                    Debug.Log("Power Up");
                    PlayerPrefs.SetFloat("PowerUps",scoreManager.powerUps);
                }
                scoreManager.enemies++;
        }
        boxCollider.enabled=false;
        }
        
    }

    public void setDirection()
    {
        boxCollider=GetComponent<BoxCollider2D>();
        gameObject.SetActive(true);
        hit=false;
        boxCollider.enabled=true;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
