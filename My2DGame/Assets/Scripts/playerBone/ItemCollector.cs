using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private static int bone = 0; // ������� ���������� �����������

    public GameObject sound;
    public Animator boneTAnim;

    [SerializeField] private Text boneText;

    private void Start()
    {
        boneTAnim = GameObject.FindGameObjectWithTag("Bonetext").GetComponent<Animator>();
        boneText.text = "������: " + bone; // ���������� �������� ��� ������ �������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boneTAnim.SetTrigger("taked");
            Instantiate(sound, transform.position, Quaternion.identity);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            bone++;
            boneText.text = "������: " + bone;
        }
    }
}
