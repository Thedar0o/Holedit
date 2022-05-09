using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private UnityEngine.UI.Text m_text;
    private float m_Timer = 0;
    private float alpha = 1;

    private float max, min;


    private void OnEnable()
    {
        m_text = gameObject.GetComponent<UnityEngine.UI.Text>();
        StartCoroutine(FadeTextToFullAlpha(0.01f, m_text));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.unscaledDeltaTime / t));
            yield return null;
        }
        yield return StartCoroutine(FadeTextToZeroAlpha(1f, m_text));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.unscaledDeltaTime / t));
            yield return null;
        }
        yield return StartCoroutine(FadeTextToFullAlpha(1f, m_text));
    }
}