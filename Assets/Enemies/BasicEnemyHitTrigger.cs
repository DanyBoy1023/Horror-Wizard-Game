using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyHitTrigger : HitTrigger
{
    public float MaxHp = 10;
    public float hp;
    public Slider hpSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = MaxHp;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpSlider != null)
        {
            hpSlider.gameObject.transform.LookAt(GameObject.FindWithTag("Player").transform);
        }
    }

    public override void Hit(float damage, SpellHitDetection.StatusTypes statusEffect)
    {
        //base.Hit(damage, statusEffect);

        DealDamage(damage);
    }

    public void DealDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void UpdateHealthBar()
    {
        if (hpSlider != null)
        {
            hpSlider.value = Mathf.Clamp01(hp/MaxHp);
            if (hpSlider.value >= 1)
            {
                hpSlider.gameObject.SetActive(false);
            }
            else
            {
                hpSlider.gameObject.SetActive(true);
            }
            
        }
    }
}
