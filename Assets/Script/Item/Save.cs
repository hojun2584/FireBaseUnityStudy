using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Save : MonoBehaviour , IInteractiveItem
{

    public void Interactive(GameObject game)
    {
        
        if(game.TryGetComponent(out ISaveAbleCollector saveItem))
        {
            saveItem.GetSaveAble();

            var data = saveItem.GetSaveList();

            foreach (var item in data)
            {
                MakeJson.instance.Save(item , AuthController.instance.UserId);
            }
        }


        Debug.Log("Save");
    }

}
