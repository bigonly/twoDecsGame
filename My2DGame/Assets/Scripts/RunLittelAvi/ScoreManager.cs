using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public Animator TAnim;

    private void Start()
    {
        TAnim = GameObject.FindGameObjectWithTag("scoretext").GetComponent<Animator>();
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gear"))
        {
            TAnim.SetTrigger("takS");
            score++;
        }
    }
}

