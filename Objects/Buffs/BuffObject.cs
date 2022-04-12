using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff", menuName = "Add Buff", order = 51)]
public class BuffObject : ScriptableObject
{
    public Sprite sprite;
    public int speedLvL;
    public int damageLvL;
    public int attackSpeedLvl;
    public int vampiricLvL;
    public int bladeHelmetLvL;
    public int maxHealthLvL;
}
