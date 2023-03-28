using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderGenerator : MonoBehaviour
{
    public objectPooler ladderPooler;
   public void SpawnLadder(Vector3 position , float groundWidth)
   {
    // int random=Random.Range(1,100);
    // if(random<30)
    // return ;
    GameObject ladder = ladderPooler.GetPooledGameObjects();
    ladder.transform.position= new Vector3(
    position.x-1.5f,
    position.y+0.5f,
    0
    ) ;
    ladder.SetActive(true);
   } 
}
