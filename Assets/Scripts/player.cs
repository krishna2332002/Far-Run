using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    public float jump;
    public float speed;
    public float curSpeed;
    public float Life;
    public float remainLife;
    public LayerMask ground;
    private Collider2D playerCollider;
    public AudioSource deathSound;
    public AudioSource jumpSound;
    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;
    public LayerMask deathGrond;
    public GameManager gameManager;
    private Animator animator;
    private bool isJumping;
    private float gravity;
    private float distToGround;
    public HealthBar healthBar;
    void Start()
    {
        curSpeed=speed;
        remainLife=Life;
        rigidBody=GetComponent<Rigidbody2D>();
        playerCollider= GetComponent<Collider2D>();
        mileStoneCount=mileStone;
        animator=GetComponent<Animator>();
        isJumping=false;
        gravity=rigidBody.gravityScale;
        distToGround=gameObject.GetComponent<BoxCollider2D>().size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead= Physics2D.IsTouchingLayers(playerCollider,deathGrond);
        if(isDead){
            Deactivate();
        }
        if(transform.position.x>mileStoneCount)
        {
            mileStoneCount+=mileStone;
            mileStone+=mileStone*speedMultiplier;
            curSpeed=curSpeed*speedMultiplier;
            Debug.Log(curSpeed);
        }
        rigidBody.velocity=new Vector2(curSpeed,rigidBody.velocity.y);
        TakeDamage(0.01f*Time.timeScale);
        // Debug.Log(remainLife);
        // bool grounded= Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
        bool grounded= Physics2D.IsTouchingLayers(playerCollider,ground) ;

        if(grounded)
        {
            isJumping=false;
            rigidBody.gravityScale=gravity;
        }
        if(SwipeManager.swipeDown)
        {
            rigidBody.gravityScale=10f;
        }

        if(SwipeManager.swipeUp)
        {
            if(grounded)
            {
                if(PlayerPrefs.GetInt("IsMuted")==0)
                jumpSound.Play();
                rigidBody.velocity= new Vector2(rigidBody.velocity.x,jump);
                isJumping=true;
                animator.SetBool("isHurt",false);
            }
        }
        animator.SetBool("Grounded",grounded);
       
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }

    public void isDeadFun()
    {
        animator.SetBool("Grounded",true);
        animator.SetBool("isAttack",false);
        animator.SetBool("isHurt",false);
        animator.SetBool("isDead",true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        GameOver();
    }

    public void TakeDamage(float damage)
    {
        remainLife-=damage;
        healthBar.SetHealth((int)remainLife);
        if(remainLife<=0)
        {
            isDeadFun();
        }
    }
     public void changeState()
    {
        animator.SetBool("isHurt",false);
    }
}
