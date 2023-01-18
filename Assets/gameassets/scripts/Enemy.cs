using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int startHealth = 5;
    private float health;

    public int value = 50;

    public GameObject deathEffect;

    public Image healthBar;

    private bool IsDead = false;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = waypoints.points[0];
        health = startHealth;
    }

    public void TakeDamage (int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !IsDead)
        {
            Die();

        }
    }

    void Die()
    {
        IsDead = true;

        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        Wave_Spawner.EnemiesAlive--;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
        transform.LookAt(target);
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }
    
    void GetNextWaypoint()
    {
        if(wavepointIndex >= waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Wave_Spawner.EnemiesAlive--;
        Destroy(gameObject);

    }

}
