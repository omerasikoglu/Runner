using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FinalGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            Time.timeScale = 0;
            int currentLevel = PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("level", currentLevel + 1);
            ScoreboardUI.Instance.Activate();
        }
    }
}
