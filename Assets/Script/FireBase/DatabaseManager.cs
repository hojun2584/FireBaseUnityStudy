using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System.IO;
using UnityEngine.Rendering;


public class DatabaseManager : SingleTon<DatabaseManager>
{

    public DatabaseReference reference;
    FirebaseDatabase database;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        database = FirebaseDatabase.DefaultInstance;
    }


    public void GetReference(string path)
    {
        reference = database.GetReference(path);

    }
    public void SetRootReference()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

}
