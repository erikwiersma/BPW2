using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class computer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Text;
    public float State = 1f;
    public GameObject fuzecontrol;
    public GameObject deurANM;
    public GameObject deurANM2;

    string txt1 = "Warning...";
    string txt2 = "Power decreasing...";
    string txt3 = "place fuses to start backup power...";
    string txt4 = "pickup items with mouse and rotate with Q & E...";
    string txt5 = "Go lower deck to start backup protocol";

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1);
        deurANM.GetComponent<Animator>().SetBool("open", false);
        deurANM2.GetComponent<Animator>().SetBool("open", false);
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
        }
        if (State == 3)
        {
            Text.GetComponent<TextMeshPro>().text = txt3;
        }
        if (State == 4)
        {
            Text.GetComponent<TextMeshPro>().text = txt4;
            deurANM.GetComponent<Animator>().SetBool("open", true);
            StartCoroutine(Stop());
            State += 1;
        }
        if (State >= 6 && fuzecontrol.GetComponent<fuzecontrolle>().click1 && fuzecontrol.GetComponent<fuzecontrolle>().click2)
        {
            Text.GetComponent<TextMeshPro>().text = txt5;
            deurANM2.GetComponent<Animator>().SetBool("open", true);
            StartCoroutine(Stop());
            State += 1;
        }
    }
}
