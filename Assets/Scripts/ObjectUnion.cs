using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectUnion : MonoBehaviour
{

    public GameObject upSection;
    public GameObject middleSection;
    public GameObject downSection;

    private string puzzleMask = "white";
    RoomSectionMovement roomSectionMovement;

    private int dogPuzleSteps = 0;

    //WHITE MASK PUZZLE
    private GameObject topCuadro;
    private GameObject midCuadro;
    private GameObject botCuadro;

    //DOG MASK PUZZLE

    

    void Start()
    {
        roomSectionMovement = GetComponent<RoomSectionMovement>();
    }

    
    void Update()
    {
        
    }

    public void DogMaskPuzzle()
    {
        switch(dogPuzleSteps)
        {
            case 0:
                if (VerifyColor("dog", "dog", "white") &&
                    roomSectionMovement.upAngle == 0 &&
                    roomSectionMovement.middleAngle == 90 &&
                    roomSectionMovement.downAngle == 180)
                {
                    //Asignaciones
                    topCuadro = GameObject.Find("LVL1-Percha2");
                    midCuadro = GameObject.Find("LVL2-Planta1");



                    StartCoroutine(MoveCuadro(topCuadro.transform, -1, 1.5f));
                    StartCoroutine(MoveCuadro(midCuadro.transform, -1, 1.5f));
                    StartCoroutine(MoveCuadro(botCuadro.transform, -1, 1.5f));


                    Debug.Log("CUADRO ALINEADO");
                    GameObject n1 = topCuadro = GameObject.Find("LVL2-Trozo1");
                    n1.SetActive(false);

                    dogPuzleSteps++;
                }
               
                break;
            case 1:
                if (VerifyColor("dog", "dog", "white") &&
                    roomSectionMovement.upAngle == 0 &&
                    roomSectionMovement.middleAngle == 90 &&
                    roomSectionMovement.downAngle == 180)
                {
                    //Asignaciones
                    topCuadro = GameObject.Find("LVL1-Percha2");
                    midCuadro = GameObject.Find("LVL2-Planta1");



                    StartCoroutine(MoveCuadro(topCuadro.transform, -1, 1.5f));
                    StartCoroutine(MoveCuadro(midCuadro.transform, -1, 1.5f));
                    StartCoroutine(MoveCuadro(botCuadro.transform, -1, 1.5f));


                    Debug.Log("CUADRO ALINEADO");

                    dogPuzleSteps++;
                }
                break;

            case 2:
                if (VerifyColor("dog", "dog", "white") &&
                    roomSectionMovement.upAngle == 0 &&
                    roomSectionMovement.middleAngle == 90 &&
                    roomSectionMovement.downAngle == 180)
                {
                    //Asignaciones
                    topCuadro = GameObject.Find("LVL1-Percha2");
                    midCuadro = GameObject.Find("LVL2-Planta1");



                    StartCoroutine(MoveCuadro(topCuadro.transform, -1, 1.5f));
                    StartCoroutine(MoveCuadro(midCuadro.transform, -1, 1.5f));
                    StartCoroutine(MoveCuadro(botCuadro.transform, -1, 1.5f));


                    Debug.Log("CUADRO ALINEADO");

                    dogPuzleSteps++;
                }
                break;

            case 3:
                //Puzzle resuelto, se asigna nuevo color
                puzzleMask = "clown";
                break;
        }
        
    }

    public void WhiteMaskPuzzle()
    {
        if (VerifyColor("white", "white", "white") &&
            roomSectionMovement.upAngle == 0 &&
            roomSectionMovement.middleAngle == 90 &&
            roomSectionMovement.downAngle == 180 
            && puzzleMask == "white")
        {
            //Asignaciones
            topCuadro = GameObject.Find("LVL1-Cuadro1");
            midCuadro = GameObject.Find("LVL1-Cuadro2");
            botCuadro = GameObject.Find("LVL1-Cuadro3");

            //if(!roomSectionMovement.isRotating)
            //{
                StartCoroutine(MoveCuadro(topCuadro.transform, -1, 1.5f));
                StartCoroutine(MoveCuadro(midCuadro.transform, -1, 1.5f));
                StartCoroutine(MoveCuadro(botCuadro.transform, -1, 1.5f));
            //}

            Debug.Log("CUADRO ALINEADO");

            //Puzzle resuelto, se asigna nuevo color
            puzzleMask = "dog";
        }
        
    }

    public void CurrentMaskPuzzle()
    {
        switch(puzzleMask)
        {
            case "white":
                WhiteMaskPuzzle();
                break;
            case "dog":
                DogMaskPuzzle();
                break;
        }
    }

    public bool VerifyColor(string upColor, string midColor, string downColor)
    {
        if (upColor == upSection.GetComponent<EachSectionManager>().color && 
            midColor == middleSection.GetComponent<EachSectionManager>().color && 
            downColor == downSection.GetComponent<EachSectionManager>().color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator MoveCuadro(Transform section, float cm, float duration)
    {

        float elapsed = 0f;

        Vector3 startPos = section.position;
        Vector3 endPos = startPos + Vector3.left * cm;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            section.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        section.position = endPos;

    }
}
