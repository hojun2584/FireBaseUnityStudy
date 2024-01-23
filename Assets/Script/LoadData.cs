using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour , IInteractiveItem
{

    public void Interactive(GameObject game)
    {
        MakeJson.instance.LoadData(AuthController.instance.UserId);


        Debug.Log("load");
    }


}
