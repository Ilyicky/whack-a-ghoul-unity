using UnityEngine;

public class GhoulSfx : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip deathSfx;
    [SerializeField] private float volume = 1f;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayDeathSfx()
    {
        audioSource.PlayOneShot(deathSfx, volume);
    }
}
