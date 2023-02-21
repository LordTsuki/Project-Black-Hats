using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class CannonShot : MonoBehaviour
{
    [Header("Components")]
    public GameObject destroyEffect;
    public PlayerAttributesObject status;

    private void Start()
    {
        Invoke("DestroyProjectile", status.shootLifeTime);
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, status.shootRayDistance, status.shootLayerCollider);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyReceiveDamage>().TakeDamage(status.shootDamage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * status.shootSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, transform.up * status.shootRayDistance);
    }

    void DestroyProjectile()
    {
        Vector2 destroyDir = transform.position - destroyEffect.transform.position;
        float angle = Mathf.Atan2(destroyDir.y, destroyDir.x) * Mathf.Rad2Deg;
        destroyEffect.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Instantiate(destroyEffect, transform.position, destroyEffect.transform.rotation);
        Destroy(gameObject);
    }
}