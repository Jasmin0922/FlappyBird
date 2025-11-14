using TMPro;
using UnityEngine;

public class HighScoreTMPDisplay : MonoBehaviour
{
  public TextMeshProUGUI highScoreText;

  public void ShowHighScore(int value)
  {
    if (highScoreText != null)
    {
      highScoreText.text = value.ToString();
    }
  }
}
