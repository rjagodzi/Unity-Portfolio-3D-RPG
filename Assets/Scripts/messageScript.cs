using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class messageScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    //Color32 controlls Alpha in addition to RGB. The Alpha on the buttons in the speechbox are set to 0
    //so when a type Color is used, it will automatically assume the Alpha should be zero. That's why Color 32 is needed
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] shopUI;
    [HideInInspector]
    public int shopNum = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMovement.canMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMovement.canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        shopOwnerMessage.text = "hello " + SaveScript.playerName + " how can i help you";
    }

   public void Message1()
    {
        shopOwnerMessage.text = "not much going on around here";
    }

    public void Message2()
    {
        shopOwnerMessage.text = "select items from the list";
        shopUI[shopNum].SetActive(true);
        shopUI[shopNum].GetComponent<BuyScript>().UpdateGold();
    }
    private void Update()
    {
        if(PlayerMovement.canMove == true && PlayerMovement.moving == true)
        {
            if (shopUI != null)
            {
                shopUI[shopNum].SetActive(false);
            }
        } 
    }
}
