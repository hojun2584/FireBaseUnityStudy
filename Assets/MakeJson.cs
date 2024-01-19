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


public class MakeJson : MonoBehaviour
{

    string path;
    SaveData data;
    SaveData data2;

    string saveKeyName = "StudyData";


    public void Awake()
    {
        path = Application.dataPath +"/player.json";
    }

    // Start is called before the first frame update
    void Start()
    {
        data = new SaveData("저");
        data2 = new SaveData("장");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
            Debug.Log("Save");
        }


        
    }


    public void Save()
    {
        string jsonData = null;

        jsonData += JsonUtility.ToJson(data,true);

        string key = Test.instance.reference.Child(saveKeyName).Push().Key;
        Test.instance.reference.Child(saveKeyName).Child(key).SetRawJsonValueAsync(jsonData) ;
    }

    

}
