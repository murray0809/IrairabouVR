using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class UserDatas : BaseSerializeClass<UserDatas>
{
    [SerializeField] List<UserData> userDatas;

    List<UserData> UserDataList
    {
        get
        {
            if (userDatas == null)
            {
                userDatas = new List<UserData>();
            }
            return userDatas;
        } 
    } 
       
    /*
    public UserDatas()
    {
        Init();
    }
    */

    public void AddUserData(UserData data)
    {
        Instans.UserDataList.Add(data);
        Instans.Save();
    }

    public void RemoveUserData(UserData data)
    {
        UserDataList.Remove(data);
    }

    public List<UserData> GetAllUserData => UserDataList;


    /// <summary>
    /// �ō��L�^��ԋp����
    /// </summary>
    /// <param name="name">���[�U�[��</param>
    /// <returns></returns>
    public UserData GetUserData(string name)
    {
        if (userDatas.Any(data => data.userName == name))
        {
            return userDatas.Where(user => user.userName == name).OrderBy(data => data.clearTime).Take(1) as UserData;
        }
        return new UserData("",0);
    }

    public List<UserData> GetMaxScoreUsers(int limit)
    {
        return userDatas.OrderBy(data => data.clearTime).Take(limit).ToList();
    }

    public List<UserData> GetMaxScoreUsers(string name, int limit)
    {
        return userDatas.Where(data => data.userName == name).OrderBy(sldata => sldata.clearTime).Take(limit).ToList();
    }
    /*
    void Init()
    {
        userDatas = new List<UserData>();
        Load();
    }
    */
    /*
    public new void Save()
    {
        base.Save();
    }

    public new void Load()
    {
        base.Load();
    }
*/
    public override string ToString()
    {
        return fileName;
    }
}

[Serializable]
public class UserData
{
    public string userName;
    public float clearTime;

    public UserData(string name = "",float time = 0)
    {
        userName = name;
        clearTime = time;
    }
}