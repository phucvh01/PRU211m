using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<ZombieScript> zombies;
    public List<GameObject> zombiePrefabs;
    private bool stopSpawn= true;
    public int howMany;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ManuallySpawn();
        RandomSpawn();
    }
    void ManuallySpawn()
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
    void RandomSpawn()
    {
        if (LoadingScript.playWarning == true && stopSpawn == true)
        {
            for (int i = 0; i < howMany; i++)
            {
                //can random zombie type time placement
                ZombieScript zombie = new ZombieScript { type = ZombieType.normal, isSpawn = false, randomSpawner = true, Spawner = Random.Range(0, 5), spawnTime = Random.Range(1, 5) };
                //Debug.Log(zombie.Spawner + " " + zombie.spawnTime);
                //if (zombie.isSpawn == false && zombie.spawnTime < Time.time)
                //{
                //    GameObject zombieInstant = Instantiate(zombiePrefabs[(int)zombie.type], transform.GetChild(zombie.Spawner).transform);
                //    zombie.isSpawn = true;
                //    zombieInstant.GetComponent<ZombieController>().finalDestination = transform.GetChild(zombie.Spawner).GetComponent<SpawnPoint>().Destination;
                //    transform.GetChild(zombie.Spawner).GetComponent<SpawnPoint>().zombies.Add(zombieInstant);
                //}
            }
            stopSpawn = false;



        }
    }
}
