using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
    public KeyCode ActionButton = KeyCode.E;
    private bool chestNearby = false;
    private GameObject ActionObject;
    private PlayerBuffs _playerBuffs;
    private void Start()
    {
        _playerBuffs = GetComponent<PlayerBuffs>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(ActionButton) && chestNearby)
            ActionObject.GetComponent<IOpenable>().Open();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IOpenable>() != null)
        {
            chestNearby = true;
            ActionObject = collision.gameObject;
        }
        if (collision.GetComponent<Buff>() != null)
        {
            Buff _buff = collision.GetComponent<Buff>();
            _playerBuffs.TakeBuff(_buff.data);
            _buff.Delete();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IOpenable>() != null)
        {
            chestNearby = false;
            ActionObject = null;
        }
    }
}