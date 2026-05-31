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

    //WHITE MASK PUZZLE
    private GameObject topCuadro;
    private GameObject midCuadro;
    private GameObject botCuadro;

    //DOG MASK PUZZLE
    public GameObject n1;
    private GameObject n2;
    private GameObject n3;
    private int dogPuzleSteps = 0;

    private bool n1Revealed = false;
    private bool n2Revealed = false;
    private bool n3Revealed = false;

    void Start()
    {
        roomSectionMovement = GetComponent<RoomSectionMovement>();
    }

    
    void Update()
    {
        if (puzzleMask == "dog")
        {
            if (n1Revealed && GameObject.Find("LVL2-Trozo1"))
            {
                n1 = GameObject.Find("LVL2-Trozo1");
                n1.SetActive(false);
            }

            if (n2Revealed && GameObject.Find("LVL2-Trozo2"))
            {
                n2 = GameObject.Find("LVL2-Trozo2");
                n2.SetActive(false);
            }

            if (n3Revealed && GameObject.Find("LVL2-Trozo3"))
            {
                n3 = GameObject.Find("LVL2-Trozo3");
                n3.SetActive(false);
            }
        }

    }

    public void DogMaskPuzzle()
    {
        Debug.Log("COMPRUEBO DOG");

        if (
            (VerifyColor("dog", "dog", "white") || VerifyColor("white", "dog", "white")) &&
            roomSectionMovement.middleAngle == 180 &&
            roomSectionMovement.downAngle == 90 && !n1Revealed)
        {
            
            n1 = GameObject.Find("LVL2-Trozo1");
            n1.SetActive(false);
            dogPuzleSteps++;
            n1Revealed = true;
            Debug.Log("STEP 1 COMPLETADO");
        }
            
        if ((VerifyColor("dog", "dog", "white") || VerifyColor("white", "dog", "white")) &&
            roomSectionMovement.middleAngle == 90 &&
            roomSectionMovement.downAngle == 270)
        {
            n2 = GameObject.Find("LVL2-Trozo2");
            n2.SetActive(false);

            dogPuzleSteps++;
            n2Revealed = true;
            Debug.Log("STEP 2 COMPLETADO");
        }
               

        if ((VerifyColor("dog", "white", "dog") || VerifyColor("white", "white", "dog")) &&
            roomSectionMovement.middleAngle == 90 &&
            roomSectionMovement.downAngle == 180)
        {
            n3 = GameObject.Find("LVL2-Trozo3");
            n3.SetActive(false);

            dogPuzleSteps++;
            n3Revealed = true;
            Debug.Log("STEP 3 COMPLETADO");
        }
                
        //Puzzle resuelto, se asigna nuevo color
        if(dogPuzleSteps == 3)
        {
            puzzleMask = "clown";
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

    public void ClownMaskPuzzle()
    {

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
            case "clown":
                ClownMaskPuzzle();
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
