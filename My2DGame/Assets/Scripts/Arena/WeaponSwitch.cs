using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject gun;
    public GameObject gun2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(gun.activeInHierarchy == true)
            {
                gun.SetActive(false);
                gun2.SetActive(true);
            }
            else if (gun2.activeInHierarchy == true)
            {
                gun2.SetActive(false);
                gun.SetActive(true);
            }
        }
    }
}
