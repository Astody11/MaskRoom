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

    public void MaskButtonAction(PartMask currentMask)
    {
        mask = currentMask;

        if (mask == null)
        {
            Debug.LogError("MASK COMPONENT ES NULL", this);
            return;
        }

        
        ChangePart(mask.upPart, mask.midPart, mask.downPart);
        
    }

    public void ChangePart(GameObject upPart, GameObject midPart, GameObject downPart)
    {
        if (upEmpty.GetComponent<EachSectionManager>().isLocked == false)
        {
            foreach (Transform child in upEmpty)
            {
                Destroy(child.gameObject);
            }

            Instantiate(upPart, upEmpty).transform.localPosition = Vector3.zero;

        }
        if (midEmpty.GetComponent<EachSectionManager>().isLocked == false)
        {
            foreach (Transform child in midEmpty)
            {
                Destroy(child.gameObject);
            }

            Instantiate(midPart, midEmpty).transform.localPosition = Vector3.zero;
        }
        if (downEmpty.GetComponent<EachSectionManager>().isLocked == false)
        {
            foreach (Transform child in downEmpty)
            {
                Destroy(child.gameObject);
            }

            Instantiate(downPart, downEmpty).transform.localPosition = Vector3.zero;
        }
        
    }
}