using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachSectionManager : MonoBehaviour
{

    public bool isLocked;

    public string color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchLocked()
    {
        if (isLocked == false)
        {
            isLocked = true;
            Debug.Log("Sección bloqueada");
        }
        else
        {
            isLocked = false;
            Debug.Log("Sección desbloqueada");
        }
    }
}
