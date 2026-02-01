using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaskEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject playerVision;

    [SerializeField]
    private GameObject upParticles;
    [SerializeField]
    private GameObject midParticles;
    [SerializeField]
    private GameObject downParticles;

    [SerializeField] private Slider barra;
    [SerializeField] private float duracionBarra = 30f;
    [SerializeField] private string escenaACargar;
    private Coroutine sliderRoutine;

    private Image visionImage; // Image del panel

    void Start()
    {
        barra.value = 1f;
        barra.gameObject.SetActive(false);

        // Obtiene el Image del panel para controlar alfa
        if (playerVision != null)
            visionImage = playerVision.GetComponent<Image>();
    }

    public void EffectSelection(string color)
    {
        switch (color)
        {
            case "dog":
                upParticles.SetActive(true);
                midParticles.SetActive(true);
                downParticles.SetActive(true);
                Debug.Log("dog");
                break;

            case "lamb":
                if (playerVision != null)
                    playerVision.SetActive(true);

                lambTimeCounter();
                Debug.Log("lamb");
                break;

            default:
                upParticles.SetActive(false);
                midParticles.SetActive(false);
                downParticles.SetActive(false);
                break;
        }
    }

    // Lógica de la barra
    public void lambTimeCounter()
    {
        // Evita que se lance dos veces
        if (sliderRoutine != null)
            StopCoroutine(sliderRoutine);

        sliderRoutine = StartCoroutine(ContarTiempo());
    }

    IEnumerator ContarTiempo()
    {
        float tiempoActual = duracionBarra;
        barra.gameObject.SetActive(true);

        // Asegura que empieza transparente
        if (visionImage != null)
        {
            Color startColor = visionImage.color;
            startColor.a = 0f;
            visionImage.color = startColor;
        }

        while (tiempoActual > 0f)
        {
            tiempoActual -= Time.deltaTime;

            // Barra: 1 → 0
            barra.value = tiempoActual / duracionBarra;

            // Panel: 0 → 1
            if (visionImage != null)
            {
                Color c = visionImage.color;
                c.a = 1f - barra.value;
                visionImage.color = c;
            }

            yield return null;
        }

        barra.value = 0f;

        // Asegura que queda completamente opaco
        if (visionImage != null)
        {
            Color c = visionImage.color;
            c.a = 1f;
            visionImage.color = c;
        }

        CambiarEscena();
    }

    public void DetenerCuenta()
    {
        if (sliderRoutine != null)
        {
            StopCoroutine(sliderRoutine);
            sliderRoutine = null;
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}

