using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
        ChangePartType(mask.GetComponent<Mask>().maskColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePartType(string maskColor)
    {
        switch(maskColor)
        {
            case "red":
                Debug.Log("Color rojo");
                break;
            case "blue":
                Debug.Log("Color azul");
                break;
            case "green":
                Debug.Log("Color verde");
                break;
        }
    }
}
