using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmove : MonoBehaviour
{
    public AudioSource audioSource;
    public float updateStep = 0.05f;
    public int sampleDataLength = 2048;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    // Use this for initialization
    void Awake()
    {

        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];

    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.clip == null)
        {
            return;
        }
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness = clipLoudness / sampleDataLength * 15 ; //clipLoudness is what you are looking for
            Debug.Log(clipLoudness);
            clipLoudness = Mathf.Clamp(clipLoudness, 0, 1);
            if(clipLoudness <= 0.1)
            {
                clipLoudness = 0.1f;
            }
            transform.localScale = new Vector3(1, 1, clipLoudness);
        }

    }

}
