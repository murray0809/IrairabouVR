using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegisterUserData : MonoBehaviour
{
    [SerializeField] InputField userNameInput;
    [SerializeField] Button registerButton;
    TouchScreenKeyboard overlayKeyboard = null;

    // Start is called before the first frame update
    void Start()
    {
        UserDatas.Instans.Load();
        registerButton.onClick.AddListener(() => AddUserData(CreateUserData(userNameInput.text, Timer.CountTime)));
    }

    private void Update()
    {
        if (userNameInput.isFocused)
        {
           overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.ASCIICapable);
        }
    }

    void AddUserData(UserData newUser)
    {
        UserDatas.Instans.AddUserData(newUser);
    }
    
    UserData CreateUserData(string userName = "noname", float clreaTime = 999.999f)
    {
        UserData newData = new UserData();
        newData.userName = userName;
        newData.clearTime = clreaTime;

        return newData;
    }
}
