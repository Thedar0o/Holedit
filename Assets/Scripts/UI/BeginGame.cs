using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField]
    GameObject m_Character;
    [SerializeField]
    GameObject m_FirstStartUI;
    [SerializeField]
    GameObject m_AnotherStartUI;

    private bool m_WasPressed;
    public void WasStarted()
    {        
        if (m_WasPressed) return;
        else
        {
            GameManage.Instance.CanPause = true;
            m_WasPressed = true;
            m_Character.SetActive(true);
            gameObject.SetActive(false);
            GameManage.Instance.GameWasStarted = true;
            GameManage.Instance.UnPause();
        }
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            WasStarted();
        }
    }

    public void Init()
    {
        if (GameManage.Instance.GameWasStarted)
        {
            m_FirstStartUI.SetActive(false);
            m_AnotherStartUI.SetActive(true);
        }
        else
        {
            m_AnotherStartUI.SetActive(false);
            m_FirstStartUI.SetActive(true);
            
        }
        
    }
}
