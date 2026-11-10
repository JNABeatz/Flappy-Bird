using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public static score Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        UpdateScoreUI();
    }

    private void update()
    {
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }
    public int getpoints()
    {
        return currentScore;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + currentScore;
        }
    }
}
