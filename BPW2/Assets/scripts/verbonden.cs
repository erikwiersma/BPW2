using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verbonden : MonoBehaviour
{
    public bool IsLinked;

    public GameObject borther;
    public GameObject mother;

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (IsLinked == true)
        {
            if (other.GetComponent<verbonden>().IsLinked == false)
            {
                
            }
        }
    }
}
