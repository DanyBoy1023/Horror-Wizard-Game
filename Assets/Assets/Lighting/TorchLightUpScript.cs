using UnityEngine;

public class TorchLightUpScript : HitTrigger
{
    public Light torch_light;


    public override void Hit(float damage, SpellHitDetection.StatusTypes statusEffect)
    {
        if (statusEffect == SpellHitDetection.StatusTypes.Fire)
        {
            TurnOnLight();
        }
    }

    public void TurnOnLight()
    {
        if (torch_light != null && !torch_light.enabled)
        {
            torch_light.enabled = true;
        }
    }
}
