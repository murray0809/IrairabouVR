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
        try
        {
            using (var reader = new StreamReader(filePass))
            {
                var json = reader.ReadToEnd();
                _instans = JsonUtility.FromJson<T>(json);
                Debug.Log($"Load:{json}");
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("notfindfile:errormessage:" + e.Message);
        }
    }
}
