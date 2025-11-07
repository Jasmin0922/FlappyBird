using UnityEngine;

public class PipeSpawner : MonoBehaviour 
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public float pipeGap = 2.8f;
    
    [Header("自动计算的安全范围")]
    private float heightOffset;
    
    void Start() 
    {
        // 自动计算安全的 heightOffset
        Camera cam = Camera.main;
        float screenTop = cam.orthographicSize;
        float pipeHalfHeight = 1.6f; // Size Y 的一半：3.2 / 2
        float pipeLocalY = 3f; // 管子相对 prefab 中心的距离
        
        // 确保管子不超出屏幕
        heightOffset = screenTop - pipeLocalY - pipeHalfHeight;
        
        Debug.Log($"屏幕高度: ±{screenTop}, 安全的 heightOffset: {heightOffset}");
        
        InvokeRepeating("SpawnPipe", 0f, spawnRate);
    }
    
    void SpawnPipe() 
    {
        float randomY = Random.Range(-heightOffset, heightOffset);
        Instantiate(pipePrefab, new Vector3(10, randomY, 0), Quaternion.identity);
    }
}