using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float enemyHealth = 100;
    int enemyCount = 0;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.2f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        enemyCount++;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FPSController")
        {
            Debug.Log("Zombie toca al player");
            animator.SetTrigger("Pegar");
        }
    }
}
