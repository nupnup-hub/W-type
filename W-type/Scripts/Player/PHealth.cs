using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PHealth : PlaneEntity
{
    public Slider healthSlider;
    private PMovement playerMovement;
    private PAction pAction;

    private bool attacked;
    public GameObject alien1;
    private NoDamage noDamage;

    private void Awake()
    {
        playerMovement = GetComponent<PMovement>();
        pAction = GetComponent<PAction>();
        noDamage = alien1.GetComponent<NoDamage>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();

        // 체력 슬라이더 활성화
        healthSlider.gameObject.SetActive(true);
        // 체력 슬라이더의 최대값을 기본 체력값으로 변경
        healthSlider.maxValue = startHealth;
        // 체력 슬라이더의 값을 현재 체력값으로 변경
        healthSlider.value = health;

        playerMovement.enabled = true;
        pAction.enabled = true;
        attacked = false;
    }

    // Update is called once per frame
    public override void OnDamage(float damage)
    {
        if (attacked == false)
        {
            base.OnDamage(damage);
            healthSlider.value = health;
            attacked = true;
            if(!dead)
            StartCoroutine(NDamage());
        }
    }

    public override void Die()
    {
        StopCoroutine(NDamage());
        base.Die();
        healthSlider.gameObject.SetActive(false);
        playerMovement.enabled = false;
        pAction.enabled = false;
        healthSlider.value = health;
        gameObject.SetActive(false);
    }

    public override void RestoreHealth(float newHealth)
    {
        base.RestoreHealth(newHealth);
        healthSlider.value = health;
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag != "Item")
            return;
        
        if (!dead)
        { 
            Item item = other.GetComponent<Item>();

            if (item != null)
            {
                item.Use(gameObject);
                //playerAudioPlayer.PlayOneShot(itemPickupClip);
            }
        }
    }
    private IEnumerator NDamage()
    {
        if (!dead)
        {
            int count = 0;
            while (count < 11)
            {
                noDamage.NoDamageTime(count);
                yield return new WaitForSeconds(0.15f);
                count++;
            }

            attacked = false;
            yield return null;
        }
    }
}
