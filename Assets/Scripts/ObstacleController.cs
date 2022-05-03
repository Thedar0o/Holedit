using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : Controller
{

    private MeshRenderer m_HoleRenderer;
    private MeshRenderer m_LeftBlockRenderer;
    private MeshRenderer m_RightBlockRenderer;

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



        Speed = Random.Range(2f, 4f);
        m_Hiding = StartHiding(Speed);
        StartCoroutine(m_Hiding);
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

    IEnumerator StartHiding(float duration)
    {        
        var alpha = Mathf.Lerp(1f, 0f, duration * Time.deltaTime);
        while(alpha != 0)
        {
        m_HoleRenderer.material.color = new Color(m_HoleRenderer.material.color.r, m_HoleRenderer.material.color.g, m_HoleRenderer.material.color.b, alpha);
        m_LeftBlockRenderer.material.color = new Color(m_LeftBlockRenderer.material.color.r, m_LeftBlockRenderer.material.color.g, m_LeftBlockRenderer.material.color.b, alpha);
        m_RightBlockRenderer.material.color = new Color(m_RightBlockRenderer.material.color.r, m_RightBlockRenderer.material.color.g, m_RightBlockRenderer.material.color.b, alpha);

        }
        yield return null;
    }
   
}
