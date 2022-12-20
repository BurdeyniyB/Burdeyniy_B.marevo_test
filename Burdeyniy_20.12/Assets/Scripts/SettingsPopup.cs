using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private float OpenSpeed = 0.5f;
    [SerializeField] private float CloseSpeed = 0.5f;

    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open(int number_texture)
    {
      transform.LeanScale(Vector2.one, OpenSpeed);

      PlayerPrefs.SetInt("number_texture", number_texture);
    }

    public void Close()
    {
      transform.LeanScale(Vector2.zero, CloseSpeed).setEaseInBack();
    }
}
