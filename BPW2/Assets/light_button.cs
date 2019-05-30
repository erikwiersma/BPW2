using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_button : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject[] lights;
    public bool Power;
    public bool Deur;
    public GameObject ToClose;
    public GameObject dot;
    IEnumerator Dicht()
    {
        yield return new WaitForSeconds(1);
        ToClose.GetComponent<Animator>().SetBool("Close", false);
        Deur = false;
    }

    private void Start()
    {
        Power = false;
    }

        private void Update()
    {
        if (Deur == true)
        {
            Destroy(dot);
            ToClose.GetComponent<Animator>().SetBool("Close", true);
            StartCoroutine(Dicht());
        }
        if (Power == true)
        {
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().intensity = 700;
            }
        }
        else
        {
            Power = false;
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().intensity = 10;
            }
        }
    }
}
