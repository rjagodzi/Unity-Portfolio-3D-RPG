using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePotion : MonoBehaviour
{
    public int[] values;
    [HideInInspector]
    public int expectedValue;
    [HideInInspector]
    public int value;
    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;
    [HideInInspector]
    public int itemID = 0;
    private int max;
    [HideInInspector]
    public int thisValue;
    //'maxx' created just in case, so the loop doesn't colide with 'max'
    private int maxx;

    // Start is called before the first frame update
    void Start()
    {
        expectedValue = values[0];
        max = emptySlots.Length;
        maxx = emptySlots.Length;
        //method Create() is called right away, because during the potion creation it is necessary
        //to click twice on the 'create' button when creating a potion for the first time.
        //This enbales the player to create potions instantly
        Create();
    }

    public void Create()
    {
        if(expectedValue == value)
        {
            for(int i = 0; i < max; i++)
            {
                if(emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[itemID];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = itemID + 20;
                    value = 0;
                    thisValue = 0;
                }
            }

            max = emptySlots.Length;
        }
    }

    public void Remove(int index)
    {
        for(int i = 0; i < maxx; i++)
        {
            if(emptySlots[i].sprite == icons[index])
            {
                maxx = i;
                emptySlots[i].sprite = emptyIcon;
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxx = emptySlots.Length;
    }

    public void UpdateValues()
    {
        value += thisValue;
        expectedValue = values[itemID];
    }
}
