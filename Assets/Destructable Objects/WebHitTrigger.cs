using UnityEngine;

public class WebHitTrigger : HitTrigger
{
    public override void Hit(float damage, SpellHitDetection.StatusTypes statusEffect)
    {
        if (statusEffect == SpellHitDetection.StatusTypes.Fire)
        {
            Destroy(gameObject);
        }
    }
}
