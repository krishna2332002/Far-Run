using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackGround : MonoBehaviour
{
    public Material[] backgrounds;
    public GameObject mainMenu;
    private MeshRenderer meshRender;

    void Start()
    {
        
        meshRender=gameObject.GetComponent<MeshRenderer>();
        meshRender.material=backgrounds[PlayerPrefs.GetInt("SelectedStage",1)-1];
    }

    public void ChangeBackGroundImage()
    {
        meshRender.material=backgrounds[PlayerPrefs.GetInt("SelectedStage",1)-1];
    }
}
