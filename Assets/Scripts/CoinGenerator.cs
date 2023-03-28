using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
   public objectPooler coinPooler;
   public void SpawnCoins(Vector3 position , float groundWidth)
   {
    int numberOfCoins=(int) Random.Range(3f,groundWidth);
    float y= Random.Range(2.5f,4.5f);
    for(int i=0;i<numberOfCoins;i++)
    {
      
        GameObject coin = coinPooler.GetPooledGameObjects();
      coin.transform.position= new Vector3(
        position.x+i-numberOfCoins/2,
        position.y+y,
        0
      ) ;
      coin.SetActive(true);
    }
     
   } 
}
