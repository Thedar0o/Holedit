using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtons : UIButtonController
{
    private enum CommandName
    {
        None = -1,
        Restart = 0,
        Resume =1,
        Options=2,
        Score=3,
        Back=4,
    }


    private void Start()
    {
        m_commands[0].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(0));
        m_commands[1].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(1));
        m_commands[2].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(2));
        m_commands[3].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(3));
        m_commands[4].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(4));
    }

    public override void OnButtonClicked(int id)
    {
        switch ((CommandName)id)
        {
            case CommandName.Restart:
                Restart();
                break;
            case CommandName.Resume:
                Resume();
                break;
            case CommandName.Options:
                Options();
                break;
            case CommandName.Score:
                break;
            case CommandName.Back:
                Exit();
                break;
        }
    }

    private void Restart()
    {
        GameManage.Instance.StartGame(true);        
    }

    private void Exit()
    {
        GameManage.Instance.LoadScene(GameManage.Scenes.MainMenu);
    }

    private void Resume()
    {
        GameManage.Instance.UnPause();
    }

    private void Options()
    {
        GameManage.Instance.SetWindowed();
    }

}