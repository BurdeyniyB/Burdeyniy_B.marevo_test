using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SizeSetting : MonoBehaviour
{
   [SerializeField] private InputField WidthField;
   [SerializeField] private InputField LengthField;
   [SerializeField] private InputField DepthField;

   public void OK()
   {
     if(WidthField != null && LengthField != null && DepthField != null)
     {
       PlayerPrefs.SetFloat("Width", (int.Parse(WidthField.text) / 100f));
       PlayerPrefs.SetFloat("Length", (int.Parse(LengthField.text) / 100f));
       PlayerPrefs.SetFloat("Depth", (int.Parse(DepthField.text) / 100f));

       SceneManager.LoadScene("Show");
     }
   }
}
