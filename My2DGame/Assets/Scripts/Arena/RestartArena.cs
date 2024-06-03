using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartArena : MonoBehaviour
{
    public Text score;
    public ScoreManagerArena sm;

    private void Start()
    {
        score.text = ("Не плохо ты набрал: ") + sm.score.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
