using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using UnityEngine;


public class FireBaseDB : SingleTon<FireBaseDB>
{

    public async Task<DataSnapshot> LoadData(string keyName)
    {
        DataSnapshot snapShot = null;
        DatabaseManager.instance.GetReference(keyName);

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
            return null;
        }
    }

    //public void Save(System.Object data , string keyName)
    //{
    //    string jsonData = null;
    //    jsonData = JsonUtility.ToJson(data, true);
    //    DatabaseManager.instance.SetRootReference();
    //    //string key = DatabaseManager.instance.reference.Child(keyName).Push().Key;
    //    string key = "SaveData";
    //    DatabaseManager.instance.reference.Child(keyName).Child(key).SetRawJsonValueAsync(jsonData);
    //}

    //public void Save(List<object> data, string keyName)
    //{
    //    string jsonData = null;

    //    jsonData = JsonUtility.ToJson(data, true);

        
    //    DatabaseManager.instance.SetRootReference();
    //    string key = DatabaseManager.instance.reference.Child(keyName).Push().Key;
    //    //string key = "SaveData";
    //    DatabaseManager.instance.reference.Child(keyName).Child(key).SetRawJsonValueAsync(jsonData);
    //}

    public void Save(SaveFormat data , string keyName)
    {
        string jsonData = JsonUtility.ToJson(data.data, true);
        DatabaseManager.instance.SetRootReference();
        DatabaseManager.instance.reference.Child(keyName).Child(data.name).SetRawJsonValueAsync(jsonData);
    }

}
