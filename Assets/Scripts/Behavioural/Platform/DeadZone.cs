using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            ScoreboardUI.Instance.UpdateScore(-9999);
        }
    }
}
