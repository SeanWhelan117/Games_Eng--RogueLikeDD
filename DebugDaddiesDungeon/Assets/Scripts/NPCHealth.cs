using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Used for all NPCs, Example of Factory for handling all hp for enemies
///  Excludes Player, player is handled in player script.
///  
///
/// </summary>


public class NPCHealth : MonoBehaviour
{
    [Header("Objects and Scripts")]
    public XPBarScript xpBar;
    public Slider xpBarSlider;
    public GameObject npc;

    [Header("Variables")]
    public short health;

    private void Start()
    {
        assignHealthToNPC(); // This will assign health to the NPC, depending on the type of enemy!

        //Checking what level we are and assigning a level cap
        if(xpBar.level == 1)
        {
            xpBar.setMaxXP(100);
        }
    }

    public void assignHealthToNPC() // DO NOT EDIT LAYERS
    {
        if (npc.layer == 10) // 10th layer is GRUNT !!!!DO NOT EDIT!!!!
        {
            health = 10;
        }

        if (npc.layer == 11) // 11th layer is RANGED !!!!DO NOT EDIT!!!!
        {
            health = 15;
        }

        if (npc.layer == 12) // 12th layer is BRUTE !!!!DO NOT EDIT!!!!
        {
            health = 20;
        }

        if (npc.layer == 13) // 13th layer is BOSS !!!!DO NOT EDIT!!!!
        {
            health = 50;
        }
    }

    private void Update()
    {

        xpBarSlider.value = xpBar.currentXp;
    }

    public void setXpToNPC()
    {
        if (npc.layer == 10) // 10th layer is GRUNT !!!!DO NOT EDIT!!!!
        {
            xpBar.currentXp += 5;
            xpBar.setXP(xpBar.currentXp);
            Debug.Log("Giving XP");
        }

        if (npc.layer == 11) // 11th layer is RANGED !!!!DO NOT EDIT!!!!
        {
            xpBar.currentXp += 10;
            xpBar.setXP(xpBar.currentXp);
            Debug.Log("Giving XP Ranged ");
        }

        if (npc.layer == 12) // 12th layer is BRUTE !!!!DO NOT EDIT!!!!
        {
            xpBar.currentXp += 15;
            xpBar.setXP(xpBar.currentXp);
            Debug.Log("Giving XP");
        }

        if (npc.layer == 13) // 13th layer is BOSS !!!!DO NOT EDIT!!!!
        {
            xpBar.currentXp += 20;
            xpBar.setXP(xpBar.currentXp);
            Debug.Log("Giving XP");
        }
    }

    public void NPCTakesDamage(short t_health, short t_damage) // takes in the damage done by the player and the NPCs health
    {
        t_health -= t_damage;
        if (isNPCDead())
        {
            setXpToNPC();
            Destroy(npc);
        }
    

        //npc.health = t_health;  Placeholder for getting npcs health set after taking damage
        health = t_health;
    }

    bool isNPCDead() // checks if the NPC is dead and returns a true or false
    {
        if (health <= 0)
            return true;
        else
            return false;
    }
}
