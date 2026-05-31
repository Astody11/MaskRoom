using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePuzzleManager : MonoBehaviour
{

    public GameObject safeDoor;
    public GameObject safeHandle;
    public GameObject safeButton1;
    public GameObject safeButton2;
    public GameObject safeButton3;
    public GameObject lambMaskObject;

    public string correctCombination = "223";
    public string currentCombination;

    public void safePuzzle(string number)
    {
        IFindEverything();
        // Añade el número pulsado
        currentCombination += number;
        Debug.Log("Combinación actual: " + currentCombination);

        // Comprobación parcial:
        // Si lo que llevamos NO coincide con el inicio de la combinación correcta → reset
        if (!correctCombination.StartsWith(currentCombination))
        {
            Debug.Log("Combinación incorrecta → reset");
            currentCombination = "";
            return;
        }

        // Si ya tiene la longitud correcta y coincide → resuelto
        if (currentCombination.Length == correctCombination.Length)
        {
            Debug.Log("Caja fuerte abierta");
            safeSolved();
            currentCombination = "";
        }
    }

    public void safeSolved()
    {
        IFindEverything();
        //lambMaskObject = GameObject.Find("LambMaskObject");
        safeDoor.SetActive(false);
        safeHandle.SetActive(false);
        safeButton1.SetActive(false);
        safeButton2.SetActive(false);
        safeButton3.SetActive(false);
        //lambMaskObject = GameObject.FindGameObjectWithTag("LambMaskObject");
        lambMaskObject.SetActive(true);
    }

    public void IFindEverything()
    {
        safeDoor = GameObject.Find("LVL2-BisagrasFortes");
        safeHandle = GameObject.Find("LVL2-BolaForte");
        safeButton1 = GameObject.Find("LVL2-BotonForte1");
        safeButton2 = GameObject.Find("LVL2-BotonForte2");
        safeButton3 = GameObject.Find("LVL2-BotonForte3");

    }
}
