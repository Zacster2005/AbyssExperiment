using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [Header("Batteries")]
    
    public Transform[] BatterySpawns;
    public GameObject Battery;





    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Battery, BatterySpawns[Random.Range(0, BatterySpawns.Length)].position, Quaternion.identity);
        Instantiate(Battery, BatterySpawns[Random.Range(0, BatterySpawns.Length)].position, Quaternion.identity);
        Instantiate(Battery, BatterySpawns[Random.Range(0, BatterySpawns.Length)].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }//Update
}//class
