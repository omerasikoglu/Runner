using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    
    private int level;


    private void Awake()
    {
        textMeshPro = transform.Find(Strings.IMAGE).Find(Strings.TEXT).GetComponent<TextMeshProUGUI>();
        UpdateLevel();
    }
    public void UpdateLevel()
    {
        level = PlayerPrefs.GetInt(Strings.LEVEL);
        textMeshPro.SetText(level.ToString());
    }
}
