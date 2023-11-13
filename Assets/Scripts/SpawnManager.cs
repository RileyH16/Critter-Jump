using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;
    public GameObject[] carPrefabs;
    private Vector3 leftSpawn1 = new Vector3(-35.0f, 0.9f, -2.2f);
    private Vector3 leftSpawn2 = new Vector3(-35.0f, 0.9f, 17.7f);
    private Vector3 rightSpawn1 = new Vector3(35.0f, 0.9f, 2.0f);
    private Vector3 rightSpawn2 = new Vector3(35.0f, 0.9f, 21.9f);
    

    private List<GameObject> Enemy;

    // Start is called before the first frame update
    public void Start()
    {
        Invoke("SpawnObstacle", startDelay);
        Enemy = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        spawnInterval = Random.Range(0.75f, 1.0f);

        int randomCar = Random.Range(0, carPrefabs.Length);

        Instantiate(carPrefabs[randomCar], leftSpawn1, carPrefabs[randomCar].transform.rotation);
        Instantiate(carPrefabs[randomCar], rightSpawn1, Quaternion.Euler(0, -90, 0));

        Instantiate(carPrefabs[randomCar], leftSpawn2, carPrefabs[randomCar].transform.rotation);
        Instantiate(carPrefabs[randomCar], rightSpawn2, Quaternion.Euler(0, -90, 0));

        Invoke("SpawnObstacle", spawnInterval);

       
    }

}
