using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : Controller
{
    public bool IsSpawnedDown;
    public GameObject Hole;
    public GameObject LeftBlock;
    public GameObject RightBlock;
    
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
        Move(3f);
    }

   
}
