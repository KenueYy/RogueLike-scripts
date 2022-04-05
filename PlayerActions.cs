using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
    public KeyCode ActionButton = KeyCode.E;
    private bool chestNearby = false;
    private GameObject ActionObject;

    private void Update()
    {
        if (Input.GetKeyDown(ActionButton) && chestNearby)
            ActionObject.GetComponent<Chest>().Open();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Chest>() != null)
        {
            chestNearby = true;
            ActionObject = collision.gameObject;
        }     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Chest>() != null)
        {
            chestNearby = false;
            ActionObject = null;
        }
    }
}