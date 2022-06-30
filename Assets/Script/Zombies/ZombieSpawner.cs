using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<ZombieScript> zombies;
    public List<GameObject> zombiePrefabs;
    public static bool stopSpawn=false;
    public int howMany;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            ManuallySpawn();
        
        if (LoadingScript.playWarning == true &&stopSpawn==true)
        {

            //RandomSpawn();
            
        }
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
    //could use invoke but slower than coroutine
    void RandomSpawn()
    {

        for (int i = 0; i < howMany; i++)
        {
            //can random zombie type time placement
            //read json here
            ZombieScript zombie = new ZombieScript { type = ZombieType.normal, isSpawn = false, randomSpawner = true, Spawner = Random.Range(0, 5), spawnTime = Random.Range(1, 5) };
            Debug.Log("Zombie number"+i+ " where he spawn: "+zombie.Spawner + " what time " + zombie.spawnTime);
            zombies.Add(zombie);
      
           
        } stopSpawn = false;

     



    }

}

