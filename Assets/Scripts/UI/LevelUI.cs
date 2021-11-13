using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    
    private int level;

    private const string IMAGE = "image";
    private const string TEXT = "text";
    private const string LEVEL = "level";

    private void Awake()
    {
        textMeshPro = transform.Find(IMAGE).Find(TEXT).GetComponent<TextMeshProUGUI>();
        UpdateLevel();
    }
    public void UpdateLevel()
    {
        level = PlayerPrefs.GetInt(LEVEL);
        textMeshPro.SetText(level.ToString());
    }
}
