using UnityEngine;

public class GhoulParticleFx : MonoBehaviour
{
    private GhoulStates states;
    [SerializeField] private ParticleSystem whackParticleFx;
    [SerializeField] private ParticleSystem appearParticleFx;
    [SerializeField] private ParticleSystem disappearParticleFx;

    void Awake()
    {
        states = GetComponent<GhoulStates>();
    }

    public void OnEnable()
    {
        states.ghoulHit += PlayWhackPFX;
        states.ghoulAppear += PlayGhoulAppearPFX;
        states.ghoulDisappear += PlayGhoulDisappearPFX;
    }

    public void OnDisable()
    {
        states.ghoulHit -= PlayWhackPFX;
        states.ghoulAppear -= PlayGhoulAppearPFX;
        states.ghoulDisappear -= PlayGhoulDisappearPFX;
    }

    private void PlayWhackPFX()
    {
        whackParticleFx.Play();
    }

    public void PlayGhoulAppearPFX()
    {
        appearParticleFx.Play();
    }
    
    private void PlayGhoulDisappearPFX()
    {
        disappearParticleFx.Play();
    }
    
}
