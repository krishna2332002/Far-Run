using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLadderGenerator : MonoBehaviour
{
     public objectPooler[] extraLadderPooler;
     private StarGenerator starGenerator;
      void Start()
        {
        starGenerator=FindObjectOfType<StarGenerator>();
        }

   public void SpawnLadder(Vector3 position , float groundWidth)
   {
    float random=Random.Range(5f,8f);
    float randd=Random.Range(0f,12f);
    starGenerator=FindObjectOfType<StarGenerator>();
    int rand= Random.Range(0,extraLadderPooler.Length );
    GameObject ladder = extraLadderPooler[rand].GetPooledGameObjects();
    ladder.transform.position= new Vector3(
    position.x+randd,
    position.y+random,
    0
    );
    ladder.SetActive(true);
    starGenerator.SpawnStars(
                ladder.transform.position,
                groundWidth
            );
   } 
}
