using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartMask : MonoBehaviour
{

    [SerializeField]
    public Button maskButton;
    [SerializeField]
    public Transform inventory;

    [SerializeField]
    private GameObject GameController;

    [SerializeField]
    public GameObject upPart;
    [SerializeField]
    public GameObject midPart;
    [SerializeField]
    public GameObject downPart;

    [SerializeField]
    private string color;

    // Start is called before the first frame update
    void Start()
    {
        AddButtonToInventory(color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddButtonToInventory(string bColor)
    {
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
        newButton.onClick.AddListener(() => { 
            partChange.MaskButtonAction(bColor);
            objectUnion.CurrentMaskName(bColor);
        });
    }


}
