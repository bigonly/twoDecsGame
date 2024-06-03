using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Используйте нужную вам клавишу для паузы
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Замораживаем время
            // Дополнительные действия при паузе, например, отображение меню паузы
        }
        else
        {
            Time.timeScale = 1f; // Возобновляем время
            // Дополнительные действия при возобновлении игры
        }
    }
}
