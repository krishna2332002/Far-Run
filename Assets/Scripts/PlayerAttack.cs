using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;

    private Animator anim;
    private player player;
    private float coolDownTimer=Mathf.Infinity;
    public Joystick joystick;
    public AudioSource bulletSound;
    void Awake()
    {
        anim=GetComponent<Animator>();
        player=GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isAttack",false);
        if((joystick.Horizontal>=.001f  || Input.GetKeyDown(KeyCode.Space)) && coolDownTimer >attackCoolDown)
        Attack();
        coolDownTimer+=Time.deltaTime;
    }
    private void Attack()
    {
        if(PlayerPrefs.GetInt("IsMuted")==0)
        bulletSound.Play();
        anim.SetBool("isAttack",true);
        anim.SetBool("isHurt",false);
        coolDownTimer=0;
        bullets[FindBullets()].transform.position=firePoint.position;
        bullets[FindBullets()].GetComponent<BulletProjectile>().setDirection();
    }
    private int FindBullets()
    {
        for(int i=0;i<bullets.Length;i++)
        {
            if(!bullets[i].activeInHierarchy)
            return i;
        }
        return 0;
    }
    public void changeState()
    {
        anim.SetBool("isHurt",false);
    }
}
