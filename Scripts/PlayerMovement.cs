using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float SprintSpeed;
    public float JumpForce;
    public float RotationSpeed;
    public Transform CameraTransform;
    public Vector3 CameraOffset;
    public float Stamina = 10f; // Keep this line

    private CharacterController CharacterController;
    private Animator animator;
    private bool isSprinting = false; // Keep this line

    void Start()
    {
        animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Camera's forward and right vectors without the vertical component
        Vector3 camForward = CameraTransform.forward;
        Vector3 camRight = CameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Player Movement based on WASD keys in relation to the camera
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the camera
        Vector3 movementDirection = (camForward * verticalInput + camRight * horizontalInput).normalized;

        // Rotate the character to face the direction based on input
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
        else
        {
            // Deactivate "Run" animation when not moving
            animator.SetBool("IsMoving", false);
        }

        // Move the character based on the movement direction relative to the camera
        MoveCharacter(movementDirection);

        // Jumping
        if (CharacterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
            CharacterController.Move(Vector3.up * JumpForce * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        // Sprinting
        if (CharacterController.isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        // Camera Rotation based on Mouse Input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * RotationSpeed * Time.deltaTime);
        CameraTransform.Rotate(Vector3.left * mouseY * RotationSpeed * Time.deltaTime);

        CameraTransform.position = transform.position + CameraOffset;
    }

    // Move the character in the calculated direction
    void MoveCharacter(Vector3 direction)
    {
        float magnitude = isSprinting ? direction.magnitude * SprintSpeed : direction.magnitude * Speed;
        CharacterController.SimpleMove(direction * magnitude);
    }
}
