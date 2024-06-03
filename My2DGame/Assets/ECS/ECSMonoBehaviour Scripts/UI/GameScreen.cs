using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour // явно унаследуемс€ от MonoBehaviour
{
    [SerializeField] private Text currentInMagazineLabel;
    [SerializeField] private Text totalAmmoLabel;
    [SerializeField] private Text currentHealth;

    public Animator boneTAnim;

    private void Awake()
    {
        boneTAnim = GameObject.FindGameObjectWithTag("HP").GetComponent<Animator>();

        // ”бедитесь, что вы назначили эти ссылки в инспекторе Unity.
        if (currentInMagazineLabel == null)
        {
            currentInMagazineLabel = GameObject.Find("CurrentInMagazineLabel")?.GetComponent<Text>();
            if (currentInMagazineLabel == null)
                Debug.LogError("CurrentInMagazineLabel object not found or does not have a Text component.");
        }

        if (totalAmmoLabel == null)
        {
            totalAmmoLabel = GameObject.Find("TotalAmmoLabel")?.GetComponent<Text>();
            if (totalAmmoLabel == null)
                Debug.LogError("TotalAmmoLabel object not found or does not have a Text component.");
        }

        if (currentHealth == null)
        {
            currentHealth = GameObject.Find("CurrentHealth")?.GetComponent<Text>();
            if (currentHealth == null)
                Debug.LogError("CurrentHealth object not found or does not have a Text component.");
        }
    }

    public void SetAmmo(int current, int total)
    {
        if (currentInMagazineLabel != null && totalAmmoLabel != null)
        {
            currentInMagazineLabel.text = current.ToString();
            totalAmmoLabel.text = total.ToString();
        }
        else
        {
            Debug.LogError("UI Text components are not assigned.");
        }
    }

    public void SetAmmo(int total)
    {
        if (totalAmmoLabel != null)
        {
            totalAmmoLabel.text = total.ToString();
        }
        else
        {
            Debug.LogError("Total Ammo Label is not assigned.");
        }
    }

    public void SetHealth(float current)
    {
        if (currentHealth != null)
        {
            boneTAnim.SetTrigger("taked");
            currentHealth.text = current.ToString();
        }
        else
        {
            Debug.LogError("Current Health Label is not assigned.");
        }
    }
}
