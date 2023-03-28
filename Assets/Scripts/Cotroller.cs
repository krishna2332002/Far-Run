using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotroller : MonoBehaviour
{
    private player player;
    private Vector3 lastPosition;
    private float distance;
    private float distance2;
    void Start()
    {
        player=FindObjectOfType<player>();
        lastPosition=player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance=player.transform.position.x-lastPosition.x;
        transform.position=new Vector3(
            transform.position.x+distance,
            transform.position.y,
            transform.position.z
        );
        lastPosition=player.transform.position;
    }
}
