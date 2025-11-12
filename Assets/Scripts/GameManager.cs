using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  [Header("UI References")]
  public GameObject gameOverUI;
  public GameObject getReadyUI;

  [HideInInspector] public bool isGameOver = false;
  [HideInInspector] public bool isGameStarted = false;

  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(gameObject);
      return;
    }
    instance = this;
  }

  public void StartGame()
  {
    if (isGameStarted) return;

    isGameStarted = true;
    isGameOver = false;

    if (getReadyUI != null)
      getReadyUI.SetActive(false);

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

    if (gameOverUI != null)
      gameOverUI.SetActive(true);

    PipeSpawner spawner = FindFirstObjectByType<PipeSpawner>();
    if (spawner != null)
      spawner.StopSpawning();
  }

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
