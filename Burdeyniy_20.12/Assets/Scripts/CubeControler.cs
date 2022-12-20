using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CubeControler : MonoBehaviour
{
    private float width;
    private float length;
    private float depth;

    void Start()
    {
        width = PlayerPrefs.GetFloat("Width");
        length = PlayerPrefs.GetFloat("Length");
        depth = PlayerPrefs.GetFloat("Depth");

        transform.localScale = new Vector3(width, length, depth);
    }
}
