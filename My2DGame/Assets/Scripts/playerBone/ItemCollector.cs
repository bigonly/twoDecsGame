using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bone = 0;

    [SerializeField] private Text boneText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bone"))
        {
            Destroy(collision.gameObject);
            bone++;
            boneText.text = "Костей: " + bone;
        }
    }
}