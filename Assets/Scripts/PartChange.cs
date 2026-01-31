using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartChange : MonoBehaviour
{
    [SerializeField] private PartMask mask;

    [SerializeField] private Transform upEmpty;
    [SerializeField] private Transform midEmpty;
    [SerializeField] private Transform downEmpty;

    public void MaskButtonAction(string color)
    {
        if (mask == null)
        {
            Debug.LogError("MASK COMPONENT ES NULL", this);
            return;
        }

        switch (color)
        {
            case "red":
                ChangePart(mask.upPart, mask.midPart, mask.downPart);
                break;
        }
    }

    public void ChangePart(GameObject upPart, GameObject midPart, GameObject downPart)
    {
        foreach (Transform child in upEmpty)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in midEmpty)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in downEmpty)
        {
            Destroy(child.gameObject);
        }

        Instantiate(upPart, upEmpty).transform.localPosition = Vector3.zero;
        Instantiate(midPart, midEmpty).transform.localPosition = Vector3.zero;
        Instantiate(downPart, downEmpty).transform.localPosition = Vector3.zero;
    }
}