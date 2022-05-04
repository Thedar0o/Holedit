using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour
{
    [Tooltip("How long slab shoud be obstacles + 1 as hole")]
    [SerializeField]
    [Range(3, 17)] private int BlockLongValue;

    public static ObstacleSpawnController Instance;
    private List<GameObject> m_Obstacles = new List<GameObject>();
    private static int s_Widht = 17;
    private int m_ObstSpawnPoint;
    private int m_CubeSpawnPoint;
    private int m_LeftObstxScale;
    private float m_LeftObstPos;
    private int m_RightObstxScale;
    private float m_RightObstPos;


    [SerializeField]
    int SpawnAmmount = 0;

    [SerializeField]
    GameObject ObjectHolder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < SpawnAmmount; i++)
        {
            GameObject obj = Instantiate(ObjectHolder);
            obj.SetActive(false);            
            m_Obstacles.Add(RandomizeObstacles(obj));
        }
        StartCoroutine("Spawn");
    }

    public GameObject GetPooledObj()
    {
        for(int i =0; i < m_Obstacles.Count; i++)
        {
            if (!m_Obstacles[i].activeInHierarchy)
            {
                m_Obstacles[i] = RandomizeObstacles(m_Obstacles[i]);
                return m_Obstacles[i];
            }
        }
        return null;
    }
    public void SpawnObstacle()
    {
        GameObject obs = GetPooledObj();
        if (obs != null)
        {
            obs.SetActive(true);
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f,3f));
            SpawnObstacle();
            //yield return null;
        }
    }

    private GameObject RandomizeObstacles(GameObject obst)
    {
        ZeroAll();
        var ObstacleControl = obst.GetComponent<ObstacleController>();
        if (Random.Range(0, 2) == 1)
        {
            obst.transform.position = new Vector3(0,0,-7);
            ObstacleControl.IsSpawnedDown = true;
        }
        else
        {
            obst.transform.position = new Vector3(0,0,7);
            ObstacleControl.IsSpawnedDown = false;
        }

        m_CubeSpawnPoint = Random.Range(-7, 7);
        if (m_CubeSpawnPoint < 0) //-7, -6 , -5, -4, -3, -2 , -1
        {
            m_LeftObstxScale -= m_CubeSpawnPoint*(-1);
            m_LeftObstPos = -(((Mathf.Abs(8f-m_LeftObstxScale)) / 2f)-m_LeftObstPos);
            m_RightObstxScale += m_CubeSpawnPoint*(-1);
            m_RightObstPos = (Mathf.Abs(((Mathf.Abs(8f - m_RightObstxScale)) / 2f)-m_RightObstPos));
        }
        else
        {
            m_LeftObstxScale += m_CubeSpawnPoint;
            m_LeftObstPos = (((Mathf.Abs(8f - m_LeftObstxScale)) / 2f) + m_LeftObstPos);
            m_RightObstxScale -= m_CubeSpawnPoint;
            m_RightObstPos = (Mathf.Abs(((Mathf.Abs(8f - m_RightObstxScale)) / 2f) + m_RightObstPos));
        }
        ObstacleControl.Hole.transform.localPosition = new Vector3(m_CubeSpawnPoint, 0, 0);

        ObstacleControl.LeftBlock.transform.localScale = new Vector3(m_LeftObstxScale, 1, 1);
        ObstacleControl.LeftBlock.transform.localPosition = new Vector3(m_LeftObstPos, 0, 0);
        
        ObstacleControl.RightBlock.transform.localScale = new Vector3(m_RightObstxScale,  1, 1);
        ObstacleControl.RightBlock.transform.localPosition = new Vector3(m_RightObstPos, 0, 0);

        return obst;
    }

    private void ZeroAll()
    {
        m_CubeSpawnPoint = 0;
        m_LeftObstxScale = 8;
        m_LeftObstPos = -4.5f;
        m_RightObstxScale = 8;
        m_RightObstPos = 4.5f;
    }
}
