using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

abstract public class BaseSerializeClass<T> where T : new()
{
    protected string fileName => typeof(T).Name;

    protected string filePass => $"{Application.persistentDataPath}/{fileName}.json";

    protected static T _instans;

    public static T Instans
    {
        get
        {
            if (_instans == null)
            {
                _instans = new T();
                return _instans;
            }
            return _instans;
        }
        set
        {
            _instans = value;
        }
    }

    private void NoDataAction()
    {
        _instans = new T();   
    }

    

    public void Save()
    {
        var json = JsonUtility.ToJson(this);
        using (var writer = new StreamWriter(filePass, append: false))
        {
            writer.Write(json);
            writer.Flush();
            Debug.Log("Save:"+ json);
        }
    }

    public void Load()
    {
        var json = "";
        try
        {
            using (var reader = new StreamReader(filePass))
            {
                json = reader.ReadToEnd();
                Debug.Log($"Load:{json}");
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("notfindfile:errormessage:" + e.Message);
        }

        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("Nodata");
            NoDataAction();
            return;
        }

        _instans = JsonUtility.FromJson<T>(json);
    }

    public void ClearAllData()
    {
        var json = "";
        try
        {
            using (var reader = new StreamReader(filePass))
            {
                json = reader.ReadToEnd();
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("notfindfile:errormessage:" + e.Message);
        }

        if (string.IsNullOrEmpty(json))
        {
            Debug.LogWarning("NoData");
            return;
        }


        using (var writer = new StreamWriter(filePass, append: false))
        {
            writer.Write("");
            writer.Flush();
            Debug.Log("Clear");
        }

        _instans = new T();
    }
}
