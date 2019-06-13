using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class light_button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lights;
    public GameObject ToClose;
    public GameObject Text;
    public float State = 0f;

    string txt1 = "Press to engage backup Power...";
    string txt2 = "Main Engine power, failed...";
    string txt3 = "Engine pipes failed, system error...";
    string txt4 = "Go to engine room to fix the problem";

    IEnumerator Dicht()
    {
        yield return new WaitForSeconds(1);
        ToClose.GetComponent<Animator>().SetBool("Close", false);
    }

    private void Start()
    {
        Text.GetComponent<TextMeshPro>().text = txt1;
    }

    private void Update()
    {
        if (State == 2)
        {
            ToClose.GetComponent<Animator>().SetBool("Close", true);
            StartCoroutine(Dicht());
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().intensity = 200;
            }
            Text.GetComponent<TextMeshPro>().text = txt2;
            State += 1;
        }
        if (State == 4)
        {
            Text.GetComponent<TextMeshPro>().text = txt3;
        }
        if (State == 5)
        {
            Text.GetComponent<TextMeshPro>().text = txt4;
        }
    }
}
