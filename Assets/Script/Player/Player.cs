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

    public Component GetClass()
    {
        return this;
    }

    public void Load(DataSnapshot json)
    {

        foreach (var item in json.Children)
        {
            if (item.Key == "PlayerData")
            {
                data = JsonUtility.FromJson<PlayerData>(item.GetRawJsonValue());
            }
        }


    }

}
