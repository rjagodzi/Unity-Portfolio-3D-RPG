using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollect : MonoBehaviour
{
    public GameObject spellsUI;
    public GameObject magicUI;
    private bool magicCollected = false;
    private bool spellsCollected = false;
    public bool magicBook = false;
    public bool spellsBook = false;

    // Start is called before the first frame update
    void Start()
    {
        spellsUI.SetActive(false);
        magicUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(magicBook == true)
            {
                if(magicCollected == false)
                {
                    magicUI.SetActive(true);
                    magicCollected = true;
                }
            }

            if (spellsBook == true)
            {
                if (spellsCollected == false)
                {
                    spellsUI.SetActive(true);
                    spellsCollected = true;
                }
            }
        }
    }
}
