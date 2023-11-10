using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 3;
    private float repeatRate = 3;
    public GameObject[] carPrefabs;
    private Vector3 leftSpawn = new Vector3(-45.0f, 0.9f, -2.2f);
    private Vector3 rightSpawn = new Vector3(45.0f, 0.9f, 2.0f);
    

    private List<GameObject> Enemy;

    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        Enemy = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int randomCar = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[randomCar], leftSpawn, carPrefabs[randomCar].transform.rotation);
        Instantiate(carPrefabs[randomCar], rightSpawn, Quaternion.Euler(0, -90, 0));
    }

}
