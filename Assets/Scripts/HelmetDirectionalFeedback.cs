using UnityEngine;
using TMPro;

public class HelmetDirectionalFeedback : MonoBehaviour
{
    public Transform helmetCamera;
    public float detectionRange = 3f;
    public float sphereRadius = 0.5f;
    public TextMeshProUGUI statusText;

    void Update()
    {
        if (helmetCamera == null || statusText == null) return;

        Vector3 origin = helmetCamera.position + Vector3.up * 0.2f; // lift slightly for head level
        Vector3 forward = helmetCamera.forward;
        Vector3 left = Quaternion.Euler(0, -90, 0) * forward;
        Vector3 right = Quaternion.Euler(0, 90, 0) * forward;

        string result = "Helmet Status: Clear";

        if (Physics.SphereCast(origin, sphereRadius, forward, out RaycastHit hitF, detectionRange))
        {
            if (hitF.distance < 1.5f)
                result = "⚠ Obstacle in Front!";
        }
        else if (Physics.SphereCast(origin, sphereRadius, left, out RaycastHit hitL, detectionRange))
        {
            if (hitL.distance < 1.5f)
                result = "⚠ Obstacle on Left!";
        }
        else if (Physics.SphereCast(origin, sphereRadius, right, out RaycastHit hitR, detectionRange))
        {
            if (hitR.distance < 1.5f)
                result = "⚠ Obstacle on Right!";
        }

        statusText.text = result;

        // Debug draw for development
        Debug.DrawRay(origin, forward * detectionRange, Color.red);
        Debug.DrawRay(origin, left * detectionRange, Color.green);
        Debug.DrawRay(origin, right * detectionRange, Color.blue);
    }
}
