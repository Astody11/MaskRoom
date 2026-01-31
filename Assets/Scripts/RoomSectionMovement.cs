using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSectionMovement : MonoBehaviour
{
    public GameObject upSection;
    public GameObject middleSection;
    public GameObject downSection;

    public Button upSectionBtn;
    public Button middleSectionBtn;
    public Button downSectionBtn;

    public String roomSectionString = "UP";

    public int upAngle = 0;
    public int middleAngle = 0;
    public int downAngle = 0;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RoomRotation(-90);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RoomRotation(90);
        }
    }

    public void RoomRotation(int angleRotation)
    {
        switch (roomSectionString)
        {
            case "UP":
                upSection.transform.Rotate(0, angleRotation, 0);
                upAngle += angleRotation;
                if(upAngle < 0 && angleRotation == -90)
                {
                    upAngle = 270;
                } else if(upAngle>270 && angleRotation == 90)
                {
                    upAngle = 0;
                }
                Debug.Log("UP" + upAngle);
                            
                break;
            case "MIDDLE":
                middleSection.transform.Rotate(0, angleRotation, 0);
                middleAngle += angleRotation;
                if (middleAngle < 0 && angleRotation == -90)
                {
                    middleAngle = 270;
                }
                else if (middleAngle > 270 && angleRotation == 90)
                {
                    middleAngle = 0;
                }
                Debug.Log("MIDDLE" + middleAngle);
                break;
            case "DOWN":
                downSection.transform.Rotate(0, angleRotation, 0);
                downAngle += angleRotation;
                if (downAngle < 0 && angleRotation == -90)
                {
                    downAngle = 270;
                }
                else if (downAngle > 270 && angleRotation == 90)
                {
                    downAngle = 0;
                }
                Debug.Log("DOWN" + downAngle);
                break;
        }
    }

    public void roomSectionStringChanged(string sectionName) {
        roomSectionString = sectionName;
        Debug.Log(sectionName);
    }

    

}
