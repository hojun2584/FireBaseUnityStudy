using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingleTon<SceneController>
{
    public enum SceneName
    {
        INTRO,
        MAIN,
        END
    }

    private String introScene = "Intro";
    private String mainScene = "Main";
    private String endScene = "End";

    Dictionary<SceneName, string> sceneDict = new Dictionary<SceneName, string>();
    
    public void Start()
    {
        sceneDict[SceneName.INTRO] = introScene;
        sceneDict[SceneName.MAIN] = mainScene;
        sceneDict[SceneName.END] = endScene;
    }


    public void LoadScene(SceneController.SceneName name)
    {
        SceneManager.LoadScene(sceneDict[name]);
    }

}
