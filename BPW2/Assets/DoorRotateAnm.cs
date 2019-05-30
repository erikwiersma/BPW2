using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotateAnm : MonoBehaviour
{
    bool eind = false;
    bool move = false;

    void Movetorotate()
    {
        move = true;
    }
    void Movenotrotate()
    {
        eind = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            GetComponent<Animator>().SetBool("open", false);
        }
    }
}
