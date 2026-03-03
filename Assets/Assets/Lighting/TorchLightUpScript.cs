using UnityEngine;

public class TorchLightUpScript : HitTrigger
{
    public Light torch_light;
    public bool on = true;

    private void Start()
    {
        UpdateLight();
    }

    private void Update()
    {
        UpdateLight();
    }

    public override void Hit(float damage, SpellHitDetection.StatusTypes statusEffect)
    {
        if (statusEffect == SpellHitDetection.StatusTypes.Fire)
        {
            on = true;
            UpdateLight();
        }
    }

    public void UpdateLight()
    {
        if (torch_light != null)
        {
            torch_light.enabled = on;
        }
    }
}
