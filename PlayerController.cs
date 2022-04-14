using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera cam;

    private Rigidbody2D _rb;
    private bool isFacingRight = true;
    private PlayerInput _input;
    private PlayerAnim _anim;
    Vector2 movement;
    private void Awake()
    {
        _input = new PlayerInput();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnim>();
        _input.Player.Action.performed += context => gameObject.GetComponent<PlayerActions>().Action();
        _input.Player.Attack.performed += context => gameObject.GetComponent<PlayerFightSystem>().Attack();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    void Update()
    {
        movement = _input.Player.Move.ReadValue<Vector2>();
        _anim.PlayRunningAnim(_input.Player.Move.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);
        if (movement.x > 0 && !isFacingRight) Flip(); else if (movement.x < 0 && isFacingRight) Flip();
    }
    public void Flip()
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
