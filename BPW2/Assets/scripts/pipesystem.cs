using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipesystem : MonoBehaviour
{
    Transform endMarker;

    [Header("snap")]
    public float speed = 0.03f;
    public float threshold = 0.2F;
    public float snapRange = 1f;
    public bool inRange;

    [Header ("pipes")]
    public float Hoek;
    private float startTime;
    public float Points = 3f;

    public float EigenOnderdeel;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, endMarker.position);
    }
    private void Update()
    {
        
    }

    // Follows the target position like with a spring
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<pipeclip>().full == false)
        {
            endMarker = other.transform;
            inRange = true;
            float dist = Vector3.Distance(other.transform.position, transform.position);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (GetComponent<PickUp>().isHolding == false)
        {
            //---------------------------------------------------------------------------------------------
            //om de hoek van het onderdeel goed te zetten
            if (transform.rotation.eulerAngles.z <= -45 && transform.rotation.eulerAngles.z <= 45)
            {
                Hoek = 0;
            }
            else if (transform.rotation.eulerAngles.z >= 45 && transform.rotation.eulerAngles.z <= 135)
            {
                Hoek = 90;
            }
            else if (transform.rotation.eulerAngles.z >= 135 && transform.rotation.eulerAngles.z <= 225)
            {
                Hoek = 180;
            }
            else if (transform.rotation.eulerAngles.z >= 225 && transform.rotation.eulerAngles.z <= 315)
            {
                Hoek = 270;
            }
            else if (transform.rotation.eulerAngles.z >= 315 && transform.rotation.eulerAngles.z <= 405)
            {
                Hoek = 360;
            }
            //---------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------
            if (other.GetComponent<pipeclip>().onderdeel == EigenOnderdeel)
            {
                other.GetComponent<pipeclip>().right = true;
                Debug.Log(other.GetComponent<pipeclip>().onderdeel);
            }
            other.GetComponent<pipeclip>().full = true;
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, endMarker.position, fracJourney);

            // set de rotation 
            Quaternion wantedRotation = Quaternion.Euler(0, 0, Hoek);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, fracJourney);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        inRange = false;
        other.GetComponent<pipeclip>().full = false;
    }

}