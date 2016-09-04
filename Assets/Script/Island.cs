
using System;
using System.Collections;

public class Island  {

    public float Money = 10000;
    public float FackMoney = 0;
    public int Investor = 0;
    public float Doubt=0;
    public DateTime Date = new DateTime(2017, 1, 1);
    public int Trust;

    public int Profit = 0;
    public int GovermentLevel = 0;
    public int AnalystLevel = 0;
    public int RelashionShip = 0;

    public float LastDraw = 0;
    public float LastDeposit = 0;
    public int LasrInvest = 0;


    public void NextMonth()
    {

        LastDraw = Investor * 10000 * 0.03f;
        LastDraw -= LastDraw * ((float)Trust / 100.0f);
        if(Doubt > 100)
        {
            if(LastDraw < (Money + FackMoney) * 0.25f)
            {
                LastDraw = (Money + FackMoney) * 0.25f;
            }
        }

        Money -= LastDraw;

        LasrInvest = 2 + (2 * GovermentLevel) ;
        Investor += LasrInvest;

        LastDeposit = LasrInvest * 10000 + (LasrInvest * 10000 * AnalystLevel) / 100;
        FackMoney += (Money * Profit) / 100;
        Money += LastDeposit - LastDraw;

        Date = Date.AddMonths(1);

        if (Profit == 0)
        {
            Doubt += 5;
            Trust -= 5;
        }
        else if (Profit > 0)
        {
            Doubt += Profit + Profit * GovermentLevel *0.05f;
            Trust += Profit + (int)(Profit * AnalystLevel * 0.05f );

        }
        else if (Profit < 0)
        {
            Doubt += (Profit + (int)(Profit * AnalystLevel * 0.05f)) * 0.7f;

            Trust += Profit + (int)(Profit * AnalystLevel * 0.05f);
        }

        
    }

}
