using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    public GameObject sound;

    public Animator camAnim;
    public Animator TAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        TAnim = GameObject.FindGameObjectWithTag("Bonetext").GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            TAnim.SetTrigger("tak");
            camAnim.SetTrigger("shake");
            Instantiate(sound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<PlayerRun>().health -= damage;
            Destroy(gameObject);
        }
    }
}
