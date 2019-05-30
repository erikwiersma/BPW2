using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpSnap : MonoBehaviour
{
    public Transform endMarker;

    public float speed = 1.0F;
    public float threshold = 0.2F;
    public float snapRange = 1f;

    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void Update()
    {
        //checken of dat het object vastgehouden wordt 
        if (GetComponent<PickUp>().isHolding == false)
        {
            //afstand meting 
            float dist = Vector3.Distance(endMarker.position, transform.position);

            //als de afstand groter is dan 1 schiet terug, 
            //0.3 is treshold
            if (dist >= threshold && dist <= snapRange)
            {
                // Distance moved = time * speed.
                float distCovered = (Time.time - startTime) * speed;

                // Fraction of journey completed = current distance divided by total distance.
                float fracJourney = distCovered / journeyLength;

                // Set our position as a fraction of the distance between the markers.
                transform.position = Vector3.Lerp(transform.position, endMarker.position, fracJourney);
                Debug.Log("move");
            }
        }
       
       
    }
}
