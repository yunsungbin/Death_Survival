using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate;
    public static float plusdamage;
    public static float powerplus;

    public void Init(ItemData data)
    {
        name = "Gear" + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        type = data.itemType;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
            case ItemData.ItemType.Bullet:
                GunDamageUp();
                break;
            case ItemData.ItemType.Power:
                PowerUp();
                break;
        }
    }

    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    float speed = 150 * Character.WeaponSpeed;
                    weapon.speed = speed + (speed * rate);
                    break;
                default:
                    speed = 0.5f * Character.WeaponRate;
                    weapon.speed = speed * (1f - rate);
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 3 * Character.Speed;
        GameManager.instance.player.Speed = speed + speed * rate;
    }

    void GunDamageUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();
        

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 1:
                    float damage = 3 * Character.Damage;
                    plusdamage = damage * rate;
                    break;
            }
        }
    }

    void PowerUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();


        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    float damage = 3 * Character.Damage;
                    powerplus = damage * rate;
                    break;
            }
        }
    }
}
