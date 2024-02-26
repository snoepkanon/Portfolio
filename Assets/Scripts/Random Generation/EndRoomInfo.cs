using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomInfo : MonoBehaviour
{
    public GameObject collisionCheckOBJ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //info meegeven over hoe het gegaanis
        }
    }
}
