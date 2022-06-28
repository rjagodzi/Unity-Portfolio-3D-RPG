using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject openedBook;
    public GameObject closedBook;
    public GameObject potionBook;

    public GameObject messageBox;

    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;

    public static int redMushrooms = 0;
    public static int purpleMushrooms = 0;
    public static int brownMushrooms = 0;
    public static int blueFlowers = 0;
    public static int redFlowers = 0;
    public static int roots = 0;
    public static int leafDew = 0;
    public static int key = 0;
    public static int pinkEgg = 0;
    public static int bluePotion = 0;
    public static int purplePotion = 0;
    public static int greenPotion = 0;
    public static int redPotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;

    public static bool hasKey = false;

    public static int newIcon = 0;
    public static int gold = 30000;
    public static bool iconUpdate = false;
    public int max;
    public GameObject theCanvas;
    [HideInInspector]
    public string entry;
    public string[] items;
    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmount = 0;
    //these two variables are created in case the 'max' variable conflicts with the first 'for loop'
    private int maxx;
    private int maxxx;

    public Image[] UISlots;
    public Sprite[] magicIcons;
    public Sprite[] spellIcons;
    public KeyCode[] keys;
    public bool set = false;
    //different 'set' for spells
    public bool setTwo = false;
    [HideInInspector]
    public int selected = 0;
    public int[] magicAttack;
    

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        openedBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(false);
        max = emptySlots.Length;
        maxx = items.Length;
        maxxx = emptySlots.Length;

        //TEMP
        redMushrooms = 0;
        purpleMushrooms = 0;
        brownMushrooms = 0;
        blueFlowers = 0;
        redFlowers = 0;
        roots = 0;
        leafDew = 0;
        key = 0;
        pinkEgg = 0;
        bluePotion = 0;
        purplePotion = 0;
        greenPotion = 0;
        redPotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(iconUpdate == true)
        {
            for(int i = 0; i < max; i++)
            {
                if(emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
            StartCoroutine(Reset());
        }
        
        if(set == true)
        {
            for(int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    set = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttack[i] = selected;
                    theCanvas.GetComponent<CreatePotion>().Remove(selected);
                }
            }
        }

        if (setTwo == true)
        {
            for (int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlots[i].sprite = spellIcons[selected];
                    //adding 6 to 'selected' variable enables the spell icons to occupy different slots
                    magicAttack[i] = selected += 6;
                }
            }
        }
    }

    public void CheckStatics()
    {
        for(int i = 0; i < maxx; i++)
        {
            if(i == currentID)
            {
                maxx = i;
                entry = items[i];
                checkAmount = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
                checkAmount--;
                typeof(InventoryItems).GetField(entry).SetValue(null, checkAmount);
                if(checkAmount == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        maxx = items.Length;
    }

    public void RemoveIcon(int iconType)
    {
        for(int i = 0; i < maxxx; i++)
        {
            if(emptySlots[i].sprite == icons[iconType])
            {
                maxxx = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxxx = emptySlots.Length;
    }

    public void OpenMenu()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        openedBook.SetActive(true);
        closedBook.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openedBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1;
    }

    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
    }

    public void ClosePotionBook()
    {
        theCanvas.GetComponent<CreatePotion>().value = 0;
        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
        potionBook.SetActive(false);
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;
    }

}
