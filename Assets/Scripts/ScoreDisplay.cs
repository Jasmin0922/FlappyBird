using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public Sprite[] numberSprites;  // 0~9 对应的图片
    public GameObject digitPrefab;  // 显示单个数字的 Image 预制体

    private List<GameObject> digits = new List<GameObject>();

    public void ShowScore(int score)
    {
        // 清除旧数字
        foreach (var d in digits)
            Destroy(d);
        digits.Clear();

        // 转成字符串 例如 123 → "123"
        string scoreStr = score.ToString();

        // 为每个字符生成数字图片
        foreach (char c in scoreStr)
        {
            int num = c - '0';
            GameObject newDigit = Instantiate(digitPrefab, transform);
            newDigit.GetComponent<Image>().sprite = numberSprites[num];
            digits.Add(newDigit);
        }
    }
}
