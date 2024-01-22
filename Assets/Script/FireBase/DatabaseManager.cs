using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System.IO;
using UnityEngine.Rendering;


public class DatabaseManager : MonoBehaviour
{

    public static DatabaseManager instance;
    public DatabaseReference reference;
    public string savePath;
    FirebaseDatabase database;

    protected void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this.gameObject);


        savePath = Application.dataPath + "/player.json";
    }

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        database = FirebaseDatabase.DefaultInstance;
    }


    public void SetReference(string path)
    {
        reference = database.GetReference(path);

    }
    public void SetRootReference()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

}
