using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ����������� ������ ��� ������� ��� �����
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // ������������ �����
            // �������������� �������� ��� �����, ��������, ����������� ���� �����
        }
        else
        {
            Time.timeScale = 1f; // ������������ �����
            // �������������� �������� ��� ������������� ����
        }
    }
}
