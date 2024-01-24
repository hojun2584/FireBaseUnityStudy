using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData
{
    [SerializeField]
    public string name;
    [SerializeField]
    public List<ItemSerial> itemList;
    [SerializeField]
    public Vector3 myPos;

    public PlayerData() 
    {
        itemList = new List<ItemSerial>();
        itemList.Add(new ItemSerial());
        itemList.Add(new ItemSerial());
    }

}


[Serializable]
public class ItemSerial
{
    [SerializeField]
    public string name = "hpPotion";
}

[Serializable]
public class Player : MonoBehaviour , ISaveAble , ILoadAble
{
    [SerializeField]
    PlayerData data = new PlayerData();



    public void Awake()
    {
        data.name = "Warrior";
        data.itemList[1].name = "mpPotion";
        data.myPos = Vector3.zero;
    }

    public void Update()
    {

        Debug.Log(data.myPos);

    }


    public Component GetClass()
    {
        data.myPos = transform.position;
        return this;
    }

    public void Load(DataSnapshot json)
    {

        if (json == null)
            Debug.Log("null");



        foreach (var item in json.Children)
        {
            Debug.Log(item.Key);

            if (item.Key == "PlayerData")
            {
                Debug.Log("fdsfsdf");
                data = JsonUtility.FromJson<PlayerData>(item.GetRawJsonValue());

            }
        }


        //Dictionary<string,object> data = json.Value as Dictionary<string, object>;

        //foreach (var item in data)
        //{
        //    Dictionary<string, object> inData = item.Value as Dictionary<string, object>;

        //    if (inData != null)
        //    {
        //        foreach (var item1 in inData)
        //        {
        //            if (item1.Value is Dictionary<string, object> innerData)
        //            {
        //                string jsonStr = JsonUtility.ToJson(innerData);
        //                Debug.Log(jsonStr);
        //            }
        //            else
        //            {
        //                Debug.Log(item1.Value);
        //            }
        //        }
        //    }
        //}



    }

    public void SetLoad(object name)
    {
        data = (PlayerData)name;
    }
}
