using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Flight Parameters")]
    public float jumpForce = 3f;

    [Header("Bird Sprites")]
    public Sprite[] birdSprites; // 0 = mid, 1 = up, 2 = down

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isDead = false;

    void Awake()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) return;

        // Space key to make the bird jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            sr.sprite = birdSprites[1]; // Upward wing sprite
        }

        // Change bird sprite based on vertical speed
        if (rb.linearVelocity.y > 0.1f)
        {
            sr.sprite = birdSprites[1]; // Ascending
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            sr.sprite = birdSprites[2]; // Falling
        }
        else
        {
            sr.sprite = birdSprites[0]; // Neutral
        }

        // Rotate bird based on vertical speed for natural flight
        float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -90f, 45f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with ground or pipe
        isDead = true;
        GameManager.instance.GameOver();
    }
}
