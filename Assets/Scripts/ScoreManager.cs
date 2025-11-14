using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance;

  public int score = 0;
  public int highScore = 0;

  public ScoreDisplay scoreDisplay;
  public ScoreDisplay gameOverHighScoreDisplay;

  void Awake()
  {
    if (Instance == null)
      Instance = this;
    else if (Instance != this)
      Destroy(gameObject);

    highScore = PlayerPrefs.GetInt("HighScore", 0);
  }

  public void AddScore(int amount)
  {
    score += amount;
    if (score > highScore)
    {
      highScore = score;
      PlayerPrefs.SetInt("HighScore", highScore);
      PlayerPrefs.Save();
    }
    UpdateScoreDisplay();
  }

  void UpdateScoreDisplay()
  {
    if (scoreDisplay != null)
      scoreDisplay.ShowScore(score);
  }

  // 【新增】在游戏结束时调用此方法来更新最高分显示
  public void ShowGameOverHighScore()
  {
    if (gameOverHighScoreDisplay != null)
    {
      // 直接使用之前从 PlayerPrefs 读取的最高分
      gameOverHighScoreDisplay.ShowScore(highScore);
    }
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