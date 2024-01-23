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



public class SaveData
{

}

[Serializable]
public class Player : MonoBehaviour , ISaveAble
{
    [SerializeField]
    PlayerData data = new PlayerData();
    [SerializeField]
    Vector3 myTrans;



    public void Awake()
    {
        data.name = "Warrior";
        data.itemList[1].name = "mpPotion";
    }

    public Component GetClass()
    {
        return this;
    }


}
