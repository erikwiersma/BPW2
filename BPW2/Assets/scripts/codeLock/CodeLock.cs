using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeLock : MonoBehaviour
{
    //public List<GameObject> buttons = new List<GameObject>();
    public Material[] material;
    private Renderer[] button; 
    int codelength;
    int placeInCode;
    public GameObject Text;
    public string code = "";
    public string attemptedCode;
    public Transform toOpen;


    private void Start()
    {
        codelength = code.Length;
        button = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        //veranderen van het tekst vak.
        Text.GetComponent<TextMeshPro>().text = attemptedCode;
    }
    void CheckCode()
    {
        //checkt de code met de input
        if (attemptedCode == code)
        {
            toOpen.GetComponent<Animator>().SetBool("open", true);
        }
        else
        {
            Debug.Log("wrong Code");
        }
    }
    
    //Animate Door

    // Update is called once per frame
    public void SetValue(string value)
    {
        placeInCode++;

        //toevoegen van cijvers
        if (placeInCode <= codelength)
        {
            attemptedCode += value;
        }

        //reset
        if (placeInCode == codelength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;

            //reset buttons emmision
            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Renderer>().sharedMaterial = material[0];
            }
        }
    }
}
