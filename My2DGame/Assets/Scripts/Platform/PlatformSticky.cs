using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSticky : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
