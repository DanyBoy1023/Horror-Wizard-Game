using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public float ShakeDuration = 10;
    public float ShakeStrength = 5;

    private bool ScreenShaking = false;

    // Update is called once per frame
    void Update()
    {
        if (ScreenShaking)
        {
            CameraShake.ScreenShake(ShakeDuration, ShakeStrength, 0);
        }
    }

    public void FinalScreenShake()
    {
        ScreenShaking = true;
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win Menu");
    }
}
