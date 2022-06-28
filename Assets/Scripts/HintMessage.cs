using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject hintBox;
    public Text message;
    private bool displaying = true;
    private bool overIcon = false;
    public int objectType = 0;

    private Vector3 screenPoint;
    public GameObject theCanvas;
    public Sprite cursorBasic;
    public Sprite cursorHand;
    public Image cursorImage;

    public GameObject inventoryObject;
    public bool magic = false;
    public bool spells = false;
    public bool left = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if(displaying == true)
        {
            cursorImage.sprite = cursorHand;
            hintBox.SetActive(true);
            //'left' variable enables the hint message to appear on the left for the far right icons
            if(left == true)
            {
                screenPoint.x = Input.mousePosition.x + 500;
            }
            if(left == false)
            {
                screenPoint.x = Input.mousePosition.x - 500;
            }
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursorImage.sprite = cursorBasic;
        overIcon = false;
        hintBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hintBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(overIcon == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);

                if(magic == true)
                {
                    //the 'if' statement prevents an error - after clicking an empty slot the value of object type is -20 (out of bounds exception)
                    if(objectType != 0)
                    {
                        //object type for magic attacks starts at 20, so it is necessary to substract 20 from the objectType to reset the value
                        inventoryObject.GetComponent<InventoryItems>().selected = objectType - 20;
                        inventoryObject.GetComponent<InventoryItems>().set = true;
                    }                  
                }

                if (spells == true)
                {
                    if (objectType != 0)
                    {
                        inventoryObject.GetComponent<InventoryItems>().selected = objectType - 30;
                        inventoryObject.GetComponent<InventoryItems>().setTwo = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }

    void MessageDisplay()
    {
        if(objectType == 0)
        {
            message.text = "empty";
        }

        if(objectType == 1)
        {
            message.text = InventoryItems.redMushrooms.ToString() + " red mushrooms used in potions";
        }

        if (objectType == 2)
        {
            message.text = InventoryItems.purpleMushrooms.ToString() + " purple mushrooms used in potions";
        }

        if (objectType == 3)
        {
            message.text = InventoryItems.brownMushrooms.ToString() + " brown mushrooms used in potions";
        }

        if (objectType == 4)
        {
            message.text = InventoryItems.blueFlowers.ToString() + " blue flowers used in potions";
        }

        if (objectType == 5)
        {
            message.text = InventoryItems.redFlowers.ToString() + " red flowers used in potions";
        }

        if (objectType == 6)
        {
            message.text = InventoryItems.roots.ToString() + " roots used in potions";
        }

        if (objectType == 7)
        {
            message.text = InventoryItems.leafDew.ToString() + " leaf dews used in potions";
        }

        if (objectType == 8)
        {
            message.text = "A key to open chests";
        }

        if (objectType == 9)
        {
            message.text = InventoryItems.pinkEgg.ToString() + " pink eggs used in potions";
        }

        if (objectType == 10)
        {
            message.text = InventoryItems.bluePotion.ToString() + " blue potions";
        }

        if (objectType == 11)
        {
            message.text = InventoryItems.purplePotion.ToString() + " purple potions";
        }

        if (objectType == 12)
        {
            message.text = InventoryItems.greenPotion.ToString() + " green potions";
        }

        if (objectType == 13)
        {
            message.text = InventoryItems.redPotion.ToString() + " red potions";
        }

        if (objectType == 14)
        {
            message.text = InventoryItems.bread.ToString() + " loafs of bread to replenish health";
        }

        if (objectType == 15)
        {
            message.text = InventoryItems.cheese.ToString() + " blocks of cheese to replenish health";
        }

        if (objectType == 16)
        {
            message.text = InventoryItems.meat.ToString() + " pieces of meat to replenish health";
        }

        if (objectType == 20)
        {
            message.text = "Explosive fire attack";
        }

        if (objectType == 21)
        {
            message.text = "Replenishes full health";
        }

        if (objectType == 22)
        {
            message.text = "Become invisible, drains mana";
        }

        if (objectType == 23)
        {
            message.text = "Become invulnerable, drains mana";
        }

        if (objectType == 24)
        {
            message.text = "Double strength, drains mana";
        }

        if (objectType == 25)
        {
            message.text = "Swirl attack";
        }

        if (objectType == 30)
        {
            message.text = "Spell 1";
        }

        if (objectType == 31)
        {
            message.text = "Spell 2";
        }

        if (objectType == 32)
        {
            message.text = "Spell 3";
        }

        if (objectType == 33)
        {
            message.text = "Spell 4";
        }

        if (objectType == 34)
        {
            message.text = "Spell 5";
        }

        if (objectType == 35)
        {
            message.text = "Spell 6";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        theCanvas.GetComponent<CreatePotion>().thisValue = objectType;
        theCanvas.GetComponent<CreatePotion>().UpdateValues();
    }
}
