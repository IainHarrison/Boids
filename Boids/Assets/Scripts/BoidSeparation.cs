using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Boid))]

public class BoidSeparation : MonoBehaviour
{
    private Boid boid;

    public float radius;

    public float repolsion;

    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<Boid>(); //fix this in the future
        var avarage = Vector3.zero;
        var found = 0;

        foreach (var _boid in boids.Where(b => b != boid)) //not this boid
        {
            var difrence = _boid.transform.position - this.transform.position; //difrence in space of the 2 boids
            if (difrence.magnitude < radius) //if to close 
            {
                avarage += difrence; //direction towards
                found++; //we found one that is to close
            }
        }
        if (found > 0)
        {
            avarage = avarage / found;
            boid.velocity -= Vector3.Lerp(Vector3.zero, avarage, avarage.magnitude / radius) * repolsion; //lerp away from the avarage of the boid cluster
        }
    }
}
