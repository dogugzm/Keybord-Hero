using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chase : MonoBehaviour
{

    public GameObject Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 2;
    bool isChase = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isChase)
        {
            transform.DOMove(Player.transform.position, 2f);
            //bir önceki letter ý takip et
           // transform.DOMove(Player.GetComponent<PlayerController>().letterLists[Player.GetComponent<PlayerController>().letterLists.Count - 2].transform.position, 1f);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(Wait(1f));
            isChase = true;
        }
    }
    
    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(1f);
    } 
    

    public void ChasePlayer()
    {
        //transform.LookAt(Player);
        

        

        

        
    }
}
