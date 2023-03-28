using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulture : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    public float speed;
    public bool isContainsSuperPower;
    public GameObject superPower;
    public float startingX;
    public float endingX;
    private bool isGoingForward;
    void Start()
    {
        rigidBody= GetComponent<Rigidbody2D>();
        isContainsSuperPower=false;
        isGoingForward=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingForward)
        {
            if(transform.position.x>=endingX-1f)
            {
                 if(isGoingForward)
                transform.Rotate(0f,180f,0f);
                isGoingForward=false;
                rigidBody.velocity=new Vector2(-1*speed,rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity=new Vector2(2*speed,rigidBody.velocity.y);
            }
        }
        else
        {
            if(transform.position.x<=startingX+1f)
            {
                if(!isGoingForward)
                transform.Rotate(0f,180f,0f);
                isGoingForward=true;
                rigidBody.velocity=new Vector2(2*speed,rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity=new Vector2(-1*speed,rigidBody.velocity.y);
            }
        }
        
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public void Gravity()
    {
        rigidBody.gravityScale=1f;
    }
    

}
