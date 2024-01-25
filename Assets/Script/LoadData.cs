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
        DataSnapshot snapshot = await FireBaseDB.instance.LoadData(AuthController.instance.UserId);
        ILoadAble dataCompo = game.GetComponent<ILoadAble>();
        
        if(dataCompo != null)
            dataCompo.Load(snapshot);

    }


}
