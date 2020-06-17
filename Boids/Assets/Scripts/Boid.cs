using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxVelocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = this.transform.forward * maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if ( velocity.magnitude > maxVelocity)
            velocity = velocity.normalized * maxVelocity;

        this.transform.position += velocity * Time.deltaTime; //move 
        this.transform.rotation = Quaternion.LookRotation(velocity); //look in direction of movment
    }
}
