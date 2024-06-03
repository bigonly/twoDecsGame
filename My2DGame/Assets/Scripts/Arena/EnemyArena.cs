using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArena : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public GameObject deathEffect;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private PlayerAnim2 player;
    private Animator anim;
    private ScoreManagerArena sm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerAnim2>();
        normalSpeed = speed;
        sm = FindObjectOfType<ScoreManagerArena>();
    }

    private void Update()
    {
        if(stopTime <= 0) 
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime; 
        }
        if (health <= 0)
        {
            sm.Kill();
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("PlayerAnim2"))
        {
            if(timeBtwAttack <= 0) 
            {
                anim.SetTrigger("enemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
