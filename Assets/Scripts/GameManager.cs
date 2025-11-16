using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  [Header("UI References")]
  public GameObject gameOverUI;
  public GameObject getReadyUI;
  public GameObject pauseUI;

  [HideInInspector] public bool isGameOver = false;
  [HideInInspector] public bool isGameStarted = false;
  [SerializeField] private Bird bird;
  [SerializeField] private PipeSpawner spawner;
  private bool isPaused = false;
  private float pauseCooldown = 0f;


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
    if (pauseCooldown > 0f)
      pauseCooldown -= Time.unscaledDeltaTime;
    if (Input.GetKeyDown(KeyCode.Escape) && pauseCooldown <= 0f)
    {
      pauseCooldown = 0.1f;

      if (isPaused)
        ResumeGame();
      else
        PauseGame();
    }
  }


  public void PauseGame()
  {
    if (isGameOver || isPaused) return;

    isPaused = true;
    Time.timeScale = 0f;

    if (pauseUI != null)
    {
      pauseUI.SetActive(true);
    }

  }

  public void ResumeGame()
  {
    if (!isPaused) return;

    isPaused = false;
    Time.timeScale = 1f;

    if (pauseUI != null)
      pauseUI.SetActive(false);
  }

  public void StartGame()
  {
    if (isGameStarted) return;
    Time.timeScale = 1f;

    isGameStarted = true;
    isGameOver = false;

    if (getReadyUI != null)
      getReadyUI.SetActive(false);

    if (bird != null)
      bird.OnGameStart();

    if (spawner != null)
      spawner.StartSpawning();
  }

  public void GameOver()
  {
    if (isGameOver) return;
    isGameOver = true;

    if (gameOverUI != null)
      gameOverUI.SetActive(true);

    if (ScoreManager.Instance != null)
    {
      ScoreManager.Instance.ShowGameOverHighScore();
    }

    if (SoundManager.Instance != null)
    {
      SoundManager.Instance.PlaySFX(SoundManager.Instance.hitSound);
    }

    if (spawner != null)
      spawner.StopSpawning();
  }

  public void RestartGame()
  {
    Time.timeScale = 1f;
    if (pauseUI) pauseUI.SetActive(false);
    if (gameOverUI) gameOverUI.SetActive(false);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}