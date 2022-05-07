using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IButton
{
    [SerializeField]
    private int m_ID;
    public int id { get => m_ID; }         

}
