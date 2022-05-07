using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    Text m_Score;

    void Start()
    {
        SetScore(0);
        ShowScore(false);
    }

    public void SetScore(int score)
    {
        m_Score.text = "SCORE: " + score.ToString();
    }

    public void ShowScore(bool shouldBeShowed)
    {
        if (shouldBeShowed) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

}
