using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreboardUI : MonoBehaviour
{
    public static ScoreboardUI Instance { get; private set; }

    [SerializeField] private DeadUI deadUI;

    private TextMeshProUGUI textMeshPro;

    private int score = 0;
    private int allyCubeCount = 0;
    private int enemyCubeCount = 0;
    private bool canShowFinalScreen = false;

    private const string IMAGE = "image";
    private const string TEXT = "text";

    private void Awake()
    {
        Instance = this;

        textMeshPro = transform.Find(IMAGE).Find(TEXT).GetComponent<TextMeshProUGUI>();
        UpdateText();
        transform.Find(IMAGE).gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Input.anyKeyDown && canShowFinalScreen) SceneManager.LoadScene(0/*PlayerPrefs.GetInt("level")*/);
    }
    public void UpdateScore(int changeAmount)
    {
        _ = changeAmount > 0 ? allyCubeCount++ : enemyCubeCount++;
        score += changeAmount;
        UpdateText();
        if (score < 0) deadUI.gameObject.SetActive(true);
    }
    private void UpdateText()
    {
        textMeshPro.text = "<color=yellow>Score:</color>" + score.ToString() + "\n" + 
                           "<color=green>Ally Cube:</color>" + allyCubeCount.ToString() + "\n" +
                           "<color=red> Enemy Cube:</color>" + enemyCubeCount.ToString();
    }

    public void Activate()
    {
        transform.Find(IMAGE).gameObject.SetActive(true);
        canShowFinalScreen = true;
    }
}
