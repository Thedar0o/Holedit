using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarInfo : MonoBehaviour
{

    [SerializeField]
    GameObject m_Hp1;
    [SerializeField]
    GameObject m_Hp2;
    [SerializeField]
    GameObject m_Hp3;

    void Start()
    {
        SetHPStatus(3);
        //ShowHP(false);
    }
    private void ToggleHp(int count)
    {
        switch(count)
        {
            case 3:
                m_Hp1.SetActive(true);
                m_Hp2.SetActive(true);
                m_Hp3.SetActive(true);
                break;
            case 2:
                m_Hp1.SetActive(true);
                m_Hp2.SetActive(true);
                m_Hp3.SetActive(false);
                break;
            case 1:
                m_Hp1.SetActive(true);
                m_Hp2.SetActive(false);
                m_Hp3.SetActive(false);
                break;
            case 0:
                m_Hp1.SetActive(false);
                m_Hp2.SetActive(false);
                m_Hp3.SetActive(false);
                break;

        }
    }

    public void SetHPStatus(int count)
    {        
        ToggleHp(count);
    }

    public void ShowHP(bool shouldBeShowed)
    {
        if (shouldBeShowed) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
