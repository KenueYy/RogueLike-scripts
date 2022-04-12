using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera cam;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isFacingRight = true;
    private PlayerBuffs _playerBuffs;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (movement.x > 0 && !isFacingRight) Flip(); else if (movement.x < 0 && isFacingRight) Flip();
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void BuffSpeed(float value)
    {
        speed += value;
    }
}
