using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ZombieType", menuName ="Zombie")]
public class ZombieType : ScriptableObject
{
    public int Health;

    public int Damage;

    public Sprite Sprite;

    public Sprite DeathSprite;


}
