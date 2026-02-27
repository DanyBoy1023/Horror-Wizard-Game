using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public bool shaketrue;
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public float shakeDiminish = .3f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            //camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos + Random.insideUnitSphere * shakeAmount, Time.deltaTime * 3);

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else if (shakeAmount > 0)
        {
            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos + Random.insideUnitSphere * shakeAmount, Time.deltaTime * 3);
            shakeAmount -= Time.deltaTime * shakeDiminish;
        }
        else
        {
            shakeDuration = 0f;
            //camTransform.localPosition = originalPos;
            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos, Time.deltaTime * 3);
        }
    }
    public void shakecamera(float _shakeDuration, float _shakeAmount, float _shakeDiminish)
    {
        shaketrue = true;
        shakeDuration = _shakeDuration;
        shakeAmount = _shakeAmount;
        shakeDiminish = _shakeDiminish;
    }
}