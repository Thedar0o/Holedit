using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField]
    GameObject m_Character;

    private bool m_AlreadyStarted;
      
    public void WasStarted()
    {
        if (m_AlreadyStarted) return;
        else
        {
            m_Character.SetActive(true);
            gameObject.SetActive(false);
            m_AlreadyStarted = true;
            GameManage.Instance.UnPause();
        }
    }
    //private void Update()
    //{
    //    if (Input.anyKey) WasStarted();
    //}

    public void Init()
    {
        gameObject.SetActive(true);
        m_AlreadyStarted = false;
        //GameManage.Instance.Pause();
    }
}
