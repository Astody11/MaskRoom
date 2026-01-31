using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]
    private GameObject fullCuadro;

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
            topCuadro.SetActive(false);
            midCuadro.SetActive(false);
            botCuadro.SetActive(false);
            fullCuadro.SetActive(true);
            //if(fullCuadro.)
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
}
