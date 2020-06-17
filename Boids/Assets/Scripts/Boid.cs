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
        Velocity = this.transform.forward * MaxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if ( velocity.magnitude > maxVelocity)
            Velocity = Velocity.normalized * MaxVelocity;

        this.transform.position += Velocity * Time.deltaTime; //move 
        this.transform.rotation = Quaternion.LookRotation(velocity); //look in direction of movment
    }
}
