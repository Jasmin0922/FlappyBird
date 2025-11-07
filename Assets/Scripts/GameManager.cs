using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    public GameObject gameOverUI;   // GameOver UI
    public GameObject getReadyUI;   // 开场提示动画 UI（可选）

    [HideInInspector] public bool isGameOver = false;

    private void Awake()
    {
    if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }
    instance = this;
    }

    // 游戏结束
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        // 显示 GameOver UI
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

    // 按钮调用，立即重新加载场景
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
