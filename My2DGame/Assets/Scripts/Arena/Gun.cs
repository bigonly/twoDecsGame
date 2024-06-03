using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform[] shotPoints;  // Массив точек для выстрелов

    private float timeBtwShots;
    public float starttimeBtwShots;

    public GameObject[] sounds;
    public Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("Virtual Camera").GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots < 0)
        {
            if (Input.GetMouseButton(0))
            {
                camAnim.SetTrigger("shake");
                int rand = Random.Range(0, sounds.Length);
                Instantiate(sounds[rand], transform.position, Quaternion.identity);
                foreach (Transform shotPoint in shotPoints)
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                }
                timeBtwShots = starttimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
