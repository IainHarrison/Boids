using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Boid))]

public class PlayZone : MonoBehaviour
{
    private Boid boid;

    public GameObject BoidSpawner;

    float radius;

    // Start is called before the first frame update
    void Start()
    {
        radius = BoidSpawner.GetComponent<BoidSpawner>().MaxTravelRadius;
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boid.transform.position.magnitude > radius)
        {
            boid.velocity += this.transform.position.normalized * (radius - boid.transform.position.magnitude) * Time.deltaTime; // move back toward the spawner
        }
    }
}
