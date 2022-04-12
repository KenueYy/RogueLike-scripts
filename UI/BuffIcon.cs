using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffIcon : MonoBehaviour
{
    public TextMeshProUGUI lvlBuff;

    public void SetLevelBuff(string value)
    {
        lvlBuff.text = value;
    }
}
