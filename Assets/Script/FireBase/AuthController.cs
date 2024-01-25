﻿using Firebase.Auth;
using PimDeWitte.UnityMainThreadDispatcher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AuthController : SingleTon<AuthController>
{

    FirebaseAuth auth;
    public AuthResult authResult;
    public bool isLogin;
    public Action LoginFail;
    public Action LoginSuccess;
    public Action CreateFail;
    public Action CreateSuccess;


    public String UserId
    {
        get 
        {
            if (authResult == null)
                return null;

            return authResult.User.UserId;
        }
    }

    string id;
    string password;

    public new void Awake()
    {
        base.Awake();
        auth = FirebaseAuth.DefaultInstance;
    }

    public void SetLoginData(LoginBox box)
    {
        id = box.idField.text;
        password = box.pWField.text;
    }

    public async void Login()
    {
        isLogin = false;

        var loginResult = auth.SignInWithEmailAndPasswordAsync(id, password).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted) 
            {
                Debug.Log("Error");
            }

            authResult = task.Result;
            Debug.LogFormat("Firebase user sign successfully: {0} ({1})", authResult.User.DisplayName , authResult.User.UserId) ;
        });


        try
        {
            await loginResult.ConfigureAwait(true);
            LoginSuccess();
        }
        catch
        {
            LoginFail();
        }

    }


    public async void CreateId()
    {
        Debug.Log(id +"   " + password);
        var createResult = auth.CreateUserWithEmailAndPasswordAsync(id, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            authResult = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            authResult.User.DisplayName, authResult.User.UserId);

        });


        try
        {
            await createResult.ConfigureAwait(true);
            CreateSuccess();
        }
        catch 
        {
            CreateFail();
        }

    }



}
