using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public float enemyHealth = 100;
    int enemyCount = 0;
    public NavMeshAgent agent;
    public Animator animator;

    public bool spawneando = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Esperar());
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

    IEnumerator Esperar()
    {
        Debug.Log("spawnea");
        agent.speed = 0;
        yield return new WaitForSeconds(3);
        Debug.Log("termino spawn");
        agent.speed = 3.5f;

    }
}
