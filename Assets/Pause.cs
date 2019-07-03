using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    public Transform canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SettingButton"))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }
}


                    
                
