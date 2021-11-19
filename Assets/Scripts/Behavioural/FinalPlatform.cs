using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FinalPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            int currentLevel = PlayerPrefs.GetInt(Strings.LEVEL);
            PlayerPrefs.SetInt(Strings.LEVEL, currentLevel + 1);
            ScoreboardUI.Instance.ShowScoreboardUI();
        }
    }
}
