using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButtons : UIButtonController
{
    private enum CommandName
    {
        None = -1,
        StartGame = 0,
        Options,
        Score,
        Exit,
    }
    
    private void Start()
    {
        m_commands[0].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(0));
        m_commands[1].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(1));
        m_commands[2].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(2));
        m_commands[3].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(3));
    }  

    public override void OnButtonClicked(int id)
    {
        switch ((CommandName)id)
        {
            case CommandName.StartGame:
                StartGame();
                break;
            case CommandName.Options:
                Options();
                break;
            case CommandName.Score:
                break;
            case CommandName.Exit:
                Exit();
                break;
        }
    }

    private void StartGame()
    {
        GameManage.Instance.LoadScene(GameManage.Scenes.NewGame);
        GameManage.Instance.GameWasStarted = false;
    }

    private void Exit()
    {
        GameManage.Instance.OnExit();
    }

    private void Options()
    {
        GameManage.Instance.SetWindowed();
    }

    
    
}
