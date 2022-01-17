using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RankingView : MonoBehaviour
{
    [SerializeField]Text[] rankingTexts;
    string[] rankingString = { "1st", "2nd", "3rd", "4th", "5th", "6th" };
    [SerializeField] string timeFrontText = "ClearTime";
    [SerializeField] string timeFormat = "0:00.00";
    UserDatas userdatas;

    // Start is called before the first frame update
    void Start()
    {
        OnRankingPanel();
    }

    private void OnRankingPanel()
    {
        userdatas = UserDatas.Instans;
        userdatas.Load();

        var creatimes = UserDatas.Instans.GetAllUserData;
        creatimes = creatimes.OrderByDescending(user => user.clearTime).ToList();
        

        //rankingTexts = GetComponentsInChildren<Text>();
        Debug.Log(creatimes.Count);

        for (int i = 0; i < creatimes.Count; i++)
        {
            var time = new TimeSpan(0, 0, (int)creatimes[i].clearTime);
            rankingTexts[i].text = rankingString[i] + " " + timeFrontText + " " + time.ToString(timeFormat);
        }
    }
}
