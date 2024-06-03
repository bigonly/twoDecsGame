using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Вызывается при нажатии кнопки
    public void ExitGame()
    {
        // Завершаем игру (работает только в сборке приложения, не в редакторе)
        Application.Quit();
    }
}
