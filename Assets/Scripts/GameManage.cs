using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public enum Scenes
    {
        None = -1,
        Boot = 0,
        MainMenu = 1,
        NewGame = 2,
    }
    
    public static GameManage Instance;
    private IEnumerator loadScene;
   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }               
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LoadScene(Scenes.MainMenu);
    }

    IEnumerator LoadSceneAsync(Scenes scenes)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((int)scenes);

        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        yield return null;
    }

    public void LoadScene(Scenes scenes)
    {
        loadScene = LoadSceneAsync(scenes);
        StartCoroutine(loadScene);
    }

}
