using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour,IOpening
{
    public int price;
    private bool isOpened = false;
    private bool isEmpty = false;
    private Animator _anim;
    public void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (!isOpened)
        {
            if (isEmpty)
            {
                GiveDrops();
                isEmpty = false;
            } 
            isOpened = true;
            _anim.SetBool("isOpening", true);
            Debug.Log("Открыто");
        }
        else
        {
            Close();
        }  
    }
    public void GiveDrops()
    {

    }
    public void Close()
    {
        isOpened = false;
        _anim.SetBool("isOpening", false);
        Debug.Log("Закрыто");
    }
}
