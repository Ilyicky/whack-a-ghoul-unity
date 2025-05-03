using UnityEngine;

public class GhoulSfx : MonoBehaviour
{
    private AudioSource audioSource;
    private GhoulStates states;
    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioClip disappearSfx;
    [SerializeField] private float volume = 1f;

    void Awake()
    {
        states = GetComponent<GhoulStates>();
    }

    private void OnEnable()
    {
        states.ghoulHit += PlayHitSfx;
        states.ghoulDisappear += PlayDisappearSfx;
    }

    private void OnDisable()
    {
        states.ghoulHit -= PlayHitSfx;
        states.ghoulDisappear -= PlayDisappearSfx;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayHitSfx()
    {
        audioSource.PlayOneShot(hitSfx, volume);    
    }
    private void PlayDisappearSfx()
    {
        audioSource.PlayOneShot(disappearSfx, volume);
    }
}
