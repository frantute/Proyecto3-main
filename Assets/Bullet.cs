using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int bulletDamage;
    bool colision = false;
    public LayerMask whatIsEnemies;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += transform.up * speed;
        
        if (colision == true)
        {
            RecibirDaño();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            RecibirDaño();
        }
    }

    private void RecibirDaño()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, whatIsEnemies);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemigo>().TakeDamage(bulletDamage);
        }

        Invoke("Delay", 0.05f);
    }
}
