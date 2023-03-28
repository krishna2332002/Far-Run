using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenu mainMenu;
    public GameObject quad;
    private ChangeBackGround changeBackGround;
    void Start()
    {
        changeBackGround=quad.GetComponent<ChangeBackGround>();
    }

    public void SecondSelect()
    {
          PlayerPrefs.SetInt("SelectedStage",2);
          mainMenu.nextGame=2;
          changeBackGround.ChangeBackGroundImage();
    }
    public void FifthSelect()
    {
          PlayerPrefs.SetInt("SelectedStage",5);
          mainMenu.nextGame=5;
          changeBackGround.ChangeBackGroundImage();
    }
    public void FourthSelect()
    {
          PlayerPrefs.SetInt("SelectedStage",4);
          mainMenu.nextGame=4;
          changeBackGround.ChangeBackGroundImage();
    }
    public void FirstSelect()
    {
          PlayerPrefs.SetInt("SelectedStage",1);
          mainMenu.nextGame=1;
          changeBackGround.ChangeBackGroundImage();
    }
    public void ThirdSelect()
    {
          PlayerPrefs.SetInt("SelectedStage",3);
          mainMenu.nextGame=3;
          changeBackGround.ChangeBackGroundImage();
    }

}