using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : MonoBehaviour
{
    public GameObject[] characters;
    private int characterIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        if (characterIndex < characters.Length -1)
        {
            characters[characterIndex].SetActive(false);
            characterIndex++;
            characters[characterIndex].SetActive(true);
        }
    }

    public void Back()
    {
        if (characterIndex > 0)
        {
            characters[characterIndex].SetActive(false);
            characterIndex--;
            characters[characterIndex].SetActive(true);
        }
    }

}
