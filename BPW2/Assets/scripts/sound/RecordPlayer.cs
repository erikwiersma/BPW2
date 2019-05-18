using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    //Aan maken lijst speakers
    public List<GameObject> speakers = new List<GameObject>();

    //input muziek
    public AudioClip SoundToPlay;
    public AudioClip SoundToPlay2;
    public AudioClip SoundToPlay3;

    AudioSource audio;
    //bool Zodat hij niet nog een keer speeld
    public bool alreadPlayed = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();    
    }


    void OnTriggerStay(Collider other)
    {
        //als de bool uit is >
        if (!alreadPlayed && other.GetComponent<PickUp>().isHolding == false)
        {
            //Play Record1
            if (other.gameObject.name == "RP") 
            {
                //bool aan zetten zodat hij niet nog een keer afspeeld
                alreadPlayed = true;
                Debug.Log(SoundToPlay);

                //voor elke speaker
                foreach (GameObject speaker in speakers)
                {
                    speaker.GetComponent<AudioSource>().clip = SoundToPlay;
                    speaker.GetComponent<AudioSource>().Play();
                }
            }
            //Play Record2
            else if (other.gameObject.name == "RP2")
            {
                //bool aan zetten zodat hij niet nog een keer afspeeld
                alreadPlayed = true;
                Debug.Log(SoundToPlay2);

                //voor elke speaker
                foreach (GameObject speaker in speakers)
                {

                    speaker.GetComponent<AudioSource>().clip = SoundToPlay2;
                    speaker.GetComponent<AudioSource>().Play();
                }

            }
            //Play Record3
            else if (other.gameObject.name == "RP3")
            {
                //bool aan zetten zodat hij niet nog een keer afspeeld
                alreadPlayed = true;
                Debug.Log(SoundToPlay3);

                //voor elke speaker
                foreach (GameObject speaker in speakers)
                {

                    speaker.GetComponent<AudioSource>().clip = SoundToPlay3;
                    speaker.GetComponent<AudioSource>().Play();
                }

            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        alreadPlayed = false;
        foreach (GameObject speaker in speakers)
        {
            speaker.GetComponent<AudioSource>().Stop();
        }
    }


}
