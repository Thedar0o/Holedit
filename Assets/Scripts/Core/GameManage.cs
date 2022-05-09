using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public enum GameState
    {
        None = -1,
        Pause = 0,
        UnPause,
        FirsStart,
    }
    public enum Scenes
    {
        None = -1,
        Boot = 0,
        MainMenu = 1,
        NewGame = 2,
    }
    
    public static GameManage Instance;
    public bool GameWasStarted;
    private IEnumerator loadScene;
    public GameState State;
    public int MainScore;
    public int MainLife;
    public int Windowed = 1;
    public bool CanPause;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }               
        DontDestroyOnLoad(this);
        Windowed = PlayerPrefs.GetInt("Windowed");
        Screen.fullScreen = Windowed == 1 ? false: true;
    }

    private void Start()
    {
        MainScore = 0;
        MainLife = 3;
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

    public void LoadScene(Scenes scene)
    {
        loadScene = LoadSceneAsync(scene);
        StartCoroutine(loadScene);
    }

    public void StartGame(bool InGame)
    {
        GameManage.Instance.GameWasStarted = true;
        UnPause();
        FirstStart();
        loadScene = LoadSceneAsync(Scenes.NewGame);
        StartCoroutine(loadScene);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        State = GameState.Pause;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        State = GameState.UnPause;
        Time.timeScale = 1;
    }

    public void FirstStart()
    {
        State = GameState.FirsStart;
        Time.timeScale = 0;
        MainScore = 0;
    }

    public void SaveWindowedToPrefs(int value)
    {
        Windowed = value;
        PlayerPrefs.SetInt("Windowed", Windowed);
        //SetWindowed();
        PlayerPrefs.Save();
    }

    public void SetWindowed()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            Windowed = 1;           
        }
        else
        {
            Screen.fullScreen = true;
            Windowed = 0;            
        }
        SaveWindowedToPrefs(Windowed);
    }
}
