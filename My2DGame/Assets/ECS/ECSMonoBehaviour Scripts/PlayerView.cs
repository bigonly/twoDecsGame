using Leopotam.Ecs;
using UnityEngine;


public class PlayerView : MonoBehaviour
{
    public GameObject[] sounds;
    public GameObject[] soundss;
    public Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("Virtual Camera").GetComponent<Animator>();
    }

    public EcsEntity entity;
    public void Shoot()
    {
        entity.Get<HasWeapon>().weapon.Get<Shoot>();
        camAnim.SetTrigger("shake");
        int rand = Random.Range(0, sounds.Length);
        Instantiate(sounds[rand], transform.position, Quaternion.identity);
    }
    public void Reload()
    {
        int rand = Random.Range(0, soundss.Length);
        Instantiate(soundss[rand], transform.position, Quaternion.identity);
        entity.Get<HasWeapon>().weapon.Get<ReloadingFinished>();
    }
}
