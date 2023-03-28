using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] players;
    public GameManager gameManager;
    public ScoreManager ScoreManager;
    public GameObject joystick;
    public HealthBar healthBar;
    void Start()
    {
        currentPlayerIndex=PlayerPrefs.GetInt("SelectedPlayer",0);
        foreach(GameObject player in players)
        player.SetActive(false);
        players[currentPlayerIndex].SetActive(true);
        
        gameManager.player=players[currentPlayerIndex].gameObject.GetComponent<player>();
        ScoreManager.player=players[currentPlayerIndex].gameObject.GetComponent<player>();
        healthBar.SetMaxHealth((int)gameManager.player.Life);
        Debug.Log("Hekllo"+gameManager.player.Life);
        if(currentPlayerIndex== 0)
        {
            joystick.SetActive(false);
        }
        else
        {
            joystick.SetActive(true);
        }
    }
}
