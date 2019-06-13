using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipePos : MonoBehaviour
{
    public GameObject eerst;
    public GameObject twee;
    public GameObject derde;
    public GameObject vierde;

    public GameObject marker1;
    public GameObject marker2;
    public GameObject marker3;
    public GameObject marker4;

    public GameObject computer;

    private bool done = false;
    public float onderdeel;

    void Update()
    {
        if (done == false)
        {
            if (marker1.GetComponent<pipeclip>().right == true && marker2.GetComponent<pipeclip>().right == true && marker3.GetComponent<pipeclip>().right == true && marker4.GetComponent<pipeclip>().right == true)
            {
                if (eerst.GetComponent<pipesystem>().Hoek == 90 || eerst.GetComponent<pipesystem>().Hoek == 270)
                {
                    if(twee.GetComponent<pipesystem>().Hoek == 360)
                    {
                        if(derde.GetComponent<pipesystem>().Hoek == 180)
                        {
                            if(vierde.GetComponent<pipesystem>().Hoek == 90 || vierde.GetComponent<pipesystem>().Hoek == 270)
                            {
                                computer.GetComponent<computerFuel>().State = 1000;
                                done = true;
                                Debug.Log("Feest");
                            }
                        }
                    }
                    
                }
            }
        }
       
    }
}
