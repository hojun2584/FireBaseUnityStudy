using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginBox : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField pWField;

    string loginFailstr = "Login Fail";
    string loginSuccess = "Login Success";
    string createFalse = "Sign Fail";
    string createTrue = "Sign Success";




    public void Start()
    {
        AuthController.instance.LoginFail += () => { Floating.instance.JustFloating(loginFailstr); };
        AuthController.instance.LoginSuccess += () => { Floating.instance.JustFloating(loginSuccess); };
        AuthController.instance.CreateFail += () => { Floating.instance.JustFloating(createFalse); };
        AuthController.instance.CreateSuccess += () => { Floating.instance.JustFloating(createTrue); };

        AuthController.instance.loginForm = this;
    }


    public void Login()
    {
        AuthController.instance.SetLoginData(this);
        AuthController.instance.Login();
        SceneController.instance.LoadScene(SceneController.SceneName.MAIN);
    }

    public void CreateId()
    {
        AuthController.instance.SetLoginData(this);
        AuthController.instance.CreateId();
    }


}
