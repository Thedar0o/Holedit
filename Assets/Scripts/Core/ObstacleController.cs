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
    private BoxCollider m_HoleBoxCollider;
    private BoxCollider m_LeftBlockBoxCollider;
    private BoxCollider m_RightBlockBoxCollider;
    private Color m_HoleColor;
    private Color m_LeftBlockColor;
    private Color m_RightBlockColor;
    private bool m_IsFading; 
    private float alpha = 1;
    private float m_t = 0;

    private void Awake()
    {
        InitValues();
    }

    private void InitValues()
    {
        m_HoleBoxCollider = Hole.gameObject.GetComponent<BoxCollider>();
        m_LeftBlockBoxCollider = LeftBlock.gameObject.GetComponent<BoxCollider>();
        m_RightBlockBoxCollider = RightBlock.gameObject.GetComponent<BoxCollider>();
        m_HoleBoxCollider.isTrigger = true;
        m_LeftBlockBoxCollider.isTrigger = true;
        m_RightBlockBoxCollider.isTrigger = true;
        m_HoleRenderer = Hole.GetComponent<MeshRenderer>();
        m_LeftBlockRenderer = LeftBlock.GetComponent<MeshRenderer>();
        m_RightBlockRenderer = RightBlock.GetComponent<MeshRenderer>();
        Speed = 1f;
        m_t = 0;
        alpha = 1;
        m_IsFading = false;
        m_HoleColor = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, 1);
        m_LeftBlockColor = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, 1);
        m_RightBlockColor = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, 1);
        m_HoleRenderer.material.color = m_HoleColor;
        m_LeftBlockRenderer.material.color = m_LeftBlockColor;
        m_RightBlockRenderer.material.color = m_RightBlockColor;

    }

    private void UpdateValues()
    {
        m_HoleBoxCollider.isTrigger = true; 
        m_LeftBlockBoxCollider.isTrigger = true;
        m_RightBlockBoxCollider.isTrigger = true;
        Speed = (GameManage.Instance.MainScore / 4) + 1f;
        alpha = 1;
        m_IsFading = false;
        m_HoleRenderer.material.color = m_HoleColor;
        m_LeftBlockRenderer.material.color = m_LeftBlockColor;
        m_RightBlockRenderer.material.color = m_RightBlockColor;

    }

    private void OnEnable()
    {
        UpdateValues();
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
        while (m_IsFading)
        {
            ChangeAlfa(duration);
            if (alpha == 0f)
            {
                m_IsFading = false;                
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }        
        yield return null;
    }      
    
    public void StartHidingBlock(float duration)
    {
        DisableTrigger();
        m_IsFading = true;
        m_Hiding = HideBlock(duration);
        StartCoroutine(m_Hiding);
    }

    private void ChangeAlfa(float duration)
    {
        alpha = Mathf.Lerp(1f, 0f, m_t);
        m_t += duration * Time.deltaTime;
        m_HoleRenderer.material.color = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, alpha);
        m_LeftBlockRenderer.material.color = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, alpha);
        m_RightBlockRenderer.material.color = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, alpha);
    }

    public void DisableTrigger()
    {
        Hole.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        LeftBlock.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        RightBlock.gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void OnScore()
    {
        StartHidingBlock(2f);
        GameManage.Instance.MainScore += 1;
    }

    public void OnCrash()
    {
        DisableTrigger();
        StartHidingBlock(4f);
        ObstacleSpawnController.Instance.MainCamera.StartShaking();
        GameManage.Instance.MainLife--;
    }
}
