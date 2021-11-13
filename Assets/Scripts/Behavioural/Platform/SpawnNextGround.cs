using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnNextGround : MonoBehaviour
{
    bool isActive = false;
    private void OnEnable()
    {
        isActive = true;
    }
    private void OnDisable()
    {
        isActive = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player!=null && isActive)
        {
            isActive = false;
            GroundGenerator.Instance.SpawnGround();
        }
    }
}
