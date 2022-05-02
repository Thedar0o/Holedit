using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    GameObject Character { get; }
    float Speed { get; }
    bool IsPlayer { get; }
}

