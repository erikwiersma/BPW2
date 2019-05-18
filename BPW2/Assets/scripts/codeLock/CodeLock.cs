using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codelength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    public Transform toOpen;

    private void Start()
    {
        codelength = code.Length;
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            StartCoroutine(Open());
        }
        else
        {
            Debug.Log("wrong Code");
        }
    }

    //Animate Door
    IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0, 90, 0), Space.World);
        yield return new WaitForSeconds(4);

        toOpen.Rotate(new Vector3(0, -90, 0), Space.World);
    }
    //Animate Door

    // Update is called once per frame
    public void SetValue(string value)
    {
        placeInCode++;

        if (placeInCode <= codelength)
        {
            attemptedCode += value;
        }

        if (placeInCode == codelength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
