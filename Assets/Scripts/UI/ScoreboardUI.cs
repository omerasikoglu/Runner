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
    private int coinCount;
    private bool canShowFinalScreen = false;

    private void Awake()
    {
        Instance = this;

        textMeshPro = transform.Find(Strings.IMAGE).Find(Strings.TEXT).GetComponent<TextMeshProUGUI>();
        UpdateText();
        transform.Find(Strings.IMAGE).gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Input.anyKeyDown && canShowFinalScreen) SceneManager.LoadScene(0);
    }
    public void UpdateCoinAmount()
    {
        coinCount++;
        UpdateText();
    }
    public void UpdateScore(int changeAmount = 0)
    {
        _ = changeAmount > 0 ? allyCubeCount++ : enemyCubeCount++;
        score += changeAmount;
        UpdateText();
        if (score < 0 || changeAmount == 0 /*falled*/)
        {
            deadUI.gameObject.SetActive(true);
            ShowScoreboardUI();
        }
    }
    private void UpdateText()
    {
        textMeshPro.text = "<b>Total Score:</b>" + (score + coinCount).ToString() + "\n" +
                           "<b>Gained Cube:</b>" + allyCubeCount.ToString() + "\n" +
                           "<b>Gained Coin:</b>" + coinCount.ToString() + "\n" +
                           "<b>Wrong Cubes:</b>" + enemyCubeCount.ToString();
    }

    public void ShowScoreboardUI()
    {
        transform.Find(Strings.IMAGE).gameObject.SetActive(true);
        canShowFinalScreen = true;
        Time.timeScale = 0;
    }
}
