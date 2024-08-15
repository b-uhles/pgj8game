using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 6;
    [SerializeField] private int maxHealth = 6;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(amount < 0f)
            throw new System.ArgumentOutOfRangeException("Damage cant be negative!");
        
        this.health -= amount;
        if(health < 0f) Die();
    }
    public void Heal(int amount)
    {
        if(amount < 0f)
            throw new System.ArgumentOutOfRangeException("Heal cant be negative!");
        

        if(health+amount>maxHealth)
            this.health = maxHealth;
        else
            this.health+=amount;
    }

    private void Die(){
        Debug.Log("dead");
        Destroy(gameObject);
    }
}
