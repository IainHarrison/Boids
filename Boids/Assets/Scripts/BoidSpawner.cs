using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject BoidPrefab;

    public float SpawnRadius;
    public float MaxTravelRadius;
    public int AmountOfBoids;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< AmountOfBoids; i++)
        {
            var _boid = Instantiate(BoidPrefab, this.transform.position + Random.insideUnitSphere * SpawnRadius, Random.rotation);
            _boid.GetComponent<PlayZone>().BoidSpawner = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
