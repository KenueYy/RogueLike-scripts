using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour,IOpening
{
    public int price;
    public UnityEvent<GameObject> ChestOpened;
    private bool isOpened = false;
    private bool isEmpty = false;
    private bool playerNearby = false;
    private Animator _anim;
    private GameObject _chest;
    public void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerActions>() != null)
        {
            _chest = this.gameObject;
            playerNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerActions>() != null)
            this.playerNearby = false;
    }
    private void Update()
    {
        ChestOpened?.Invoke(_chest);
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
