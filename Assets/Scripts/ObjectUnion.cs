using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnion : MonoBehaviour
{

    public GameObject upSection;
    public GameObject middleSection;
    public GameObject downSection;

    private string currentMask = "";
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
        currentMask = gameObject.name;
    }

    
    void Update()
    {
        
    }

    public void CurrentMaskName(string currentMaskName)
    {
        currentMask = currentMaskName;
    }
    public void WhiteMaskPuzzle()
    {
        if (roomSectionMovement.upAngle == 0 &&
                    roomSectionMovement.middleAngle == 90 &&
                    roomSectionMovement.downAngle == 180)
        {
            topCuadro.SetActive(false);
            midCuadro.SetActive(false);
            botCuadro.SetActive(false);
            fullCuadro.SetActive(true);
            //if(fullCuadro.)
        }
        else
        {
            Debug.Log("YA NO PUEDES INTERACTUAR");
        }
    }

    public void CurrentMaskPuzzle()
    {
        switch(currentMask)
        {
            case "white":
                WhiteMaskPuzzle();
                
                break;
        }
    }
}
