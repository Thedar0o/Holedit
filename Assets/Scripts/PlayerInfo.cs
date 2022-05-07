using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    HpBarInfo m_HpBar;

    [SerializeField]
    ScoreManager m_ScoreInfo;

    public void SetScore(int score)
    {
        m_ScoreInfo.SetScore(score);
    }
     
    public void SetHP(int hp)
    {
        m_HpBar.SetHPStatus(hp);
    }
}
