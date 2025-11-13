using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  [Header("UI References")]
  public GameObject gameOverUI;
  public GameObject getReadyUI;
  public GameObject pauseUI; // <<-- 新增: 暂停菜单UI

  [HideInInspector] public bool isGameOver = false;
  [HideInInspector] public bool isGameStarted = false;
  private bool isPaused = false; // <<-- 新增: 暂停状态


  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(gameObject);
      return;
    }
    instance = this;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (isPaused)
        ResumeGame();
      else
        PauseGame();
    }
  }


  public void PauseGame()
  {
    if (isGameOver || isPaused) return; // 游戏结束或已暂停时，不能再次暂停

    isPaused = true;
    Time.timeScale = 0f; // <<-- 核心: 将时间流速设为 0，暂停游戏

    if (pauseUI != null)
      pauseUI.SetActive(true);
  }

  public void ResumeGame()
  {
    if (!isPaused) return; // 只有在暂停状态才能继续

    isPaused = false;
    Time.timeScale = 1f; // <<-- 核心: 恢复时间流速

    if (pauseUI != null)
      pauseUI.SetActive(false);
  }

  public void StartGame()
  {
    if (isGameStarted) return;

    // 确保游戏开始时时间是流动的
    Time.timeScale = 1f;

    isGameStarted = true;
    isGameOver = false;

    if (getReadyUI != null)
      getReadyUI.SetActive(false);

    // **注意：由于您之前反馈过 FindFirstObjectByType 的问题，
    // 强烈建议将 Bird 和 PipeSpawner 声明为 public 变量并在 Inspector 中拖拽赋值。**

    Bird bird = FindFirstObjectByType<Bird>();
    if (bird != null)
      bird.OnGameStart();

    PipeSpawner spawner = FindFirstObjectByType<PipeSpawner>();
    if (spawner != null)
      spawner.StartSpawning();
  }

  public void GameOver()
  {
    if (isGameOver) return;
    isGameOver = true;

    // 游戏结束时，可选停止时间流逝，或保持 1f 让动画继续。
    // 这里保持 1f，只停止 PipeSpawner。

    if (gameOverUI != null)
      gameOverUI.SetActive(true);

    PipeSpawner spawner = FindFirstObjectByType<PipeSpawner>();
    if (spawner != null)
      spawner.StopSpawning();
  }

  public void RestartGame()
  {
    // 确保在重新加载场景前恢复时间流速
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}