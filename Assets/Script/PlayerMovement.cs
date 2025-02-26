using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float sprintSpeed = 18f;
    public float gravity = -30f;
    public float jumpHeight = 3f;
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public CharacterController characterController;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask telekMask;

    Vector3 velocity;
    bool isGrounded;
    bool isMoving;
    public Slider volumeSlider;

    public Animator animator;

    public GameObject playerModel;


    void Start()
    {
        if (!audioSource)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask) || Physics.CheckSphere(groundCheck.position, groundDistance, telekMask))
            isGrounded = true;
        else
            isGrounded = false;
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
            animator.SetBool("isFalling", false);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        isMoving = move != Vector3.zero;
        animator.SetBool("isMoving", isMoving);

        if (isMoving && isGrounded) {
            animator.SetFloat("speed", Input.GetKey(KeyCode.LeftShift) ? 1f : 0.5f);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
            animator.SetFloat("speed", 0f);
        }


        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("isJumping", true);
        }

        if (!isGrounded && velocity.y < 0) {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}