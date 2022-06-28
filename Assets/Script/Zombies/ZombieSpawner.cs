using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<ZombieScript> zombies;
    public List<GameObject> zombiePrefabs;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (ZombieScript zombie in zombies)
        {
            if (zombie.isSpawn == false && zombie.spawnTime < Time.time)
            {
                GameObject zombieInstant = Instantiate(zombiePrefabs[(int)zombie.type], transform.GetChild(zombie.Spawner).transform);
                zombie.isSpawn = true;
                zombieInstant.GetComponent<ZombieController>().finalDestination = transform.GetChild(zombie.Spawner).GetComponent<SpawnPoint>().Destination;
                transform.GetChild(zombie.Spawner).GetComponent<SpawnPoint>().zombies.Add(zombieInstant);
            }
        }
    }
}
