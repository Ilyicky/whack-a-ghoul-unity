using UnityEngine;

public class GhoulHandler : MonoBehaviour
{
    [SerializeField] private int skeletonValue = 1;
    [SerializeField] private int vampireValue = 3;
    [SerializeField] private int zombieValue = 5;
    private GhoulSfx ghoulSfx;
    private Animator ghoulAnimator;
    private GameManager gameManager;
    private GhoulParticleFx ghoulParticleFx;

    void Start()
    {
        ghoulSfx = GetComponent<GhoulSfx>();
        ghoulParticleFx = GetComponent<GhoulParticleFx>();
        ghoulAnimator = GetComponent<Animator>();
        gameManager =   GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnMouseDown()
    {
        //if gameover, dont process the clicks
        if (!gameManager.IsGameActive) return;

        //if game is on, 
        switch (gameObject.tag)
        {
            case "Skeleton":
                Debug.Log("Skeleton destroyed!");
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>()?.UpdateScore(skeletonValue);

                break;

            case "Vampire":
                Debug.Log("Vampire destroyed!");
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>()?.UpdateScore(vampireValue);
                break;

            case "Zombie":
                Debug.Log("Zombie destroyed!");
                 GameObject.Find("ScoreManager").GetComponent<ScoreManager>()?.UpdateScore(zombieValue);
                break;
        }
        DestroyGhoul();
    }

    private void DestroyGhoul()
    {
        Destroy(gameObject, 1.0f);
        ghoulSfx.PlayDeathSfx();
        ghoulParticleFx.PlayWhackPFX();
        ghoulAnimator.SetTrigger("die_t");
    }
}
