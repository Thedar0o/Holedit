using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtons : UIButtonController
{
    private enum CommandName
    {
        None = -1,
        Restart = 0,
        Resume,
        Options,
        Score,
        Back,
    }

    private void Start()
    {
        m_commands[0].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(0));
        m_commands[1].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(1));
        m_commands[1].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(2));
        m_commands[2].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(3));
        m_commands[3].gm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClicked(4));
    }

    public override void OnButtonClicked(int id)
    {
        switch ((CommandName)id)
        {
            case CommandName.Restart:
                Restart();
                break;
            case CommandName.Resume:
                break;
            case CommandName.Options:
                Debug.Log("Options");
                break;
            case CommandName.Score:
                Debug.Log("Score");
                break;
            case CommandName.Back:
                Exit();
                break;
        }
    }

    private void Restart()
    {
        GameManage.Instance.LoadScene(GameManage.Scenes.NewGame);
    }

    private void Exit()
    {
        GameManage.Instance.LoadScene(GameManage.Scenes.MainMenu);
    }

    private void Score()
    {

    }

    private void OpenScoreBoard()
    {

    }

}