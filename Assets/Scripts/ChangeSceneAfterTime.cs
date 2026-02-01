using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTime : MonoBehaviour
{
    [SerializeField] private float tiempo = 7f;
    [SerializeField] private string escenaACargar;

    void Start()
    {
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("MainMenu");
    }
}