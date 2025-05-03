using UnityEngine;
using System.Collections;

public class GhoulHandler : MonoBehaviour
{
    [Header ("Zombie Values")]
    [SerializeField] private int skeletonValue = 1;
    [SerializeField] private int vampireValue = 3;
    [SerializeField] private int zombieValue = 5;

    [Header ("Death and Fall Values")]
    [SerializeField] private float deathTimer = 5f; //time before zombie goes back to the ground (disappear)
    [SerializeField] private float timeAlive = 0f;
    [SerializeField] private float fallSpeed = 9.81f; //speed of falling

    private GameManager gameManager;
    private GhoulStates states;

    void Awake()
    {
        states = GetComponent<GhoulStates>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        timeAlive += Time.deltaTime;
        //destroy zombie if not whacked within the death timer
        if (timeAlive >= deathTimer && !states.IsDisappearing && !states.IsHit)
        {
            states.IsDisappearing = true;
            states.ghoulDisappear.Invoke();
            StartCoroutine(WaitAndDestroy());
        }

    }

    void OnMouseDown()
    {
        //if gameover, dont process the clicks
        if (!gameManager.IsGameActive) return;

        //if game is on, 
        if (!states.IsDisappearing && !states.IsHit) //if the zombie is going back to the ground || on the ground it can't be hit
        {
            switch (gameObject.tag)
            {
                case "Skeleton":
                    //Debug.Log("Skeleton destroyed!");
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>()?.UpdateScore(skeletonValue);

                    break;

                case "Vampire":
                    //Debug.Log("Vampire destroyed!");
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>()?.UpdateScore(vampireValue);
                    break;

                case "Zombie":
                    //Debug.Log("Zombie destroyed!");
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>()?.UpdateScore(zombieValue);
                    break;
            }
            DestroyGhoul();
        }
    }

    private void DestroyGhoul()
    {
        Destroy(gameObject, 1f);
        states.ghoulHit.Invoke();
        states.IsHit = true;
    }

    private IEnumerator WaitAndDestroy()
    {
        //wait for 1second before the fall to play animation and sound
        yield return new WaitForSeconds(1f);

        //gradually move the ghoul (fall)
        while (transform.position.y > -20f)  //keep falling until -20f then destroy
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
