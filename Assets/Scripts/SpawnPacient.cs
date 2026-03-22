using UnityEngine;

public class SpawnPacient : MonoBehaviour
{

    // Grab our prefab
    public GameObject patientPrefab;
    // Number of patients to spawn
    public int numSpawned;
    public int activeSpawneds;
    public int maxSpawned = 8;

    void Start()
    {
        //for (int i = 0; i < numPatients; ++i) {

        //    // Instantiate numPatients at the spawner
        //    Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        //}
        // Call the SpawnPatient method for the first time
        activeSpawneds = 0;
        Invoke("SpawnPatient", 5.0f);
    }

    void SpawnPatient()
    {
        // Instantiate numPatients at the spawner
        if (activeSpawneds < maxSpawned)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
            // Invoke this method at random intervals
            Invoke("SpawnPatient", Random.Range(2.0f, 10.0f));
            activeSpawneds += 1;
        }
        else
        {
           Invoke("SpawnPatient", Random.Range(2.0f, 10.0f)); 
        }      
    }

    public void RestarPaciente()
    {
        activeSpawneds -= 1;
    }
}
