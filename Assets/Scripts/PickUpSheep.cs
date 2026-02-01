using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSheep : MonoBehaviour
{
    private bool hasBeenClicked = false;

    [SerializeField]
    GameObject GameManager;

    private void Start()
    {
        GameManager= GameObject.FindGameObjectWithTag("GameManager");
    }

    void OnMouseDown()
    {
        hasBeenClicked = true;
        GameManager.GetComponent<CountSheeps>().sheepsPickedUp += 1;
        Debug.Log("Una oveja pillada: " + GameManager.GetComponent<CountSheeps>().sheepsPickedUp);
        if (GameManager.GetComponent<CountSheeps>().sheepsPickedUp >= 6)
        {
            GameManager.GetComponent<CountSheeps>().AllSheepsPicked();
        }
        gameObject.SetActive(false);
    }
}
