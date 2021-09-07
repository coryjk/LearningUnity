using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject SpawnedSpherePrefab;
    private (float Min, float Max) spawnXRange = (-13, 13);
    private (float Min, float Max) spawnYRange = (5, 10);
    private (float Min, float Max) spawnZRange = (-13, 13);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnSphere();
        } else if (Input.GetKeyDown(KeyCode.B)) {
            Earthquake();
        }
    }

    void SpawnSphere()
    {
        Vector3 position = new Vector3(
            Random.Range(spawnXRange.Min, spawnXRange.Max),
            Random.Range(spawnYRange.Min, spawnYRange.Max),
            Random.Range(spawnZRange.Min, spawnZRange.Max));
        
        GameObject newSphere = (GameObject) Instantiate(SpawnedSpherePrefab, position, Quaternion.identity);
        newSphere.transform.localScale = Vector3.one * Random.Range(1, 5);
    }

    void Earthquake()
    {
        GameObject[] spheres = FindObjectsOfType<GameObject>();
        foreach (GameObject sphere in spheres) 
        {
            if (sphere.tag == "Spawned")
            {
                Vector3 randomForce = new Vector3(0, Random.Range(0, 2), 0);
                sphere.GetComponent<Rigidbody>().AddForce(randomForce * 15, ForceMode.Impulse);
            }
        }
    }
}
