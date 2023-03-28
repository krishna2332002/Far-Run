using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public objectPooler starPooler;
   public void SpawnStars(Vector3 position , float groundWidth)
   {
    // int random=Random.Range(1,100);
    // if(random<95)
    // return ;
    GameObject star = starPooler.GetPooledGameObjects();
    star.transform.position= new Vector3(
        position.x,
        position.y+1f,
        0
      ) ;
      star.SetActive(true);
     
   } 
}
