using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
  public Sprite[] numberSprites;
  public GameObject digitPrefab;

  private List<GameObject> digits = new List<GameObject>();

  public void ShowScore(int score)
  {
    foreach (var d in digits)
      Destroy(d);
    digits.Clear();

    string scoreStr = score.ToString();

    foreach (char c in scoreStr)
    {
      int num = c - '0';

      GameObject newDigit = Instantiate(digitPrefab, transform);
      newDigit.GetComponent<Image>().sprite = numberSprites[num];
      digits.Add(newDigit);
    }
  }
}