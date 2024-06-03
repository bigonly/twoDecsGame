using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenURL : MonoBehaviour
{
    public string url = "https://www.donationalerts.com/r/3mp3r0r_3";

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OpenLink);
        }
    }

    public void OpenLink()
    {
        Application.OpenURL(url);
    }
}
