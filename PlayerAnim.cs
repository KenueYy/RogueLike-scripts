using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator _anim;
    Vector2 movement;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        PlayRunningAnim(movement);
    }
    private void PlayRunningAnim(Vector2 movement)
    {
        Vector2 dsd = new Vector2(0,0);
        if(movement != dsd)
        {
            _anim.SetBool("isRunning",true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }
    }
}
