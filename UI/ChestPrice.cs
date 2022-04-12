using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestPrice : MonoBehaviour
{
    public TextMeshProUGUI txPrice;
    public void Set(string price)
    {
        if(price != "0")
        {
            txPrice.text = price;
        }
        else
        {
            txPrice.text = "";
        }
    }
    public void Delete()
    {
        Destroy(gameObject, 0.25f);
    }
}
