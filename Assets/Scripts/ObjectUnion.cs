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
    [SerializeField]
    private GameObject topCuadro;
    [SerializeField]
    private GameObject midCuadro;
    [SerializeField]
    private GameObject botCuadro;
    

    void Start()
    {
        roomSectionMovement = GetComponent<RoomSectionMovement>();
    }

    
    void Update()
    {
        
    }

    public void WhiteMaskPuzzle()
    {
        if (VerifyColor("white", "white", "white") &&
            roomSectionMovement.upAngle == 0 &&
            roomSectionMovement.middleAngle == 90 &&
            roomSectionMovement.downAngle == 180)
        {
            //Asignaciones
            topCuadro = GameObject.Find("LVL1-Cuadro1");
            midCuadro = GameObject.Find("LVL1-Cuadro2");
            botCuadro = GameObject.Find("LVL1-Cuadro3");

            StartCoroutine(MoveCuadro(topCuadro.transform, 100, 1.5f));
            StartCoroutine(MoveCuadro(midCuadro.transform, 100, 1.5f));
            StartCoroutine(MoveCuadro(botCuadro.transform, 100, 1.5f));

            Debug.Log("CUADRO ALINEADO");

            //Puzzle resuelto, se asigna nuevo color
            puzzleMask = "dog";
        }
        else
        {
            Debug.Log("YA NO PUEDES INTERACTUAR");
        }
    }

    public void CurrentMaskPuzzle()
    {
        switch(puzzleMask)
        {
            case "white":
                WhiteMaskPuzzle();
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
