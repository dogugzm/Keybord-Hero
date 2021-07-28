using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    Animator anim;
    int bossMaxHealth=100;
    public int bossCurrentHealth;
    public Boss Boss;
    public PlayerController Player;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bossCurrentHealth = bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCurrentHealth<0)
        {
            Boss.currentState = BossStates.DEATH;

            healthBar.SetSize(0f);
            Player.currentState = PlayerState.VICTORY;
            //ve oyunu bitir.
        }
        else
        {
            healthBar.SetSize(bossCurrentHealth*0.01f);
        }
    }

    public void DropHealth()
    {
        bossCurrentHealth -= 40;
    }
    public IEnumerator HitBoss()
    {
        Boss.currentState = BossStates.HIT;
        yield return new WaitForSeconds(1.2f);
        Boss.currentState = BossStates.ATTACK;
    }
    public IEnumerator WaitSecond()
    {
        anim.enabled = false;
        yield return new WaitForSeconds(3f);
        anim.enabled = true;

    }
}
