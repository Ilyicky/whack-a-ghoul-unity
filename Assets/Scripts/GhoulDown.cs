using System.Collections;
using UnityEngine;

public class GhoulDown : MonoBehaviour
{
    [SerializeField] private float fallDelay = 5f; // Delay before falling
    [SerializeField] private float fallSpeed = 9.81f; // Speed of falling

    private bool isFalling = false;
    private GhoulParticleFx ghoulParticleFx;

    void Start()
    {
        ghoulParticleFx = GetComponent<GhoulParticleFx>();
        StartCoroutine(FallAfterDelay());
    }

    private IEnumerator FallAfterDelay()
    {
        ghoulParticleFx.PlayGhoulAppearPFX();
        yield return new WaitForSeconds(fallDelay);
         // Wait for 5 seconds
        isFalling = true; //start falling
    }

    void Update()
    {
        if (isFalling)
        {
            ghoulParticleFx.PlayGhoulAppearPFX();
            Debug.Log("Ghoul appear particle effect played.");
            // Move the object downwards
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            // Check if the object has fallen below a certain Y position (e.g., -10)
            if (transform.position.y <= -20f) // Adjust this value as needed
            {
                Destroy(gameObject); // Destroy the GameObject
            }
        }
    }
}