using UnityEngine;

public class GhoulParticleFx : MonoBehaviour
{
    [SerializeField] private ParticleSystem whackParticleFx;
    [SerializeField] private ParticleSystem appearParticleFx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayWhackPFX()
    {
         whackParticleFx.Play();
    }

    public void PlayGhoulAppearPFX()
    {
        appearParticleFx.Play();
    }
}
