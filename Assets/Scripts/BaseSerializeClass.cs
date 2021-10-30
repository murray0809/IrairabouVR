using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

abstract public class BaseSerializeClass<T> where T : new() 
{
    string fileName;

    string filePass => $"{Application.persistentDataPath}/{fileName}.json";

    private T instans;

    public T Instans 
    {
        get {
            if (instans == null)
            {
                instans = new T();
                return instans;
            }
            return instans;
        }
        set {
            instans = value;
        }
    }

    void Init(string filename)
    {
        fileName = filename;
    }

    public void Save()
    {
        var json = JsonUtility.ToJson(this);
        using (var writer =  new StreamWriter(filePass,append:false))
        {
            writer.Write(json);
            writer.Flush();
        }
    }

    public void Load()
    {
        using (var reader = new StreamReader(filePass))
        {
            
        }
    }
}
