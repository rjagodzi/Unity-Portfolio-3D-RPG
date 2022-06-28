using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //Two methods that prevent character movement when the cursor is pointing at the inventory icon

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Time.timeScale == 1)
        {
            PlayerMovement.canMove = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(Time.timeScale == 1)
        {
            PlayerMovement.canMove = true;
        }
    }
}
