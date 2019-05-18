using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpDistance = 4f;
    public GameObject tempParent;
    public bool isHolding = false;
    public bool check = true;
    public float trowFroce = 600f;
    Vector3 objectPos;
    float distance;

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
        if (IsHolding == true && check == true)
        {
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
            GetComponent<Rigidbody>().useGravity = true;
            transform.position = objectPos;
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

