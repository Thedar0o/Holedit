using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public GameObject Character;

    public float Speed;

    public override void Init()
    {
        base.Init();

    }

    public override void Control(float speed)
    {
        if (UseLeftMouse()) MovePlayerToPosition(speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Control(Speed);
    }

    private void MovePlayerToPosition(float speed)
    {
        Character.transform.position = new Vector3(Time.deltaTime * speed, 0f, 0f);
    }
}
