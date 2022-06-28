using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ZombieScript
{
    // Start is called before the first frame update
 
   public float spawnTime;
    public ZombieType type;
    
    public int Spawner;
    public bool randomSpawner;
    public bool isSpawn;


}
public enum ZombieType { normal, tank, speed }
