using UnityEngine;

public class BasicEnemyHitTrigger : HitTrigger
{
    public float MaxHp = 10;
    public float hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
