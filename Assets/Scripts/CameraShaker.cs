using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    private Vector3 m_oryginalPossition;

    private float m_Duration = 0.2f;

    private float m_MinShakeValue = 1.2f;
    private float m_MaxShakeValue = 1f;
    // Start is called before the first frame update
    void Start()
    {
        m_oryginalPossition = gameObject.transform.position;
    }

    public void StartShaking()
    {
        m_Duration = 0.2f;
        StartCoroutine("ShakeIt");
    } 

    private IEnumerator ShakeIt()
    {
        do
        {
            gameObject.transform.localPosition = m_oryginalPossition + Random.insideUnitSphere * m_MinShakeValue;

            m_Duration -= Time.deltaTime * m_MaxShakeValue;
            yield return null;
        }
        while (m_Duration > 0);
        m_Duration = 0f;
        gameObject.transform.localPosition = m_oryginalPossition;
        yield break;      
        
    }
    
}
