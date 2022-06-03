using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public GameObject[] characters;
    private int player = 0;
    public Text pName;
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
        if (player < characters.Length -1)
        {
            characters[player].SetActive(false);
            player++;
            characters[player].SetActive(true);
        }
    }

    public void Back()
    {
        if (player > 0)
        {
            characters[player].SetActive(false);
            player--;
            characters[player].SetActive(true);
        }
    }

    public void Accept()
    {
        SaveScript.playerCharacter = player;
        SaveScript.playerName = pName.text;
        SceneManager.LoadScene(1);
    }

}
