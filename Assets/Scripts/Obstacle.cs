using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class Obstacle : MonoBehaviour
{
    public ParticleSystem Explosion;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.CompareTag("Obstacle"))
        //{
        //    StartCoroutine(ObstacleMovement());
        //}
        

    }

    


    //public IEnumerator ObstacleMovement()
    //{
    //    if (!DOTween.IsTweening(transform))
    //    {
    //        transform.DORotate(transform.eulerAngles + new Vector3(0, 0, 80), 0.7f);
    //        yield return new WaitForSeconds(0.7f);
    //        transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0), 0.7f);
    //        yield return new WaitForSeconds(0f);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayExplosion());
        }
    }

    public IEnumerator PlayExplosion()
    {
        yield return new WaitForSeconds(0f);
        Explosion.Play();

    }


}
