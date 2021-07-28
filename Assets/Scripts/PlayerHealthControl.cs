using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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
        //Player.AddNoise(1, 1, 0.5f);
        Player.Box.GetComponent<TextMeshPro>().text = Player.Box.GetComponent<TextMeshPro>().text.Substring(0,Player.Box.GetComponent<TextMeshPro>().text.Length - 3);
        Player.letterLists.RemoveRange(Player.letterLists.Count - 4,3);
        Player.Chat.transform.DOScale(new Vector3(Player.Chat.transform.localScale.x - 0.05f, Player.Chat.transform.localScale.y, Player.Chat.transform.localScale.z), 1f); //sadece x ekseininde scale ettim.
        Player.Box.GetComponent<TextMeshPro>().margin = new Vector4(Player.Box.GetComponent<TextMeshPro>().margin.x + 0.5f, Player.Box.GetComponent<TextMeshPro>().margin.y, Player.Box.GetComponent<TextMeshPro>().margin.z + 0.5f, Player.Box.GetComponent<TextMeshPro>().margin.w);// text marginini de scale ederek güzel gözükmesini saðladýk
    }
}
