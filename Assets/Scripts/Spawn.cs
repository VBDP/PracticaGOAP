using UnityEngine;

public class Spawn : MonoBehaviour
{

    // Grab our prefab
    public GameObject patientPrefab;
    // Number of patients to spawn
    public int numPatients;
    public int activePacients;
    public int maxPatients = 8;

    void Start()
    {
        //for (int i = 0; i < numPatients; ++i) {

        //    // Instantiate numPatients at the spawner
        //    Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        //}
        // Call the SpawnPatient method for the first time
        activePacients = 0;
        Invoke("SpawnPatient", 5.0f);
    }

    void SpawnPatient()
    {
        // Instantiate numPatients at the spawner
        if (activePacients < maxPatients)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
            // Invoke this method at random intervals
            Invoke("SpawnPatient", Random.Range(2.0f, 10.0f));
            activePacients += 1;
        }
        else
        {
           Invoke("SpawnPatient", Random.Range(2.0f, 10.0f)); 
        }      
    }

    public void RestarPaciente()
    {
        activePacients -= 1;
    }
}
