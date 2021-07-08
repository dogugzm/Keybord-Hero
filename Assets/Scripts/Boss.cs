using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossStates
{
    IDLE,
    ATTACK,
    DEATH
}


public class Boss : MonoBehaviour
{
    public Animator animator;
    public BossStates currentState;
    public GameObject BossDeathParticle;
    // Start is called before the first frame update
    void Start()
    {
        currentState = BossStates.IDLE;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState==BossStates.IDLE)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);

        }
        else if (currentState==BossStates.ATTACK)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Idle", false);

        }
        else if (currentState == BossStates.DEATH)
        {
            BossDeathParticle.SetActive(true);
            animator.SetBool("Death", true);
            animator.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = BossStates.ATTACK;
            
        }
    }

    
}
