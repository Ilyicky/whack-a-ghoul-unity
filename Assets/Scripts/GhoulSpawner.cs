using UnityEngine;

public class GhoulSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] ghoul;
    [SerializeField] private Transform gravesParent;
    private Transform[] graves;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float ghoulLifeTime = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //add the 15 graves in the array
        graves = new Transform[gravesParent.childCount];
        for (int i = 0; i < gravesParent.childCount; i++)
        {
            graves[i] = gravesParent.GetChild(i);
        }
        InvokeRepeating("SpawnGhoul", 1f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnGhoul()
    {
        int index = Random.Range(0, graves.Length);
        Transform selectedGrave = graves[index];

        bool isOccupied = false;
        foreach (Transform child in selectedGrave)
        {
            if (child.CompareTag("Vampire") || child.CompareTag("Zombie") || child.CompareTag("Skeleton"))
            {
                isOccupied = true;
                break;
            }
        }
        if (!isOccupied)
        {
            int randomIndex = Random.Range(0, ghoul.Length);
            GameObject spawnedGhoul = Instantiate(ghoul[randomIndex], 
            new Vector3(selectedGrave.position.x -0.15f, selectedGrave.position.y -0.6f, selectedGrave.position.z), //add the offsets in order to center the ghoul
            Quaternion.Euler(0,180,0)); //make the ghoul look front

            spawnedGhoul.transform.SetParent(selectedGrave);
            Destroy(spawnedGhoul, ghoulLifeTime);
            //Debug.Log("Spawned zombie: " + spawnedGhoul.name + " at selectedGrave index " + index);
        }
        else
        {
            //Debug.Log("Grave " + index + " is already occupied. Skipping spawn.");
        }
    }
}
