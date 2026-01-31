using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskAnimation : MonoBehaviour
{
    private bool hasBeenClicked = false;
    private bool goesUp = true;
    private bool goesDown;

    private float tUp = 2f;
    private float tDown = 0;
    private float tRotate = 1.75f;
    private float tGame = 1.75f;

    void OnMouseDown()
    {
        hasBeenClicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenClicked)
        {
            if (goesUp && tUp > 0f)
            {
                
                    transform.localPosition += new Vector3(0f, 0.1f * Time.deltaTime, 0);
                    tUp -= Time.deltaTime;
                    Debug.Log(tUp);
                
            }
            else if (goesDown && tDown > 0f)
            {
                transform.localPosition += new Vector3(0f, -0.1f * Time.deltaTime, 0f);
                tDown -= Time.deltaTime;
                Debug.Log(tDown);
            }

            if (tUp <= 0f)
            {
                tUp = 2f;
                tDown = 2f;
                goesDown = true;
                goesUp = false;
            }

            if(tDown <= 0f)
            {
                tUp = 2f;
                tDown = 2f;
                goesDown = false;
                goesUp = true;
            }


        } else
        {

            transform.localPosition += new Vector3(0f, 0f, -1f * Time.deltaTime);
            if(tRotate > 0f)
            {
                transform.Rotate(0f, 0f, 100f * Time.deltaTime);
                tRotate -= Time.deltaTime;
            }

            if (tRotate < 0f)
            {
                SceneManager.LoadScene("MaskRoom_Alex");
            }
        }

        
    }
}
