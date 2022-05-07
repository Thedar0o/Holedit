using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    GameObject m_InGameMenu;
    [SerializeField]
    GameObject m_PlayerInfo;
    [SerializeField]
    GameObject m_StartInfo;
    [SerializeField]
    GameObject m_Character;
    [SerializeField]
    BeginGame m_Begin;

    private bool m_IsjustStarted;
    private PlayerInfo m_PayerInfo;
    private HpBarInfo m_Hp;

    private void Start()
    {
        m_PayerInfo = m_PlayerInfo.GetComponent<PlayerInfo>();
        GameManage.Instance.FirstStart();
        Init();
    }

    void Init()
    {
        GameManage.Instance.MainLife = 3;
        m_StartInfo.SetActive(true);
        m_InGameMenu.SetActive(false);
        m_PlayerInfo.SetActive(false);
        m_Character.SetActive(false);
    }

    private void Update()
    {
        ShowHidePause();
        m_PayerInfo.SetScore(GameManage.Instance.MainScore);
        m_PayerInfo.SetHP(GameManage.Instance.MainLife);
        if (Input.anyKey)
        {
            m_Begin.WasStarted();
        }
        if (GameManage.Instance.MainLife == 0)
        {
            //GameManage.Instance.LoadScene(GameManage.Scenes.MainMenu);
            GameManage.Instance.State = GameManage.GameState.Pause;
            GameManage.Instance.MainLife = 3;
        }
    }

    private void ShowHidePause()
    {
        if (GameManage.Instance.State == GameManage.GameState.UnPause)
        {
            m_InGameMenu.SetActive(false);
            m_PlayerInfo.SetActive(true);
            m_Character.SetActive(true);

        }
        else if (GameManage.Instance.State == GameManage.GameState.Pause)
        {
            m_InGameMenu.SetActive(true);
            m_PlayerInfo.SetActive(false);
            m_Character.SetActive(false);
        }
        else
        {
            Init();
            m_Begin.Init();
        }
    }

}
