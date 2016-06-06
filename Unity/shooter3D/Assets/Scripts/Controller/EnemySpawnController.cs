using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    GameObject[] spawnpoints;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        spawnpoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
        SpawnEnemies(5);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	
	}
    
    public void SpawnEnemies(int numberOfSpawns)
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            int spawnNumber = Random.Range(0, spawnpoints.Length);
            var spawnpoint = spawnpoints[spawnNumber].transform.position;
            Instantiate(enemy, spawnpoint, new Quaternion());
        }
    }
}
