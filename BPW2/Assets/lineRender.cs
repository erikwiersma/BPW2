using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRender : MonoBehaviour { 

    public GameObject ItSelf;
    public GameObject DeLink;

    private LineRenderer lineRenderer;
    float Scrollx = 0.1f;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, ItSelf.transform.position);
        lineRenderer.SetPosition(0, DeLink.transform.position);

    }
}
