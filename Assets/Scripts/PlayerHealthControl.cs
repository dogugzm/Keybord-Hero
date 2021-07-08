using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthControl : MonoBehaviour
{
    public PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropLetter()
    {
        Player.Box.GetComponent<TextMeshPro>().text = Player.Box.GetComponent<TextMeshPro>().text.Remove(Player.Box.GetComponent<TextMeshPro>().text.Length - 1);
        Player.letterLists.RemoveAt(Player.letterLists.Count - 1);
    }
}
