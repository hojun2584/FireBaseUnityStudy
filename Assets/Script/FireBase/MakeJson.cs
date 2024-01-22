using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


public class MakeJson : MonoBehaviour
{

    //SaveData data;
    //SaveData data2;
    //[SerializeField]
    //MonsterData monster;

    //string saveKeyName = "StudyData";


    //public void Awake()
    //{

    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    data = new SaveData("저");
    //    data2 = new SaveData("장");
    //    monster = new MonsterData();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Save();
    //        Debug.Log("Save");
    //    }

    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        LoadData();
    //        Debug.Log("Load");
    //    }
    //}


    //public void LoadData()
    //{

    //    FirebaseDatabase.DefaultInstance.GetReference(saveKeyName);
    //    DataSnapshot snapShot = null;
    //    FirebaseDatabase db = FirebaseDatabase.DefaultInstance;
    //    DatabaseManager.instance.SetReference("StudyData");

    //    DatabaseManager.instance.reference.GetValueAsync().ContinueWith(task =>
    //    {
    //        if (task.IsCompleted)
    //        {
    //            snapShot = task.Result;
    //        }

    //        foreach (var item in snapShot.Children)
    //        {
    //            IDictionary rank = (IDictionary)item.Value;
    //            foreach (DictionaryEntry item1 in rank)
    //                Debug.Log(item1.Key + " || " + item1.Value);

    //        }


    //    });
    //}

    public void Save(GameObject data , string keyName)
    {
        string jsonData = null;
        jsonData += JsonUtility.ToJson(data, true);
        DatabaseManager.instance.SetRootReference();
        string key = DatabaseManager.instance.reference.Child(keyName).Push().Key;
        DatabaseManager.instance.reference.Child(keyName).Child(key).SetRawJsonValueAsync(jsonData);
    }



}
