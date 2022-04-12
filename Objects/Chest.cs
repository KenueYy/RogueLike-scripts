using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour, IOpenable
{
    public int price;
    public ChestPrice chestPrice;
    public List<BuffObject> buffs;
    public Buff buff;
    private bool isOpened = false;
    private Animator _anim;
    public void Start()
    {
        _anim = GetComponent<Animator>();
        chestPrice.Set(price.ToString());
    }

    public void Open()
    {
        if (!isOpenedChest())
        {
            if (chestPrice != null)
            {
                GiveDrops();
            } 
            _anim.SetBool("isOpening", true);
        }
        else
        {
            Close();
        }  
    }
    public bool isOpenedChest()
    {
        if (!isOpened)
            return isOpened = true;
        else
            return isOpened = false;
    }
    public void GiveDrops()
    {
        buff.data = buffs[Random.Range(0, buffs.Count)];
        buff = Instantiate(buff,gameObject.transform);
        chestPrice.Delete();
    }
    public void Close()
    {
        _anim.SetBool("isOpening", false);
    }
}
