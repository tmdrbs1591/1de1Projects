using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverActivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> childObjectsToToggle;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToggleChildObjects(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToggleChildObjects(false);
    }

    private void ToggleChildObjects(bool state)
    {
        foreach (GameObject child in childObjectsToToggle)
        {
            AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.3f, 1.3f), 1);
            child.SetActive(state);
        }
    }
}
