using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBySword : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackCoolDown;
    private Animator anim;
    private player player;
    private float coolDownTimer=Mathf.Infinity;
    public ScoreManager scoreManager;
    public Vector3 attackOffest;
    public float attackRange=1.5f;
    public LayerMask attackMask;
    private float offsetY;
    private float offsetX;
    public Joystick joystick;
    public AudioSource WeaponSound;

    void Awake()
    {
        anim=GetComponent<Animator>();
        player=GetComponent<player>();
        offsetY=player.GetComponent<BoxCollider2D>().offset.y;
        offsetX=player.GetComponent<BoxCollider2D>().offset.x;
    }

    // Update is called once per frame
    void Update()
    {
        if((joystick.Horizontal>=.1f  || Input.GetKeyDown(KeyCode.Space)) && coolDownTimer >attackCoolDown)
        Attack();
        coolDownTimer+=Time.deltaTime;
    }
    private void Attack()
    {
        if(PlayerPrefs.GetInt("IsMuted")==0)
        WeaponSound.Play();
        anim.SetBool("isAttack",true);
        anim.SetBool("isHurt",false);
        coolDownTimer=0;
    }
    public void checkIsAttack()
    {
        Vector3 pos=transform.position;
        pos+=transform.right*attackOffest.x;
        pos+=transform.up*attackOffest.y;

        Collider2D colInfo=Physics2D.OverlapCircle(pos,attackRange,attackMask);
        if(colInfo!=null)
        {
            if(colInfo.gameObject.layer==9)
            {
                colInfo.gameObject.GetComponent<Animator>().SetBool("isDead",true);
                colInfo.gameObject.GetComponent<BoxCollider2D>().enabled=false;
                if(colInfo.gameObject.GetComponent<Vulture>().isContainsSuperPower)
                {
                    scoreManager.powerUps++;
                    PlayerPrefs.SetFloat("PowerUps",scoreManager.powerUps);
                }
                scoreManager.enemies++;
            }
        }
        anim.SetBool("isAttack",false);

    }
    public void checkAttack()
    {
        Vector3 pos=transform.position;
        pos+=transform.right*attackOffest.x+transform.up*offsetX;
        pos+=transform.up*attackOffest.y+transform.up*offsetY;

        Collider2D colInfo=Physics2D.OverlapCircle(pos,attackRange,attackMask);
        if(colInfo!=null)
        {
            if(colInfo.gameObject.layer==9)
            {
                colInfo.gameObject.GetComponent<Animator>().SetBool("isDead",true);
                colInfo.gameObject.GetComponent<BoxCollider2D>().enabled=false;
                if(colInfo.gameObject.GetComponent<Vulture>().isContainsSuperPower)
                {
                    scoreManager.powerUps++;
                    PlayerPrefs.SetFloat("PowerUps",scoreManager.powerUps);
                }
                scoreManager.enemies++;
            }
        }
    }
    public void changeState()
    {
        anim.SetBool("isHurt",false);
    }

}
