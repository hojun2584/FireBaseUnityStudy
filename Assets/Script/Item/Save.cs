using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEditor.Progress;


[Serializable]
public struct SaveFormat
{
    [SerializeField]
    public string name;
    [SerializeField]
    public object data;

    public SaveFormat(string name , object data)
    {
        this.name = name;
        this.data = data;
    }

}


public class Save : MonoBehaviour , IInteractiveItem
{
    [SerializeField]
    List<SaveFormat> saveList = new List<SaveFormat>();

    string UserId { get => AuthController.instance.UserId; }

    public void Interactive(GameObject game)
    {

        if (game.TryGetComponent(out ISaveAbleCollector saveItem))
        {

            saveItem.GetSaveAble();
            var data = saveItem.GetSaveList();

            
            foreach (var item in data)
            {
                var saveData = new SaveFormat(item.ToString(), item);
                FireBaseDB.instance.Save(saveData, UserId);
            }


            Debug.Log("Save");
        }   
    }

}
