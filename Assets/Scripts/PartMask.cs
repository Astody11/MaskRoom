using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartMask : MonoBehaviour
{

    [SerializeField]
    public Button maskButton;
    [SerializeField]
    public Transform inventory;

    [SerializeField]
    public GameObject upPart;
    [SerializeField]
    public GameObject midPart;
    [SerializeField]
    public GameObject downPart;

    [SerializeField]
    public string color;

    [SerializeField]
    public bool maskIsCaught;

    [SerializeField]
    private AudioClip maskSong;

    private GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        inventory = GameObject.FindGameObjectWithTag("Inventory").transform;
        if (maskIsCaught)
        {
            AddButtonToInventory(color);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddButtonToInventory(string bColor)
    {
        ChangeSong();

        // 1️⃣ Instanciar el botón
        Button newButton = Instantiate(maskButton, inventory);

        // 2️⃣ Limpiar listeners del prefab
        newButton.onClick.RemoveAllListeners();

        // 3️⃣ Buscar el GameManager por tag
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        if (gm == null)
        {
            Debug.LogError("No se encontró GameManager en la escena!");
            return;
        }

        // 4️⃣ Obtener el script PartChange del GameManager
        PartChange partChange = gm.GetComponent<PartChange>();
        ObjectUnion objectUnion = gm.GetComponent<ObjectUnion>();
        if (partChange == null)
        {
            Debug.LogError("GameManager no tiene el script PartChange!");
            return;
        }

        // 5️⃣ Asignar el onClick dinámicamente
        newButton.onClick.AddListener(() => partChange.MaskButtonAction(GetComponent<PartMask>()));


        // Cambiar texto del botón
        TMP_Text text = newButton.GetComponentInChildren<TMP_Text>();
        if (text != null)
        {
            text.text = "";
        }
        else
        {
            Debug.LogError("El botón no tiene TMP_Text");
        }
    }

    public void ChangeSong()
    {
        GameManager.GetComponent<MusicManager>().currentClip = maskSong;
        GameManager.GetComponent<MusicManager>().PlayMusic(maskSong);
    }
}
