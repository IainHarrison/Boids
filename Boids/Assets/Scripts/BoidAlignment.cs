using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Boid))]

public class BoidAlignment : MonoBehaviour
{
    private Boid boid;
    public List<GameObject> Boids = new List<GameObject>();

    public float Radius;

    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        var avarage = Vector3.zero;
        var found = 0;

        foreach (var _boid in Boids.Where(b => b != boid)) //not this boid
        {
            var difrence = _boid.transform.position - this.transform.position; //difrence in space of the 2 boids
            if (difrence.magnitude < radius) //if in range
            {
                avarage += boid.velocity; 
                found++; //we found one in range
            }
        }
        if (found > 0)
        {
            avarage = avarage / found;
            boid.velocity += Vector3.Lerp(boid.velocity, avarage, Time.deltaTime); //lerp towards the avarage of the boid cluster
        }
    }
}
