using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_InGameMenu;
    [SerializeField]
    private GameObject m_PlayerInfo;
    [SerializeField]
    private GameObject m_StartInfo;
    [SerializeField]
    private GameObject m_Character;
    [SerializeField]
    private BeginGame m_Begin;
    [SerializeField]
    private UnityEngine.UI.Text m_Pause;
    [SerializeField]
    private GameObject m_Resume;

    private PlayerInfo m_PayerInfo;

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
       

        if (GameManage.Instance.MainLife == 0)
        {
            OnDeath();
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
            //m_Pause.text = "PAUSE";
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


    private void OnDeath()
    {
        m_Pause.text = "DEFEAT";
        GameManage.Instance.CanPause = false;
        GameManage.Instance.State = GameManage.GameState.Pause;
        GameManage.Instance.MainLife = 3;
        m_Resume.SetActive(false);
    }
}
