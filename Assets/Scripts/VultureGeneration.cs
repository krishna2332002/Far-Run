using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureGeneration : MonoBehaviour
{
     public objectPooler vulturePooler;
   public void SpawnVulture(Vector3 position , float groundWidth)
   {
    int random= Random.Range(4,10);
    GameObject vulture = vulturePooler.GetPooledGameObjects();
    vulture.transform.position= new Vector3(
    position.x-1+groundWidth/2-random/2,
    position.y+random,
    0
    ) ;
    vulture.SetActive(true);
   } 
}
