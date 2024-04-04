using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager InstanceUI { get; private set; }

    public GameObject pauzeMenu;
    void Start()
    {
        if (InstanceUI != null && InstanceUI != this)
        {
            Destroy(this);
        }
        else
        {
            InstanceUI = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
