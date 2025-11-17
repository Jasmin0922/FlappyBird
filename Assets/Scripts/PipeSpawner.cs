using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
  public GameObject pipePrefab;
  public float spawnRate = 1f;
  public float pipeGap = 2.8f;
  public float difficultyIncreaseRate = 2f; // how often to increase difficulty (seconds)
  public float minPipeGap = 1.4f;

  private float heightOffset;

  private bool isSpawning = false;

  void Start()
  {

    Camera cam = Camera.main;
    float screenTop = cam.orthographicSize;
    float pipeHalfHeight = 1.6f;
    float pipeLocalY = 3f;

    heightOffset = screenTop - pipeLocalY - pipeHalfHeight;
  }

  public void StartSpawning()
  {
    if (isSpawning) return;
    isSpawning = true;
    InvokeRepeating(nameof(SpawnPipe), 0f, spawnRate);
    InvokeRepeating(nameof(IncreaseDifficulty), difficultyIncreaseRate, difficultyIncreaseRate);
  }

  public void StopSpawning()
  {
    if (!isSpawning) return;
    isSpawning = false;
    CancelInvoke(nameof(SpawnPipe));
    CancelInvoke(nameof(IncreaseDifficulty));
  }
  void SpawnPipe()
  {
    float randomY = Random.Range(-heightOffset, heightOffset);
    GameObject newPipe = Instantiate(pipePrefab, new Vector3(10, randomY, 0), Quaternion.identity);

    Pipe pipe = newPipe.GetComponent<Pipe>();
    if (pipe != null)
    {
      pipe.SetGap(pipeGap);
    }
  }

  void IncreaseDifficulty()
  {
    if (pipeGap > minPipeGap)
      pipeGap -= 0.06f;

  }
}
