using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Reflection;
using System.IO;

public class SaveAbleCollector : MonoBehaviour , ISaveAbleCollector
{
    List<object> dataList = new List<object>();
    List<ISaveAble> saveList;

    public void GetSaveAble()
    {
        dataList.Clear();
        saveList = this.gameObject.GetComponents<ISaveAble>().ToList<ISaveAble>();

        foreach (var item in saveList)
        {
            Type itemType = item.GetType();
            
            FieldInfo[] fields = itemType.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute(typeof(SerializeField), false);
                if (attribute != null)
                {
                    // item의 클래스 형태로 filed value 삽입
                    dataList.Add(field.GetValue(item.GetClass()));
                }
            }
        }
    }

    public List<object> GetSaveList()
    {
        return dataList;
    }

}
