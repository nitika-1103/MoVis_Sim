using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput;

    public Transform helmetCamera;
    private PlayerInput playerInput;
    private InputAction moveAction;

    public TextMeshProUGUI speedText;      // Drag SpeedText in Inspector
    public TextMeshProUGUI statusText;     // Drag StatusText in Inspector

    private bool helmetOn = true; // Initial helmet status

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (helmetCamera == null || controller == null) return;

        // Movement direction based on helmet camera
        Vector3 move = helmetCamera.right * moveInput.x + helmetCamera.forward * moveInput.y;
        move.y = 0f;

        Vector3 horizontalMovement = move.normalized * speed;

        // Move player horizontally
        controller.Move(horizontalMovement * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Calculate and display horizontal speed
        float horizontalSpeed = horizontalMovement.magnitude;
        if (speedText != null)
        {
            speedText.text = $"Speed: {horizontalSpeed:F2} m/s";
        }

        // Toggle helmet ON/OFF using 'H' key
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            helmetOn = !helmetOn;
            if (statusText != null)
            {
                statusText.text = $"Helmet Status: {(helmetOn ? "ON" : "OFF")}";
            }
        }
    }
}
