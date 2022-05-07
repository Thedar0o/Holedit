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
                Debug.Log("Options");
                break;
            case CommandName.Score:
                Debug.Log("Score");
                break;
            case CommandName.Exit:
                Debug.Log("Exit");
                break;
        }
    }

    private void StartGame()
    {
        GameManage.Instance.LoadScene(GameManage.Scenes.NewGame);
    }
    
}
