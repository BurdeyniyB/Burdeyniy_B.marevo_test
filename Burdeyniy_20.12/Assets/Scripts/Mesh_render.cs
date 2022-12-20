using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mesh_render : MonoBehaviour
{
    private Renderer _Renderer;
    private int number_texture;
    [SerializeField] private Texture[] _texture;
    [SerializeField] private GameObject cube;


    void Start()
    {
        _Renderer = cube.GetComponent<Renderer>();
        number_texture = PlayerPrefs.GetInt("number_texture");
        Debug.Log("_number_texture = " + number_texture);

        _Renderer.material.mainTexture = _texture[number_texture - 1];
    }

}
