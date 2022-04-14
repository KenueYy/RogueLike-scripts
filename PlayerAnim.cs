using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void PlayRunningAnim(Vector2 movement)
    {
        Vector2 stay = new Vector2(0,0);
        if(movement != stay)
        {
            _anim.SetBool("isRunning",true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }
    }
}
