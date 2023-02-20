using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Player/Attributes")]
public class PlayerAttributesObject : ScriptableObject
{
    [Header("Status")]
    public float maxHealth;
    public float health;
    public float speed;
    public float movement;

    [Header("Jump")]
    public float jumpForce;
    public float doubleJumpForce;
    public float groundDistance;
    public float wallJumpForce;
    public float wallCheckDistance;
    public float jumpDiagonalFactor;
    public float wallJumpTime;
    public float wallJumpCooldown;
    public LayerMask wallLayerCollider;
    public LayerMask jumpLayerCollider;
    public Vector3[] footOffset;

    [Header("Components")]
    public RuntimeAnimatorController anim;
    public GameObject _cam;

    [Header("Dash")]
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    [Header("Checks")]
    public bool right;
    public bool left;
    public bool isGrounded;
    public bool isSliding;
    public bool controller;
    public bool dashing;
    public bool canDash;
    public int weapon;
    public bool doubleJump;
    public bool leftWallCheck;
    public bool rightWallCheck;
    public bool isWallJumping;

    [Header("Meele Weapon")]
    public float attackTime;
    public float meeleDamage;
    public float attackCooldown;
    public float firstHit;
    public float secondHit;
    public float thirdHit;

    [Header("Cannon")]
    public float shootSpeed;
    public float shootLifeTime;
    public float shootRayDistance;
    public float shootDamage;
    public LayerMask shootLayerCollider;
    public float particleDestroyCooldown;
    public float particleDestroy;
    public float shootCooldown;
    public float shootActuallyCooldown;
}