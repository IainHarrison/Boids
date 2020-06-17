using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Boid))]

public class BoidSeparation : MonoBehaviour
{
    public List<GameObject> Boids = new List<GameObject>();

    private Boid boid;

    public float Radius;

    public float Repolsion;

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
            if (difrence.magnitude < Radius) //if to close 
            {
                avarage += difrence; //direction towards
                found++; //we found one that is to close
            }
        }
        if (found > 0)
        {
            avarage = avarage / found;
            boid.velocity -= Vector3.Lerp(Vector3.zero, avarage, avarage.magnitude / Radius) * Repolsion; //lerp away from the avarage of the boid cluster
        }
    }
}
