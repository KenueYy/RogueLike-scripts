using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBuffs : MonoBehaviour
{
    [Header("Статы за уровень")]
    public float speedPerLvl;
    public float damagePerLvl;
    public float attackSpeedPerLvl;
    public float maxHealthPerLvl;
    public float bladeHelmetDamagePerLvl;
    public float vampiricPerLvl;
    [Header("Уровень")]
    public int lvlSpeed;
    public int lvlDamage;
    public int lvlAttackSpeed;
    public int lvlVamipric;
    public int lvlMaxHealth;
    public int lvlBladeHelmet;

    public PlayerUI playerUI;
    private PlayerController _playerController;
    private PlayerFightSystem _playerFightSystem;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerFightSystem = GetComponent<PlayerFightSystem>();
    }
    public void SpeedUp(int countUPs)
    {
        float speed = 0;
        lvlSpeed += countUPs;
        speed += speedPerLvl * countUPs;
        _playerController.BuffSpeed(speed);
        playerUI.buffSpeedIcon.SetLevelBuff(lvlSpeed.ToString());
    }
    public void DamageUp(int countUPs)
    {
        float damage = 0;
        lvlDamage += countUPs;
        damage += damagePerLvl * countUPs;
        _playerFightSystem.BuffDamage(damage);
        playerUI.buffDamageIcon.SetLevelBuff(lvlDamage.ToString());
    }
    public void AttackSpeedUp(int countUPs)
    {
        float attakSpeed = 0;
        lvlAttackSpeed += countUPs;
        attakSpeed += attackSpeedPerLvl * countUPs;
        _playerFightSystem.BuffAttackSpeed(attakSpeed);
        playerUI.buffAttackSpeedIcon.SetLevelBuff(lvlAttackSpeed.ToString());
    }
    public void VampiricUp(int countUPs)
    {
        float vampiric = 0;
        lvlVamipric += countUPs;
        vampiric += vampiricPerLvl * countUPs;
    }
    public void BladeHelmetUp(int countUPs)
    {
        lvlBladeHelmet += countUPs;
        bladeHelmetDamagePerLvl += vampiricPerLvl * countUPs;
    }
    public void MaxHealthUp(int countUPs)
    {
        float maxHealth = 0;
        lvlMaxHealth += countUPs;
        maxHealth += maxHealthPerLvl * countUPs;
        _playerFightSystem.BuffMaxHealth(maxHealth);
        playerUI.buffMaxHealthIcon.SetLevelBuff(lvlMaxHealth.ToString());
    }
    public void TakeBuff(BuffObject data)
    {
        if(data.speedLvL != 0)
        {
            SpeedUp(data.speedLvL);
        }
        if (data.damageLvL != 0)
        {
            DamageUp(data.damageLvL);
        }
        if (data.attackSpeedLvl != 0)
        {
            AttackSpeedUp(data.attackSpeedLvl);
        }
        if (data.maxHealthLvL != 0)
        {
            MaxHealthUp(data.maxHealthLvL);
        }
    }
    
}
