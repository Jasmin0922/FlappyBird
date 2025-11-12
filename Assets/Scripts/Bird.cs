using UnityEngine;

public class Bird : MonoBehaviour
{
  [Header("Flight Parameters")]
  public float jumpForce = 3f;

  [Header("Sprites")]
  public Sprite deadSprite;

  private Rigidbody2D rb;
  private Animator animator;
  private SpriteRenderer sr;
  private bool isDead = false;

  void Awake()
  {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        rb.gravityScale = 0f;
  }

  void Update()
  {
    if (!GameManager.instance.isGameStarted || isDead) return;

    // Space key to make the bird jump
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rb.linearVelocity = Vector2.up * jumpForce;

    }

    // Rotate bird based on vertical speed for natural flight
    float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -90f, 45f);
    transform.rotation = Quaternion.Euler(0, 0, angle);

  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (isDead) return;
    isDead = true;

    if (animator != null)
      animator.enabled = false;

    if (sr != null && deadSprite != null)
      sr.sprite = deadSprite;

    GameManager.instance.GameOver();
  }
    
        public void OnGameStart()
    {
        rb.gravityScale = 1f; // 或你原来的值
    }
}
