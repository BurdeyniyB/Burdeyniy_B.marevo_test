using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    [SerializeField] private GameObject MyObject;

    void Start()
    {
        GameObject.Instantiate(MyObject);
    }

}
