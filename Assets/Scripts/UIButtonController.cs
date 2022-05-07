using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIButtonController : MonoBehaviour
{
    [System.Serializable]
    public struct Commands
    {
        public int id;
        public GameObject gm;
    }
   
    [Header("Buttons")]
    [SerializeField] protected Commands[] m_commands;
    
    
    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
       
    }
    public virtual void Hide(GameObject ui)
    {
        ui.SetActive(false);
    }
   
    public virtual void HideAndShowOther(GameObject toHide, GameObject toOpen)
    {
        toHide.SetActive(false);
        toOpen.SetActive(true);
    }
    public event Action<int> Clicked;
    public virtual void OnButtonClicked(int id)
    {
     
    }

  

}
