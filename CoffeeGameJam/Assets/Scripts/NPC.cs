using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //variables
    public SpriteRenderer thisSprite;
    public Sprite Emote;     
    //state variables
    public bool isHappy = true;
    //NPC movement Variables
    void Start()
    {
      //get component npctype info
    }
    // Update is called once per frame
    void Update()
    {
        //check the state of NPC's and do things
        if(isHappy == true){
            
        }
      
    }

    public void CasualMovement(){


    }
    public void AttackPlayer(){
        //find player follow them until they get beat 
    }

    public void BecomeSad(){
        isHappy = false;
        thisSprite.color = Color.black;
        //play sad particles
        //explode 
        //destroy particles
    }
    public void NPCMovement(){
        //running  



    }
}
