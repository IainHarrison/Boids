using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Boid))]

public class BoidCohesion : MonoBehaviour
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
        //var boids = FindObjectsOfType<Boid>(); //fix this in the future
        var avarage = Vector3.zero;
        var found = 0;
        
        foreach(var _boid in Boids.Where(b => b != boid)) //not this boid
        {
            var difrence = _boid.transform.position - this.transform.position; //difrence in space of the 2 boids
            if (difrence.magnitude < Radius) //if in range
            {
                avarage += difrence; //add to the avarage direction
                found++; //we found one in range
            }
        }
        if (found > 0)
        {
            avarage = avarage / found;
            boid.velocity += Vector3.Lerp(Vector3.zero, avarage, avarage.magnitude / Radius); //lerp towards the avarage of the boid cluster
        }
     
    }
}
