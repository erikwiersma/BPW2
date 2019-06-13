using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class computerFuel : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] material;
    Renderer rend;

    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject lamp3; 

    public GameObject[] lights;
    public GameObject Text;
    public float State = 1f;
    public GameObject completeUI;


    string txt1 = "Click to engage emergency power...";
    string txt2 = "Power line Error...";
    string txt3 = "Place the pipes in the right order, to fix the power line...";
    string txt4 = "Click reset engine...";
    string txt5 = "Engine repaired. Thanks for playing !";

    IEnumerator Returnplayer()
    {
        yield return new WaitForSeconds(2);
        lamp1.GetComponent<Renderer>().sharedMaterial = material[1];
        yield return new WaitForSeconds(2);
        lamp2.GetComponent<Renderer>().sharedMaterial = material[1];
        yield return new WaitForSeconds(2);
        lamp3.GetComponent<Renderer>().sharedMaterial = material[1];
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (State == 1)
        {
            Text.GetComponent<TextMeshPro>().text = txt1;
        }
        if (State == 2)
        {
            Text.GetComponent<TextMeshPro>().text = txt2;
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().intensity = 500;
            }
        }
        if (State == 3)
        {
            Text.GetComponent<TextMeshPro>().text = txt3;
        }
        if (State == 1000)
        {
            Text.GetComponent<TextMeshPro>().text = txt4;
        }
        if (State == 1001)
        {
            Text.GetComponent<TextMeshPro>().text = txt5;
            StartCoroutine(Returnplayer());
        }
    }
}
