using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    CodeLock codeLock;

    public int reachRange = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
        }

    }


    void CheckHitObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, reachRange))
        {
            if (hit.collider.gameObject.tag == "Switch")
            {
                hit.collider.GetComponent<light_button>().Power = true;
                hit.collider.GetComponent<light_button>().Deur = true;
            }
            else if (hit.collider.gameObject.tag == "Button")
            {
                codeLock = hit.transform.gameObject.GetComponentInParent<CodeLock>();

                if (codeLock != null)
                {
                    string value = hit.transform.name;
                    codeLock.SetValue(value);
                    hit.collider.GetComponent<Renderer>().sharedMaterial = material[1];

                }
            }
        }
    }
}
