using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance;

  public int score = 0;
  public int highScore = 0;

  public ScoreDisplay scoreDisplay;

  public HighScoreTMPDisplay gameOverHighScoreTMPDisplay;

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

    if (SoundManager.Instance != null)
    {
      SoundManager.Instance.PlaySFX(SoundManager.Instance.scoreSound);
    }

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

  public void ShowGameOverHighScore()
  {
    if (gameOverHighScoreTMPDisplay != null)
    {
      gameOverHighScoreTMPDisplay.ShowHighScore(highScore);
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