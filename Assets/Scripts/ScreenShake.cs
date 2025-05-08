using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;   // Increased for better visibility
    public float shakeMagnitude = 0.4f;  // Increased for better visibility

    private Vector3 originalPos;
    private float currentShakeTime = 0f;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (currentShakeTime > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeMagnitude;
            currentShakeTime -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPos;
            originalPos = transform.localPosition; // Update base position if camera moves
        }
    }

    public void TriggerShake()
    {
        currentShakeTime = shakeDuration;
    }
}
