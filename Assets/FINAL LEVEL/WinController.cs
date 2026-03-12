using UnityEngine;

public class WinController : MonoBehaviour
{
    public float ShakeDuration = 10;
    public float ShakeStrength = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinalScreenShake()
    {
        CameraShake.ScreenShake(ShakeDuration, ShakeStrength, 0);
    }
}
