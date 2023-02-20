using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemy/Attributes")]
public class EnemyAttributesObject : ScriptableObject
{
    [Header("Status")]
    public float maxHealth;
    public float health;
    public float speed;
    public float distanceVision;
    public float offset;
    public float movement;

    [Header("Components")]
    public RuntimeAnimatorController anim;
    public GameObject Player;
    public Transform[] points;

    [Header("Dash")]
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    [Header("Checks")]
    public bool right;
    public bool spot;
    public int startPoint;
    public int nowPoint;
    public bool reverse;
    public bool canMove;

    [Header("Meele Weapon")]
    public float attackTime;
    public float meeleDamage;
    public float attackCooldown;

    [Header("Ranged Weapon")]
    public float shootCooldown;
    public float startShootCooldown;
    public float returnSpeed;
}
