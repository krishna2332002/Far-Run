using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectGenerator : MonoBehaviour
{
    public objectPooler[] insectPooler;
    private float insectHeight;
    public int noOfInsects;
    private int[] prob={60,70,75,80,90};
    void Start()
    {
         noOfInsects=0;
    }
   public void SpawnInsect(Vector3 position , float groundWidth, float groundHeight)
   {
    if(noOfInsects<5)
    {
        int random = Random.Range(0,100);
        if(random>prob[noOfInsects])
        return;
    }

    int inn = Random.Range(0,insectPooler.Length );
    
    GameObject insect = insectPooler[inn].GetPooledGameObjects();

    insectHeight=insect.GetComponent<BoxCollider2D>().size.y/2-insect.GetComponent<BoxCollider2D>().offset.y;

    float ranX=Random.Range(groundWidth/4,groundWidth/2);

    insect.transform.position= new Vector3(
            position.x-ranX,
            position.y+groundHeight+insectHeight,
            0
        );                                   // Generating Enemey
    insect.GetComponent<BoxCollider2D>().enabled=true;
    int rand = Random.Range(0,100);
    if(rand<=4)
    {
        insect.GetComponent<Vulture>().isContainsSuperPower=true;
        insect.GetComponent<Vulture>().superPower.SetActive(true);
    }
    insect.GetComponent<Vulture>().startingX=position.x-groundWidth/2;
    insect.GetComponent<Vulture>().endingX=position.x+groundWidth/2;
    noOfInsects++;
    insect.SetActive(true);
    
   } 
}
