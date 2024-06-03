using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterTrigger : MonoBehaviour
{
    private GameObject hatInstance; // ������ �� ��������� ��������� �����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �������� ������ ���������
            PlayerAnim playerAnim = collision.GetComponent<PlayerAnim>();
            if (playerAnim != null && playerAnim.hatPrefab != null)
            {
                // �������� ������ ����������� ��������, �������������� ������ ���������
                GameObject headObject = playerAnim.headObject; // ��������������, ��� � ��� ���� ��������� ���� headObject � ������� PlayerAnim, ���� �� ������ ��������� ���� ������ � ��������� Unity

                if (headObject != null)
                {
                    // ������� ��������� �����
                    hatInstance = Instantiate(playerAnim.hatPrefab, headObject.transform.position, Quaternion.identity);

                    // ������ ����� �������� �������� ������ ���������
                    hatInstance.transform.parent = headObject.transform;
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hatInstance != null)
        {
            // ������� �����, ���� ��� ����
            Destroy(hatInstance);
        }
    }
}
