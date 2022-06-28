using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour
{
    public GameObject shopUI;

    public int[] amount;
    public int[] cost;
    public int[] iconNumber;
    public int[] inventoryItems;
    public Text[] itemAmountText;
    public Text currencyText;
    private Text compare;
    public bool tavern = false;
    private int max = 0;
    //'canClick' is necessary, so that the script allows to buy other items
    //even if the amount of one of them reaches 0
    private bool canClick = true;

    // Start is called before the first frame update
    void Start()
    {
        max = itemAmountText.Length;
        currencyText.text = InventoryItems.gold.ToString();
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void BuyButton()
    {
        if (canClick == true)
        {
            for (int i = 0; i < max; i++)
            {
                if (itemAmountText[i] == compare)
                {
                    max = i;
                    if (amount[i] > 0)
                    {
                        if (tavern == true)
                        {
                            UpdateTavernAmount();
                        }
                        else
                        {
                            UpdateWizardAmount();
                        }
                        if (InventoryItems.gold >= cost[i])
                        {
                            if (inventoryItems[i] == 0)
                            {
                                InventoryItems.newIcon = iconNumber[i];
                                InventoryItems.iconUpdate = true;
                            }
                            InventoryItems.gold -= cost[i];
                            if (tavern == true)
                            {
                                SetTavernAmount(i);
                            }
                            else
                            {
                                SetWizardAmount(i);
                            }
                        }
                    }
                }
            }
        }
    }

    void UpdateTavernAmount()
    {
        inventoryItems[0] = InventoryItems.bread;
        inventoryItems[1] = InventoryItems.cheese;
        inventoryItems[2] = InventoryItems.meat;
    }

    void UpdateWizardAmount()
    {
        inventoryItems[0] = InventoryItems.redPotion;
        inventoryItems[1] = InventoryItems.purplePotion;
        inventoryItems[2] = InventoryItems.bluePotion;
        inventoryItems[3] = InventoryItems.greenPotion;
        inventoryItems[4] = InventoryItems.pinkEgg;
        inventoryItems[5] = InventoryItems.roots;
        inventoryItems[6] = InventoryItems.leafDew;
    }

    public void UpdateGold()
    {
        currencyText.text = InventoryItems.gold.ToString();
    }

    void SetTavernAmount(int item)
    {
        if(item == 0)
        {
            InventoryItems.bread++;
        }
        if (item == 1)
        {
            InventoryItems.cheese++;
        }
        if (item == 2)
        {
            InventoryItems.meat++;
        }
        
        amount[item]--;
        itemAmountText[item].text = amount[item].ToString();
        currencyText.text = InventoryItems.gold.ToString();
        max = itemAmountText.Length;
    }

    void SetWizardAmount(int item)
    {
        if (item == 0)
        {
            InventoryItems.redPotion++;
        }
        if (item == 1)
        {
            InventoryItems.purplePotion++;
        }
        if (item == 2)
        {
            InventoryItems.bluePotion++;
        }
        if (item == 3)
        {
            InventoryItems.greenPotion++;
        }
        if (item == 4)
        {
            InventoryItems.pinkEgg++;
        }
        if (item == 5)
        {
            InventoryItems.roots++;
        }
        if (item == 6)
        {
            InventoryItems.leafDew++;
        }
        
        amount[item]--;
        itemAmountText[item].text = amount[item].ToString();
        currencyText.text = InventoryItems.gold.ToString();
        max = itemAmountText.Length;
    }

    public void Bread()
    {
        compare = itemAmountText[0];
        Check(0);
    }

    public void Cheese()
    {
        compare = itemAmountText[1];
        Check(1);
    }

    public void Meat()
    {
        compare = itemAmountText[2];
        Check(2);
    }

    public void RedPotion()
    {
        compare = itemAmountText[0];
        Check2(0);
    }

    public void PurplePotion()
    {
        compare = itemAmountText[1];
        Check2(1);
    }

    public void BluePotion()
    {
        compare = itemAmountText[2];
        Check2(2);
    }

    public void GreenPotion()
    {
        compare = itemAmountText[3];
        Check2(3);
    }

    public void DragonEgg()
    {
        compare = itemAmountText[4];
        Check2(4);
    }

    public void Root()
    {
        compare = itemAmountText[5];
        Check2(5);
    }

    public void Dew()
    {
        compare = itemAmountText[6];
        Check2(6);
    }

    void Check(int c)
    {
        if(amount[c] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }

    void Check2(int d)
    {
        if (amount[d] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }
}
