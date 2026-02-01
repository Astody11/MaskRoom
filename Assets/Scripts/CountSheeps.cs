using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSheeps : MonoBehaviour
{
    public int sheepsPickedUp;
    public GameObject angelMask;

    // Start is called before the first frame update
    void Start()
    {
        sheepsPickedUp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllSheepsPicked()
    {
        angelMask.SetActive(true);
    }
}
