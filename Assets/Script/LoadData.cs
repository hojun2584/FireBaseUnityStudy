using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;

public class LoadData : MonoBehaviour , IInteractiveItem
{

    public async void Interactive(GameObject game)
    {
        DataSnapshot snapshot = await MakeJson.instance.LoadData(AuthController.instance.UserId);
        ILoadAble dataCompo = game.GetComponent<ILoadAble>();
        dataCompo.Load(snapshot);

        //Debug.Log(json);

        //data = JsonUtility.FromJson<PlayerData>(json);


        //Dictionary<string, object> dict = new Dictionary<string, object>();

        //foreach (var item in snapshot.Children)
        //{
        //    dict.Add(item.Key,item.Value);
        //}

        
        //foreach(var item in ( Dictionary<string, object>)dict["PlayerData"] )
        //{
            
        //    Debug.Log(item.Key+" value : " + item.Value);

        //}


        


        


    }


}
