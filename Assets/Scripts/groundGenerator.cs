using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;
    private float lastY;
    public objectPooler[] groundPoolers;
    private float[] groundWidths;
    private float[] groundHeights;
    private CoinGenerator coinGenerator;
    private InsectGenerator insectGenerator;
    private LadderGenerator ladderGenerator;
    private ExtraLadderGenerator extraLadderGenerator;
    private VultureGeneration vultureGenerator;
    private StarGenerator starGenerator;
    void Start()
    {
        minY=minHeightPoint.position.y;
        maxY=maxHeightPoint.position.y;
        groundWidths= new float[groundPoolers.Length];
        groundHeights=new float[groundPoolers.Length];
        coinGenerator= FindObjectOfType<CoinGenerator>();
        insectGenerator= FindObjectOfType<InsectGenerator>();
        ladderGenerator= FindObjectOfType<LadderGenerator>();
        extraLadderGenerator= FindObjectOfType<ExtraLadderGenerator>();
        vultureGenerator= FindObjectOfType<VultureGeneration>();
        starGenerator=FindObjectOfType<StarGenerator>();
        for(int i=0;i<groundPoolers.Length;i++ )
        {
            groundWidths[i]=groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
            groundHeights[i]=groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.y;
        }
        lastY=0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<groundPoint.position.x){

            int random= Random.Range(0,groundPoolers.Length );  // Choose Ground type

            float distance=groundWidths[random]/2;  // Half Width of random ground

            float gap= Random.Range(minGap,maxGap);  // Gap between two grounds

            float height= Random.Range(minY,maxY);  // Height of new ground

            transform.position=new Vector3( 
                transform.position.x+distance+gap,
                height,
                transform.position.z
            );                                      //  Set the ground at specific position

            GameObject ground = groundPoolers[random].GetPooledGameObjects();    
            ground.transform.position=transform.position;
            ground.SetActive(true);
            
            if(gap>=(2*maxGap)/3)
            {
                ladderGenerator.SpawnLadder(
                    new Vector3(
                        transform.position.x-groundWidths[random]/2,
                        (transform.position.y+lastY)/2,
                        transform.position.z
                    ),
                    groundWidths[random]
                );
            }                                    // Generating ladders if gap is large


            float isStar=Random.Range(1,1000);

            if(isStar<=80)
            {
                extraLadderGenerator.SpawnLadder(
                    new Vector3(
                        transform.position.x-groundWidths[random]/2,
                        (transform.position.y+lastY)/2,
                        transform.position.z
                    ),
                    groundWidths[random]
                );
            }                                     //  Generating Extra ladders for starts

            float isCoin= Random.Range(1,100);

            if(isCoin>60)
            {
                coinGenerator.SpawnCoins(
                    transform.position,
                    groundWidths[random]
                );
            }                                   // Generating coins
            else
            {
                if(random!=0)
                {
                    float isInsect= Random.Range(1,100);
                    if(isInsect>20)
                    {
                        insectGenerator.SpawnInsect(
                            transform.position,
                            groundWidths[random],
                            groundHeights[random]/2
                        );
                    }                            // Genrating Insects
                    else if(isInsect<35)
                    {
                        vultureGenerator.SpawnVulture(
                            transform.position,
                            groundWidths[random]
                        );
                    }                             // Generating Vultures
                }
            }
            
             transform.position=new Vector3(
                transform.position.x+distance,
                transform.position.y,
                transform.position.z
            );
             lastY=height;
        }
    }
}
