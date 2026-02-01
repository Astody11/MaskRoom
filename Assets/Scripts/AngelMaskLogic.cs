using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngelMaskLogic : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
