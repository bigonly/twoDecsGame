using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterTrigger : MonoBehaviour
{
    private GameObject hatInstance; // Ссылка на созданный экземпляр шапки

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Получаем скрипт персонажа
            PlayerAnim playerAnim = collision.GetComponent<PlayerAnim>();
            if (playerAnim != null && playerAnim.hatPrefab != null)
            {
                // Получаем объект визуального элемента, представляющий голову персонажа
                GameObject headObject = playerAnim.headObject; // Предполагается, что у вас есть публичное поле headObject в скрипте PlayerAnim, куда вы можете присвоить этот объект в редакторе Unity

                if (headObject != null)
                {
                    // Создаем экземпляр шапки
                    hatInstance = Instantiate(playerAnim.hatPrefab, headObject.transform.position, Quaternion.identity);

                    // Делаем шапку дочерним объектом головы персонажа
                    hatInstance.transform.parent = headObject.transform;
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hatInstance != null)
        {
            // Удаляем шапку, если она есть
            Destroy(hatInstance);
        }
    }
}
