using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using System;

public class DailyReward : MonoBehaviour
{
    // Start is called before the first frame update

    public RewardData[] Rewards;
    public TextMeshProUGUI rewardAmount;
    public GameObject starImage;
    public GameObject coinImage;
    public GameObject rewardEndPanel;
    public GameObject rewardPanel;
    private float coins;
    private float stars;
    private int currentReward;
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentReward"))
        {
            PlayerPrefs.SetInt("CurrentReward",0);
        }
        currentReward=PlayerPrefs.GetInt("CurrentReward");
        DateTime a=DateTime.Now;
        DateTime b=DateTime.Parse(PlayerPrefs.GetString("RewardDate"));
        if(string.IsNullOrEmpty(PlayerPrefs.GetString("RewardDate")))
        {
            PlayerPrefs.SetString("RewardDate",DateTime.Now.AddDays(-1).ToString());
        }
        if(a.Date!=b.Date)
        {
            currentReward=0;
            PlayerPrefs.SetInt("CurrentReward",0);
            rewardEndPanel.SetActive(false);
            rewardPanel.SetActive(true);
        }
        if(currentReward==Rewards.Length)
        {
            DeActivateRewards();
        }
        else
        {
            ActivateRewards();
            RewardData reward=Rewards[currentReward];
            rewardAmount.text=Mathf.Round(reward.amount).ToString();
            if(reward.type==RewardData.RewardType.Coins)
            {
                coinImage.SetActive(true);
                starImage.SetActive(false);
            }
            else
            {
                coinImage.SetActive(false);
                starImage.SetActive(true);
            }
        }
            

    }

    private void ActivateRewards()
    {
        rewardEndPanel.SetActive(false);
        rewardPanel.SetActive(true);
    }

    private void DeActivateRewards()
    {
        rewardEndPanel.SetActive(true);
        rewardPanel.SetActive(false);
    }
    private void ChangeReward()
    {
        if(currentReward==Rewards.Length)
        {
            DeActivateRewards();
        }
        else
        {
            ActivateRewards();
            RewardData reward=Rewards[currentReward];
            rewardAmount.text=Mathf.Round(reward.amount).ToString();
            if(reward.type==RewardData.RewardType.Coins)
            {
                coinImage.SetActive(true);
                starImage.SetActive(false);
            }
            else
            {
                coinImage.SetActive(false);
                starImage.SetActive(true);
            }
        }
    }
    public void OnClaim()
    {
        RewardData reward=Rewards[currentReward];
        PlayerPrefs.SetString("RewardDate",DateTime.Now.ToString());
        if(reward.type==RewardData.RewardType.Coins)
        {
            coins=PlayerPrefs.GetFloat("Coins",0);
            PlayerPrefs.SetFloat("Coins",coins+reward.amount);
        }
        else
        {
            stars=PlayerPrefs.GetFloat("Stars",0);
            PlayerPrefs.SetFloat("Stars",stars+reward.amount);
        }
        currentReward++;
        PlayerPrefs.SetInt("CurrentReward",currentReward);
        ChangeReward();
    }
}
