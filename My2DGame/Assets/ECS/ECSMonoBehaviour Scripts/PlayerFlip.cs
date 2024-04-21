using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 1;
        float rotZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        if ((0 > rotZ || 0 < rotZ) && !(-90 < rotZ) || !(90 > rotZ))
        {
            transform.localScale = new Vector3(-1, 1 ,1);
        }
        else if (90 > rotZ || -90 < rotZ)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
