using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    private Touch touch2;
    private float SpeedMod;

    void Start()
    {
        SpeedMod = 0.005f;
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
          touch = Input.GetTouch(0);

          if(touch.phase == TouchPhase.Moved)
          {
            transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * SpeedMod, transform.position.y, transform.position.z + touch.deltaPosition.y * SpeedMod);
          }
        }

        if(Input.touchCount == 2)
        {
          touch = Input.GetTouch(0);
          touch2 = Input.GetTouch(1);

          if(touch.phase == TouchPhase.Moved)
          {
            if(touch.deltaPosition.x > 0)
            {
              transform.Rotate(transform.position.x + touch.position.x * SpeedMod, 0, 0, Space.World);
            }

            if(touch.deltaPosition.y > 0)
            {
              transform.Rotate(0, 0, transform.position.z + touch.position.y * SpeedMod, Space.World);
            }

            if(touch2.deltaPosition.x > 0)
            {
              transform.Rotate(transform.position.x + touch.position.x * SpeedMod, 0, 0, Space.World);
            }

            if(touch2.deltaPosition.y > 0)
            {
              transform.Rotate(0, 0, transform.position.z + touch.position.y * SpeedMod, Space.World);
            }
          }
        }
    }
}
