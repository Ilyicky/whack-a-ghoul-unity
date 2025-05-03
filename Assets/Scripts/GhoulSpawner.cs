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

    [Header ("Game Manager")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int ghoulSpawnsPerSec = 1;

    private GhoulParticleFx ghoulParticleFx;

    public float GhoulSpawnsPerSec 
    {
        set 
        {
            this.ghoulSpawnsPerSec = (int)value;

            //adjust spawnInterval based on the ghoulSpawnsPerSec value
            if (ghoulSpawnsPerSec == 1 || ghoulSpawnsPerSec == 2)
            {
                spawnInterval = Random.Range(2.5f, 3f); //time interval for easay and intermediate difficulty
            }
            else if (ghoulSpawnsPerSec == 3)
            {
                spawnInterval = Random.Range(1.5f, 2f); //time interval for hard difficulty
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
        while (gameManager.IsGameActive) //as long as game is active, continue spawning
        {
            List<Transform> unoccupiedGraves = new List<Transform>();
            foreach (Transform grave in graves)
            {
                // int spawned = 0;
                bool isOccupied = false;

                //check how many ghouls in the grave
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

                    //instantiate a ghoul in a grave
                    SpawnGhoul(selectedGrave);

                    //remove the selected grave to the list of unoccupied graves
                    unoccupiedGraves.RemoveAt(randomIndex);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnGhoul(Transform grave)
    {
        int chance = Random.Range(0, 100);
        int selectedIndex; 

        if (chance < 60)
        {
            selectedIndex = 0;
        }
        else if (chance < 90)
        {
            selectedIndex = 1; 
        }
        else
        {
            selectedIndex = 2;
        }

        GameObject spawnedGhoul = Instantiate(
            ghoul[selectedIndex],
            new Vector3(grave.position.x - 0.15f, grave.position.y - 0.6f, grave.position.z),  //center the zombie in the grave
            Quaternion.Euler(0, 180, 0)  //to make the zombie face front
        );
        spawnedGhoul.transform.SetParent(grave);
        ghoulParticleFx = spawnedGhoul.GetComponent<GhoulParticleFx>();
        ghoulParticleFx.PlayGhoulAppearPFX();
    }
}


