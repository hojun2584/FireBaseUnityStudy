using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IInteractiveItem
{
    public void Interactive( GameObject iteractive);
}


public interface ISaveAble
{
    public Component GetClass();
}

public interface ISaveAbleCollector
{
    public void GetSaveAble();
    public List<object> GetSaveList();


}