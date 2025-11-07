using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    public ScoreDisplay scoreDisplay; // 关联到用图片显示数字的脚本

    void Awake()
    {
            if (Instance == null)
        Instance = this;
    else if (Instance != this)
        Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        if (scoreDisplay != null)
            scoreDisplay.ShowScore(score);
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }
    
    void OnDestroy()
{
    if (Instance == this)
        Instance = null;
}
}
