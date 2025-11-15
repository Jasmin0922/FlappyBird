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
  private float deathRotateSpeed = -720f;
  private float deathRotateDuration = 1f;
  private float deathTimer = 0f;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();

    rb.gravityScale = 0f;
  }

  void Update()
  {
    if (isDead)
    {
      if (deathTimer < deathRotateDuration)
      {
        transform.Rotate(0, 0, deathRotateSpeed * Time.deltaTime);
        deathTimer += Time.deltaTime;
      }

      return;
    }
    if (!GameManager.instance.isGameStarted || isDead) return;

    if (Input.GetKeyDown(KeyCode.Space))
    {
      rb.linearVelocity = Vector2.up * jumpForce;
      if (SoundManager.Instance != null)
      {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.jumpSound);
      }
    }

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

    rb.gravityScale = 1f;
    rb.linearVelocity = Vector2.zero;

    GameManager.instance.GameOver();
  }

  public void OnGameStart()
  {
    rb.gravityScale = 1f;
  }
}
