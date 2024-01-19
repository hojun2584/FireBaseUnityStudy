using Firebase.Auth;
using PimDeWitte.UnityMainThreadDispatcher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthController : MonoBehaviour
{

    public TMP_InputField id;
    public TMP_InputField password;
    public FirebaseAuth auth;

    public bool flag;


    public Action LoginFail;
    public void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;

        LoginFail += ()=> { Floating.instance.JustFloating("Login Fail"); };
    }


    public async void Login()
    {
        flag = true;
        
        var temp = auth.SignInWithEmailAndPasswordAsync(id.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted) 
            {
                Debug.Log("Error");
                flag = false;
            }

            AuthResult result = task.Result;
            Debug.LogFormat("Firebase user sign successfully: {0} ({1})", result.User.DisplayName , result.User.UserId) ;
        });


        try
        {
            await temp.ConfigureAwait(false);
            UnityMainThreadDispatcher.Instance().Enqueue( ()=> Floating.instance.JustFloating("Login Success") );
            
        }
        catch
        {
            UnityMainThreadDispatcher.Instance().Enqueue( ()=>LoginFail() );
        }

    }


    public void CreateId()
    {
        
        flag = true;

        
        auth.CreateUserWithEmailAndPasswordAsync(id.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                flag = false;
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                flag = false;
                return;
            }
            // Firebase user has been created.
            Firebase.Auth.AuthResult newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.User.DisplayName, newUser.User.UserId);
        });


    }



}
