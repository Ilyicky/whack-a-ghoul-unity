using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GhoulSpawner : MonoBehaviour
{
    [Header ("Ghouls")]
    [SerializeField] private GameObject[] ghoul;

    [Header ("Graves")]
    [SerializeField] private Transform gravesParent;
    private Transform[] graves;

    [Header ("Spawner Values")]
    [SerializeField] private float spawnInterval;
    //[SerializeField] private float ghoulLifeTime = 1.0f;

    [Header ("Game Manager")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int ghoulSpawnsPerSec = 1;

    private GhoulParticleFx ghoulParticleFx;

    void Start()
    {
        ghoulParticleFx = GetComponent<GhoulParticleFx>();
    }

    public float GhoulSpawnsPerSec 
    {
        set 
        {
            this.ghoulSpawnsPerSec = (int)value;

            //adjust spawnInterval based on the ghoulSpawnsPerSec value
            if (ghoulSpawnsPerSec == 1 || ghoulSpawnsPerSec == 2)
            {
                spawnInterval = Random.Range(2.5f, 3f); // Set interval for Easy and Intermediate (1 or 2 ghouls per sec)
            }
            else if (ghoulSpawnsPerSec == 3)
            {
                spawnInterval = Random.Range(1.5f, 2f); // Set interval for Hard (3 ghouls per sec)
            }
        }
    }


    public void StartSpawn()
    {
        //add the 15 graves in the array
        graves = new Transform[gravesParent.childCount];
        for (int i = 0; i < gravesParent.childCount; i++)
        {
            graves[i] = gravesParent.GetChild(i);
        }
        StartCoroutine(SpawnGhoulOnDifficulty());
    }

    private IEnumerator SpawnGhoulOnDifficulty()
    {
        while (gameManager.IsGameActive)  // Infinite loop for continuous spawning
        {
            List<Transform> unoccupiedGraves = new List<Transform>();
            foreach (Transform grave in graves)
            {
                // int spawned = 0;
                bool isOccupied = false;

                // Check how many ghouls are already in this grave
                foreach (Transform child in grave)
                {
                    if (child.CompareTag("Vampire") || child.CompareTag("Zombie") || child.CompareTag("Skeleton"))
                    {
                        isOccupied = true;
                        break;
                    }
                }
            
                if (!isOccupied)
                {
                    unoccupiedGraves.Add(grave);
                }
            }
            
            int ghoulsToSpawn = Mathf.Clamp(ghoulSpawnsPerSec, 1, 3);

            if (unoccupiedGraves.Count >=  ghoulsToSpawn)
            {
                for (int i = 0; i < ghoulsToSpawn; i++)
                {
                    int randomIndex = Random.Range(0, unoccupiedGraves.Count);
                    Transform selectedGrave = unoccupiedGraves[randomIndex];

                    // Instantiate a ghoul at the selected grave
                    SpawnGhoul(selectedGrave);

                    // Remove the selected grave from the list to avoid selecting it again
                    unoccupiedGraves.RemoveAt(randomIndex);
                }
            }
            else
            {
                Debug.LogWarning("Not enough unoccupied graves to spawn the desired number of ghouls.");
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnGhoul(Transform grave)
    {
        int randomIndex = Random.Range(0, ghoul.Length);
        GameObject spawnedGhoul = Instantiate(
            ghoul[randomIndex],
            new Vector3(grave.position.x - 0.15f, grave.position.y - 0.6f, grave.position.z),  // Offset for proper centering
            Quaternion.Euler(0, 180, 0)  // Flip the ghoul for correct orientation
        );
        spawnedGhoul.transform.SetParent(grave);
        //ghoulParticleFx.PlayGhoulAppearPFX();
        //Destroy(spawnedGhoul, ghoulLifeTime);  // Destroy after certain lifetime

    }
}


