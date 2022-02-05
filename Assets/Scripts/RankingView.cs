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
    [SerializeField] string defaultText = "";
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
        UserDatas.Instans.Load();

        if (UserDatas.Instans.GetAllUserData.Count == 0) return;
       
        var creatimes = UserDatas.Instans.GetAllUserData;
        creatimes = creatimes.OrderByDescending(user => user.clearTime).ToList();

        creatimes.Reverse();

        //rankingTexts = GetComponentsInChildren<Text>();
        Debug.Log(creatimes.Count);

        for (int i = 0; i < creatimes.Count; i++)
        {
            var floaten = (creatimes[i].clearTime - (int)creatimes[i].clearTime) * 1000;
            Debug.Log(floaten);
            var time = new TimeSpan(0, 0, 0, (int)creatimes[i].clearTime, (int)floaten);
            rankingTexts[i].text = rankingString[i] + ":" + time.ToString(timeFormat);
        }
    }

    public void ClearPanel()
    {
        foreach (var text in rankingTexts)
        {
            text.text = defaultText;
        }
    }
}
