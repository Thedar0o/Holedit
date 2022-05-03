using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour
{
    public static ObstacleSpawnController Instance;

    private List<GameObject> m_Obstacles = new List<GameObject>();
    private static int s_Widht = 17;
    private int m_ObstSpawnPoint;
    private int m_CubeSpawnPoint;
    private int m_LeftObstxScale = 8;
    private int m_LeftObstPos;
    private int m_RightObstxScale = 8;
    private int m_RightObstPos;


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
            var obj = Instantiate(ObjectHolder);
            obj.SetActive(false);
            m_Obstacles.Add(obj);
        }
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

    private void ChangeHolePosition()
    {
       
    }

    private GameObject RandomizeObstacles(GameObject obst)
    {
        if (Random.Range(0, 2) == 1)
        {
            m_ObstSpawnPoint = -7;
            ObjectHolder.GetComponent<ObstacleController>().IsSpawnedDown = true;
        }
        else
        {
            m_ObstSpawnPoint = 7;
            ObjectHolder.GetComponent<ObstacleController>().IsSpawnedDown = false;
        }

        m_CubeSpawnPoint = Random.Range(-8, 8);
        if (m_CubeSpawnPoint < 0)
        {
            m_LeftObstxScale = m_LeftObstxScale + m_CubeSpawnPoint;
            m_RightObstxScale = m_RightObstxScale - m_CubeSpawnPoint;
        }
        else
        {
            m_LeftObstxScale = m_LeftObstxScale - m_CubeSpawnPoint;
            m_RightObstxScale = m_RightObstxScale + m_CubeSpawnPoint;
        }

        return obst;
    }
}
