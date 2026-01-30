using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSectionMovement : MonoBehaviour
{

    public GameObject roomSection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RoomRotation(-90);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            RoomRotation(90);
        }
    }

    void RoomRotation(int angle)
    {
        roomSection.transform.Rotate(0, angle, 0);
    }
}
