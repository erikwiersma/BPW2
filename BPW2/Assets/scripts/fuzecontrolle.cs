using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuzecontrolle : MonoBehaviour
{
    public GameObject[] lights;

    public GameObject fuze1;
    public GameObject fuze2;

    public GameObject Marker1;
    public GameObject Marker2;

    public bool click1;
    public bool click2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Marker1.GetComponent<pipeclip>().full == true)
        {
            if (fuze1.GetComponent<pipesystem>().Hoek == 0 || fuze1.GetComponent<pipesystem>().Hoek == 360)
            {
                click1 = true;
            }
        }
        if (Marker2.GetComponent<pipeclip>().full == true)
        {
            if (fuze2.GetComponent<pipesystem>().Hoek == 180)
            {
                click2 = true;
            }
        }
        if (click1 == true && click2 == true)
        {
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().intensity = 500;
            }
        }
    }
}
