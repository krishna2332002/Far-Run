using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentPlayerIndex;
    public GameObject[] playerModels;
    public PlayerInfo[] players;
    public TextMeshProUGUI starText;
    public float stars;
    public Button buyButton;

    void Start()
    {
        if(PlayerPrefs.HasKey("Stars"))
        stars=PlayerPrefs.GetFloat("Stars");
        foreach(PlayerInfo player in players)
        {
            if(player.price==0)
            {
                player.isUnLocked=true;
            }
            else
            {
                player.isUnLocked=PlayerPrefs.GetInt(player.name,0)==0?false:true;
            }
        }
        currentPlayerIndex=PlayerPrefs.GetInt("SelectedPlayer",0);
        foreach(GameObject player in playerModels)
        player.SetActive(false);

        playerModels[currentPlayerIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        starText.text=Mathf.Round(stars).ToString();
        UpdateUI();
    }
    public void ChangeNext()
    {
        playerModels[currentPlayerIndex].SetActive(false);
        currentPlayerIndex++;
        if(currentPlayerIndex==playerModels.Length)
        currentPlayerIndex=0;
        playerModels[currentPlayerIndex].SetActive(true);

        PlayerInfo p=players[currentPlayerIndex];
        if(!p.isUnLocked)
        return ;
        PlayerPrefs.SetInt("SelectedPlayer",currentPlayerIndex);
    }
    public void ChangePrevious()
    {
        playerModels[currentPlayerIndex].SetActive(false);
        currentPlayerIndex--;
        if(currentPlayerIndex==-1)
        currentPlayerIndex=playerModels.Length-1;
        playerModels[currentPlayerIndex].SetActive(true);
        PlayerInfo p=players[currentPlayerIndex];
        if(!p.isUnLocked)
        return ;
        PlayerPrefs.SetInt("SelectedPlayer",currentPlayerIndex);
    }
    public void UnlockPlayer()
    {
        PlayerInfo p=players[currentPlayerIndex];
        PlayerPrefs.SetInt(p.name,1);
        PlayerPrefs.SetInt("SelectedPlayer",currentPlayerIndex);
        p.isUnLocked=true;
        stars=stars-p.price;
        PlayerPrefs.SetFloat("Stars",stars);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    private void UpdateUI()
    {
        PlayerInfo p=players[currentPlayerIndex];
        
        if(p.isUnLocked)
        {
             buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text="Buy- "+p.price;
            if(p.price<=stars)
            {
                buyButton.interactable=true;
            }
            else
            {
                buyButton.interactable=false;
            }
        }
    }
}
