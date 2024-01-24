using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class SaveData 
{
    public SaveData(string name) 
    {
        this.name = name;
    }

    public string name;
    public string comment = "저장 완료";
}


[Serializable]
public class MonsterData
{
    public String name;
    public int hp;
    public int maxHp;
    public float speed;

}


public class MakeJson : SingleTon<MakeJson>
{

    //SaveData data;
    //SaveData data2;
    //[SerializeField]
    //MonsterData monster;

    //string saveKeyName = "StudyData";




    public async Task<DataSnapshot> LoadData(string keyName)
    {
        DataSnapshot snapShot = null;
        DatabaseManager.instance.SetReference(keyName);

        var check = DatabaseManager.instance.reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                snapShot = task.Result;
            }
        });


        try
        {
            await check.ConfigureAwait(true);
            return snapShot;
        }
        catch
        {
            await check.ConfigureAwait(true);
            return null;
        }
    }

    public void Save(System.Object data , string keyName)
    {
        string jsonData = null;
        jsonData = JsonUtility.ToJson(data, true);
        DatabaseManager.instance.SetRootReference();
        //string key = DatabaseManager.instance.reference.Child(keyName).Push().Key;
        string key = "SaveData";
        DatabaseManager.instance.reference.Child(keyName).Child(key).SetRawJsonValueAsync(jsonData);
    }

    public void Save(List<object> data, string keyName)
    {
        string jsonData = null;

        jsonData = JsonUtility.ToJson(data, true);

        
        DatabaseManager.instance.SetRootReference();
        string key = DatabaseManager.instance.reference.Child(keyName).Push().Key;
        //string key = "SaveData";
        DatabaseManager.instance.reference.Child(keyName).Child(key).SetRawJsonValueAsync(jsonData);
    }

    public void Save(SaveFormat data , string keyName)
    {

        string jsonData = null;

        jsonData = JsonUtility.ToJson(data.data, true);


        Debug.Log(jsonData);

        Debug.Log(data.name);

        DatabaseManager.instance.SetRootReference();
        DatabaseManager.instance.reference.Child(keyName).Child(data.name).SetRawJsonValueAsync(jsonData);

    }

}
