using UnityEngine;
using UnityEngine.UI;

public class WebHitTrigger : HitTrigger
{
    public float MaxHp = 10;
    public float hp;
    public Slider hpSlider;

    private void Start()
    {
        UpdateHealthBar();
        hp = MaxHp;
    }

    public override void Hit(float damage, SpellHitDetection.StatusTypes statusEffect)
    {
        if (statusEffect == SpellHitDetection.StatusTypes.Fire)
        {
            hp -= damage;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (hpSlider != null)
        {
            hpSlider.value = Mathf.Clamp01(hp / MaxHp);
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
