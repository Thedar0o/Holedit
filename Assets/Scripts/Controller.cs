using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour, IController
{
    public enum InputStateFlags
    {
        Null = -1,
        LockInput = 0,
        ReleaseInput,
    }

    public enum EnemyState
    {
        Null = -1,
        CanSpawn = 0,
        BlockSpawn,
    }

    public enum PlayerStates
    {
        Null = -1,
        OnMove = 0,
        OnStanding,
    }

    public enum MouseButtons
    {
        Null = -1,
        Left = 0,
        Right = 1,
        Middle = 2,
    }

    public GameObject Character { get; set; }
    public float Speed { get; set; }

    public bool IsPlayer { get; set; }

    public abstract void Move(float speed);
   
    public virtual void Init()
    {
        
    }

    public virtual bool UseLeftMouse()
    {
        if (Input.GetMouseButton((int)MouseButtons.Left)) return true;
        return false;
    }
    public virtual bool UseRightMouse()
    {
        if (Input.GetMouseButton((int)MouseButtons.Right)) return true;
        return false;
    }

    public virtual bool UseMiddleMouse()
    {
        if (Input.GetMouseButton((int)MouseButtons.Middle)) return true;
        return false;
    }

    void Awake()
    {
        Init();
    }
}
