using UnityEngine;
using TMPro;

public class HelmetObstacleDetection : MonoBehaviour
{
    public Transform helmetCamera;
    public float detectionRange = 6f;
    public float closeRange = 2.4f;
    public TextMeshProUGUI statusText;

    private ScreenShake screenShake;

    private bool wasInCloseRange = false;
    private string lastWarningText = "";

    void Start()
    {
        if (helmetCamera != null)
        {
            screenShake = helmetCamera.GetComponent<ScreenShake>();
        }
    }

    void Update()
    {
        if (helmetCamera == null || statusText == null) return;

        Ray ray = new Ray(helmetCamera.position, helmetCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            float distance = hit.distance;
            string obstacleName = hit.collider.gameObject.name;

            // Determine relative position (Left, Right, Center)
            Vector3 localPoint = helmetCamera.InverseTransformPoint(hit.point);
            string direction = "Front";

            if (localPoint.x > 0.3f) direction = "Right";
            else if (localPoint.x < -0.3f) direction = "Left";

            string feedback = "";

            if (distance < closeRange)
            {
                feedback = $"⚠️ Danger! Obstacle VERY close on {direction}: {obstacleName} ({distance:F1}m)";
                if (!wasInCloseRange)
                {
                    wasInCloseRange = true;
                    if (screenShake != null) screenShake.TriggerShake();
                }
            }
            else
            {
                feedback = $"Obstacle on {direction}: {obstacleName} ({distance:F1}m)";
                wasInCloseRange = false;
            }

            // Avoid flickering text
            if (lastWarningText != feedback)
            {
                statusText.text = feedback;
                lastWarningText = feedback;
            }
        }
        else
        {
            string clearMessage = "✅ Helmet Status: Path Clear";
            if (statusText.text != clearMessage)
            {
                statusText.text = clearMessage;
                lastWarningText = clearMessage;
                wasInCloseRange = false;
            }
        }

        // Optional: visualize ray in editor
        Debug.DrawRay(helmetCamera.position, helmetCamera.forward * detectionRange, Color.red);
    }
}
