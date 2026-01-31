using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSection : MonoBehaviour
{

    public string lockSectionString = "UP";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockRoomPart(int angleRotation)
    {
        switch (lockSectionString)
        {
            case "UP":
                

                break;
            case "MIDDLE":
                
                break;
            case "DOWN":
                
                break;
        }
    }
}
