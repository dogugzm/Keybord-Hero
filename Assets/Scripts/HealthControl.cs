using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    int bossMaxHealth=100;
    public int bossCurrentHealth;
    public Boss Boss;
    public PlayerController Player;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
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
}
