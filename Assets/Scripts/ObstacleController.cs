using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : Controller
{

    private MeshRenderer m_HoleRenderer;
    private MeshRenderer m_LeftBlockRenderer;
    private MeshRenderer m_RightBlockRenderer;
    private bool m_IsFading; 
    private float alpha = 1;

    public bool IsSpawnedDown;
    public GameObject Hole;
    public GameObject LeftBlock;
    public GameObject RightBlock;
    private IEnumerator m_Hiding;

    private void Start()
    {
        m_HoleRenderer = Hole.GetComponent<MeshRenderer>();
        m_LeftBlockRenderer= LeftBlock.GetComponent<MeshRenderer>();
        m_RightBlockRenderer= RightBlock.GetComponent<MeshRenderer>();
                
        //m_Hiding = HideAndCreateNew(Speed);        
        //StartCoroutine(m_Hiding);
    }

    private void OnEnable()
    {
        Speed = Random.Range(2f, 5f);
        t = 0;
        alpha = 1;
        m_Hiding = HideAndCreateNew(Speed);
        StartCoroutine(m_Hiding);
        m_IsFading = false;
        m_HoleRenderer.material.color = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, 1);
        m_LeftBlockRenderer.material.color = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, 1);
        m_RightBlockRenderer.material.color = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, 1);
    }

    public override void Move(float speed)
    {
        if (IsSpawnedDown)
        {
            transform.position += new Vector3(0f,0f, speed * Time.deltaTime);
        }
        else transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
    }
    // Start is called before the first frame update

    private void Update()
    {
        Move(Speed);       
    }
    float t=0;
    IEnumerator HideAndCreateNew(float duration)
    {
        do
        {
            if(IsSpawnedDown && gameObject.transform.position.z > 0.25f) m_IsFading = true;
            if(!IsSpawnedDown && gameObject.transform.position.z < -0.25f) m_IsFading = true;
            yield return null;
        }
        while (!m_IsFading);

        
        while (m_IsFading)
        {
            alpha = Mathf.Lerp(1f, 0f, t);
            t += 0.4f*Time.deltaTime;
            Debug.Log(alpha);
            m_HoleRenderer.material.color = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, alpha);
            m_LeftBlockRenderer.material.color = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, alpha);
            m_RightBlockRenderer.material.color = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, alpha);
            if (alpha == 0f)
            {
                m_IsFading = false;
                GameObject obs = ObstacleSpawnController.Instance.GetPooledObj();
                if(obs != null)
                {
                    obs.SetActive(true);
                }
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
        
        yield return null;
    }

}
