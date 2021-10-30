using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class UserData : BaseSerializeClass<UserData>
{
    [SerializeField] string userName;
    [SerializeField] List<float> clearTimes;


    public UserData()
    {
        Init();
    }

    public void SetUserName(string name)
    {
        userName = name;
    }

    public string GetUserName => userName;

    public void AddTime(float time)
    {
        clearTimes.Add(time);
    }

    public float[] GetAllClearTimesArray => clearTimes.ToArray();

    public List<float> GetAllClearTimesList => clearTimes;

    public float[] GetSortedClearTimesArray(bool revars = false)
    {
        clearTimes.Sort();
        if (!revars) return clearTimes.ToArray();

        clearTimes.Reverse();
        return clearTimes.ToArray();
    }

    public List<float> GetSortedClearTimesList(bool revars = false)
    {
        clearTimes.Sort();
        if (!revars) return clearTimes;

        clearTimes.Reverse();
        return clearTimes;
        
    }

    void Init()
    {
        userName = "";
        clearTimes = new List<float>();
    }
    public new void Save()
    {
        base.Save();
    }

    public new void Load()
    {
        base.Load();
    }

    public override string ToString()
    {
        return fileName;
    }

}
