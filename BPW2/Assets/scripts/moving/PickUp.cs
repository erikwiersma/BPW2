using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("pipesysteem")]
    public float pickUpDistance = 4f;
    public GameObject tempParent;
    public bool isHolding = false;
    public bool plaat = false;
    public float trowFroce = 600f;
    Vector3 objectPos;
    float distance;
    float Scrollx = 0.1f;
    private float DraaiSpeed = 5f;


    public Boolean IsHolding
    {
        get
        {
            return isHolding;
        }

        set
        {
            isHolding = value;
        }
    }
            // Update is called once per frame
            void Update()
    {


        distance = Vector3.Distance(transform.position, tempParent.transform.position);
        if (distance >= pickUpDistance )
        {
            IsHolding = false;
        }
        //check if isHolding
        if (IsHolding == true)
        {
            //--------------------------------------------------------------------
            //[voor ronddraaien object]
            if (Input.GetKey("q"))
            {
                Scrollx = -DraaiSpeed;
                float offsetX = Time.time * Scrollx;
                //transform.localRotation = Quaternion.Euler(0, 0, Scrollx);
                transform.Rotate(0, 0, Scrollx);
            }
            if (Input.GetKey("e"))
            {
                Scrollx = DraaiSpeed;
                float offsetX = Time.time * Scrollx;
                //transform.localRotation = Quaternion.Euler(0, 0, Scrollx);
                transform.Rotate(0, 0, Scrollx);
            }
            //--------------------------------------------------------------------
            //--------------------------------------------------------------------


            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))        //muis input rechts 
            {
                GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * trowFroce);      //om het object weg te schieten 
                IsHolding = false;
            }
        }
        else
        {
            objectPos = transform.position;
            transform.SetParent(null);
            transform.position = objectPos;
            if (plaat == true)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }

            //--------------------------------------------------------------------
            //[dit is voor pipsysteem kinematic en gravity
            if (plaat == false)
            {
                if (GetComponent<pipesystem>().inRange == false)
                {
                    GetComponent<Rigidbody>().useGravity = true;
                }
                if (GetComponent<pipesystem>().inRange == true)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            //--------------------------------------------------------------------
            //--------------------------------------------------------------------
        }
    }
    void OnMouseDown()
    {
        if (distance <= pickUpDistance)                                 //kijkt of de afstand groter is dan de oppak afstand
        {
            IsHolding = true;                                           //bool van de ifstatement AAN
            GetComponent<Rigidbody>().useGravity = false;          //zet de zwaartekracht van de rigidboy uit
            GetComponent<Rigidbody>().detectCollisions = true;     //zet de collision detection aan   

            
        }
    }
    void OnMouseUp()
    {
        IsHolding = false;                                              //bool van de ifstatement UIT
    }

}   

