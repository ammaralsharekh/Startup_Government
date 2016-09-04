using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class IslandPrint : MonoBehaviour {
    Island island = new Island();

    [Header("Header")]
    public Text lblMoney ;
    public Text lblFackMoney ;
    public Text lblInvestor ;
    public Text lblDoubt ;
    public Text lblDate;
    public Text lblTrust;

    [Header("Last Month")]
    public Text lblLastDraw ;
    public Text lblLastDeposit ;
    public Text lblLastInvest ;

    [Header("Value")]
    public Text lblProfitVal;
    public Text lblGovermentLevel ;
    public Text lblAnalystLevel ;
    public Text lblRelashionShip ;

    public Text lblGovermentCost;
    public Text lblAnalystCost;
    public Text lblRelashionShipCost;

    [Header("UI")]
    public GameObject GamePlay;
    public GameObject GameEnd;

    [Header("End")]
    public Text lblMoneyEnd;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    lblMoney.text = island.Money.ToString();
        if(island.Money < 0)
        {
            LoseGame();  
        }
	}

    public void LoseGame()
    {
        GamePlay.SetActive(false);
        GameEnd.SetActive(true);
        lblMoneyEnd.text = island.Money.ToString();

        
    }

    public void ResetGame()
    {
        //RefrishUI();
        //GamePlay.SetActive(true);
        //GameEnd.SetActive(false);
        //island = new Island();


        SceneManager.LoadScene("Intro");
    }


    public void NextMonth()
    {
        island.NextMonth();
        RefrishUI();

    }

    private void RefrishUI()
    {
        lblInvestor.text = island.Investor.ToString();

        lblFackMoney.text = island.FackMoney.ToString();
        lblDate.text = island.Date.ToString("MM/yyyy");
        lblTrust.text = island.Trust.ToString();
        lblDoubt.text = island.Doubt.ToString();

        lblLastDraw.text = island.LastDraw.ToString();
        lblLastDeposit.text = island.LastDeposit.ToString();
        lblLastInvest.text = island.LasrInvest.ToString();

        CalcCost(ref lblRelashionShipCost, island.RelashionShip + 1);
        CalcCost(ref lblGovermentCost, island.GovermentLevel + 1);
        CalcCost(ref lblAnalystCost, island.AnalystLevel + 1);

        lblRelashionShip.text = island.RelashionShip.ToString();
        lblProfitVal.text = island.Profit.ToString();
        lblProfitVal.text = island.Profit.ToString();
        lblGovermentLevel.text = island.GovermentLevel.ToString();
        lblRelashionShip.text = island.RelashionShip.ToString();
    }

    public void MoreProfit()
    {
        island.Profit++;
        lblProfitVal.text = island.Profit.ToString();
    }
    public void LessProfit()
    {
        island.Profit--;
        lblProfitVal.text = island.Profit.ToString();
    }

    public void UpgradeGoverment()
    {
        island.GovermentLevel++;
        lblGovermentLevel.text = island.GovermentLevel.ToString();

        int cost = (island.GovermentLevel * 500);
        cost -= cost * island.RelashionShip / 100;
        island.Money -= cost;
        CalcCost(ref lblGovermentCost, island.GovermentLevel + 1);
    }

    public void UpgradeAnalyst()
    {
        island.AnalystLevel++;
        lblAnalystLevel.text = island.AnalystLevel.ToString();

        int cost = (island.AnalystLevel * 500);
        cost -= cost * island.RelashionShip / 100;
        island.Money -= cost;
        CalcCost(ref lblAnalystCost, island.AnalystLevel + 1);
    }

    public void UpgradeRelashionShip()
    {
        island.RelashionShip++;
        lblRelashionShip.text = island.RelashionShip.ToString();

        int cost = (island.RelashionShip * 500);
        cost -= cost * island.RelashionShip / 100;
        island.Money -= cost;
        CalcCost(ref lblRelashionShipCost, island.RelashionShip+1);
        CalcCost(ref lblGovermentCost, island.GovermentLevel + 1);
        CalcCost(ref lblAnalystCost, island.AnalystLevel + 1);
    }

    public void CalcCost(ref Text txt,int nxtlvl )
    {
        int cost = (nxtlvl * 500);
        cost -= cost * island.RelashionShip / 100;

        txt.text = "ﺔﻔﻠﻜﺘﻟﺍ " + cost.ToString();
    }
}
