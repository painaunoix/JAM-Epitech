using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public CharacterController characterController;

    private void Start()
    {
        if (!audioSource)
            audioSource = GetComponent<AudioSource>();

        if (!characterController)
            characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.Play();
            }
        }
    }
}
