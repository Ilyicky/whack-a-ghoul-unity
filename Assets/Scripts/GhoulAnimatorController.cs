using UnityEngine;

public class GhoulAnimatorController : MonoBehaviour
{
    private Animator ghoulAnimator;
    private GhoulStates states;

    void Awake()
    {
        states = GetComponent<GhoulStates>();
    }

    private void OnEnable()
    {
        states.ghoulHit += HitAnimation;
    }

    private void OnDisable()
    {
        states.ghoulHit -= HitAnimation;
    }

    void Start()
    {
        ghoulAnimator = GetComponent<Animator>();
    }

    private void HitAnimation()
    {
        ghoulAnimator.SetBool("die_t", true);
    }
}
