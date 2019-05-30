using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    //Aan maken lijst speakers
    public List<GameObject> speakers = new List<GameObject>();

    public GameObject armAnm;

    //input muziek
    public AudioClip SoundToPlay;
    public AudioClip SoundToPlay2;
    public AudioClip SoundToPlay3;
    public AudioClip SoundToPlay4;
    //public Animator anim;

    AudioSource audio;
    //bool Zodat hij niet nog een keer speeld
    public bool alreadPlayed = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    void OnTriggerStay(Collider other)
    {
        //anmatie plaat die al draait
        other.GetComponentInChildren<Animator>().Play("Record");
        

        //als de bool uit is >
        if (!alreadPlayed && other.GetComponent<PickUp>().isHolding == false)
        {
            //animatie arm
            armAnm.GetComponent<Animator>().Play("Recordplayer");
            //Play Record1
            if (other.gameObject.name == "RP") 
            {
                Debug.Log(SoundToPlay);

                //bool aan zetten zodat hij niet nog een keer afspeeld
                alreadPlayed = true;


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
            //Play Record4
            else if (other.gameObject.name == "RP4")
            {
                //bool aan zetten zodat hij niet nog een keer afspeeld
                alreadPlayed = true;
                Debug.Log(SoundToPlay4);

                //voor elke speaker
                foreach (GameObject speaker in speakers)
                {
                    speaker.GetComponent<AudioSource>().clip = SoundToPlay4;
                    speaker.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
    //Reset
    void OnTriggerExit(Collider other)
    {
        //animatie reset
        armAnm.GetComponent<Animator>().Play("STOP");
        other.GetComponentInChildren<Animator>().Play("STOP");
        //bool uit
        alreadPlayed = false;
        //speakers uit zetten
        foreach (GameObject speaker in speakers)
        {
            speaker.GetComponent<AudioSource>().Stop();
        }
    }


}
