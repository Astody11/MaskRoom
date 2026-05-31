using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : MonoBehaviour
{
    public string buttonNumber;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void OnMouseDown()
    {
        gameManager.GetComponent<SafePuzzleManager>().safePuzzle(buttonNumber);
    }
}
