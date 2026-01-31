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

    public Boolean isRotating = false;
    ObjectUnion objectUnion;

    void Start()
    {
        upSectionBtn.Select();
        objectUnion = GetComponent<ObjectUnion>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SectionChangedByArrows(true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SectionChangedByArrows(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
        {
            RoomRotation(-90);
            objectUnion.CurrentMaskPuzzle();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
        {
            RoomRotation(90);
            objectUnion.CurrentMaskPuzzle();
        }

        FixBtnSelection();
    }

    public void RoomRotation(int angleRotation)
    {
        switch (roomSectionString)
        {
            case "UP":

                StartCoroutine(RotateSection(upSection.transform, angleRotation, 1.5f));

                upAngle += angleRotation;
                if (upAngle < 0 && angleRotation == -90)
                {
                    upAngle = 270;
                }
                else if (upAngle > 270 && angleRotation == 90)
                {
                    upAngle = 0;
                }
                Debug.Log("UP" + upAngle);

                break;
            case "MIDDLE":
                StartCoroutine(RotateSection(middleSection.transform, angleRotation, 1.5f));
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

                StartCoroutine(RotateSection(downSection.transform, angleRotation, 1.5f));
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
    IEnumerator RotateSection(Transform section, float angle, float duration)
    {
        isRotating = true;
        float elapsed = 0f;

        Quaternion startRotation = section.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            section.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }

        section.rotation = endRotation;
        isRotating = false;
    }

    public void roomSectionStringChanged(string sectionName)
    {
        roomSectionString = sectionName;
        Debug.Log(sectionName);
    }

    private void SectionChangedByArrows(Boolean upArrow)
    {
        Debug.Log(upArrow);
        if (upArrow)
        {
            switch (roomSectionString)
            {
                case "UP":
                    roomSectionString = "DOWN";
                    break;
                case "MIDDLE":
                    roomSectionString = "UP";
                    break;
                case "DOWN":
                    roomSectionString = "MIDDLE";
                    break;
            }
            Debug.Log(roomSectionString);
        }
        else
        {
            Debug.Log(upArrow);
            switch (roomSectionString)
            {
                case "UP":
                    roomSectionString = "MIDDLE";
                    break;
                case "MIDDLE":
                    roomSectionString = "DOWN";
                    break;
                case "DOWN":
                    roomSectionString = "UP";
                    break;
            }
            Debug.Log(roomSectionString);
        }
    }

    public void FixBtnSelection()
    {
        switch (roomSectionString)
        {
            case "UP":
                upSectionBtn.Select();
                break;
            case "MIDDLE":
                middleSectionBtn.Select();
                break;
            case "DOWN":
                downSectionBtn.Select();
                break;
        }

    }
}
