using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : Controller
{
    public GameObject Hole;
    public GameObject LeftBlock;
    public GameObject RightBlock;
    public bool IsSpawnedDown;

    private IEnumerator m_Hiding;
    private MeshRenderer m_HoleRenderer;
    private MeshRenderer m_LeftBlockRenderer;
    private MeshRenderer m_RightBlockRenderer;
    private bool m_IsFading; 
    private float alpha = 1;
    private float m_t = 0;


    private void Start()
    {          

    }

    private void InitValues()
    {
        m_HoleRenderer = Hole.GetComponent<MeshRenderer>();
        m_LeftBlockRenderer = LeftBlock.GetComponent<MeshRenderer>();
        m_RightBlockRenderer = RightBlock.GetComponent<MeshRenderer>();
        Speed = Random.Range(2f, 5f);
        m_t = 0;
        alpha = 1;
        //m_Hiding = HideBlock(Speed);
        //StartCoroutine(m_Hiding);
        m_IsFading = false;
        m_HoleRenderer.material.color = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, 1);
        m_LeftBlockRenderer.material.color = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, 1);
        m_RightBlockRenderer.material.color = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, 1);

    }

    private void OnEnable()
    {
        InitValues();
    }

    public override void Move(float speed)
    {
        if (IsSpawnedDown)
        {
            transform.position += new Vector3(0f,0f, speed * Time.deltaTime);
        }
        else transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
    }
   

    private void Update()
    {
        Move(Speed);       
    }
    
    private IEnumerator HideBlock(float duration)
    {
        //do
        //{
        //    if(IsSpawnedDown && gameObject.transform.position.z > 0.25f) m_IsFading = true;
        //    if(!IsSpawnedDown && gameObject.transform.position.z < -0.25f) m_IsFading = true;
        //    yield return null;
        //}
        //while (!m_IsFading);
        
        while (m_IsFading)
        {
            ChangeAlfa();
            if (alpha == 0f)
            {
                m_IsFading = false;
                //Spawn();
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }        
        yield return null;
    }      
    
    public void StartHidingBlock(float duration)
    {
        m_IsFading = true;
        m_Hiding = HideBlock(Speed);
        StartCoroutine(m_Hiding);
    }

    private void ChangeAlfa()
    {
        alpha = Mathf.Lerp(1f, 0f, m_t);
        m_t += 0.7f * Time.deltaTime;
        m_HoleRenderer.material.color = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, alpha);
        m_LeftBlockRenderer.material.color = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, alpha);
        m_RightBlockRenderer.material.color = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, alpha);
    }
}
