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
            _boid.transform.parent = this.gameObject.transform;
        }

        List<GameObject> _boids = new List<GameObject>();
        foreach (Transform _child in this.transform)
        {
            _boids.Add(_child.gameObject);
        }

        foreach (Transform child in this.transform)
        {
            child.gameObject.GetComponent<BoidAlignment>().Boids = _boids;
            child.gameObject.GetComponent<BoidCohesion>().Boids = _boids;
            child.gameObject.GetComponent<BoidSeparation>().Boids = _boids;
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
