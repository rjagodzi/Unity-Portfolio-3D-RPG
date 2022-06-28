using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator anim;
    public int goldAmmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(InventoryItems.hasKey == true)
            {
                anim.SetTrigger("open");
                InventoryItems.gold += goldAmmount;
                goldAmmount = 0;
                Debug.Log("Gold: " + InventoryItems.gold);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.hasKey == true)
            {
                anim.SetTrigger("close");
            }
        }
    }

    public void DestroyChest()
    {
        Destroy(gameObject);
    }

}
