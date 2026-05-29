using UnityEngine;

public class Racket : MonoBehaviour
{
    // Racket rigidbody, we will control this to move
    public Rigidbody2D rb2d;
    // How fast we move horizontally in pixels per second
    public float moveSpeed = 100; // in px

    public SpriteRenderer racketLeft;
    public SpriteRenderer racketCentre;
    public SpriteRenderer racketRight;
    public BoxCollider2D boxCollider2D;
    public CapsuleCollider2D capsuleCollider2D;

    void AutoSizeRacket()
    {
        // Change size of collider
        // Get size of paddle segments
        float width = racketLeft.bounds.size.x + racketRight.bounds.size.x + racketCentre.bounds.size.x;
        float height = racketCentre.bounds.size.y;
        boxCollider2D.size = new Vector2(width, height);
        capsuleCollider2D.size = new Vector2(width, height);

        // Set position of left and right segments

    }

    void FixedUpdate()
    {
        AutoSizeRacket();

        // Move player horizontally
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb2d.linearVelocityX = moveX;
    }

    void OnValidate()
    {
        // Get rigidbody automatically if it is null and attached to this object
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();
        
        if (boxCollider2D == null)
            boxCollider2D = GetComponent<BoxCollider2D>();
        
        if (capsuleCollider2D == null)
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
}
