using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 6f;

    void Update()
    {
      if (!GameManager.instance.isGameStarted) return;
        if (GameManager.instance != null && GameManager.instance.isGameOver) return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
