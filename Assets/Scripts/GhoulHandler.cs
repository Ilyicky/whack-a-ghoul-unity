using UnityEngine;

public class GhoulHandler : MonoBehaviour
{
    private GhoulSfx ghoulSfx;
    private Animator ghoulAnimator;
    // Update is called once per frame
    void Start()
    {
        ghoulSfx = GetComponent<GhoulSfx>();
        ghoulAnimator = GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        switch (gameObject.tag)
        {
            case "Skeleton":
                Debug.Log("Skeleton destroyed!");
                break;

            case "Vampire":
                Debug.Log("Vampire destroyed!");
                break;

            case "Zombie":
                Debug.Log("Zombie destroyed!");
                break;
        }

        Destroy(gameObject, 1.0f);
        ghoulSfx.PlayDeathSfx();
        ghoulAnimator.SetTrigger("die_t");
    }
}
