using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMad;
    public SpriteRenderer thisSprite; 
    void Start()
    {
        //check what npc thing is attached to 
        //
    }

    // Update is called once per frame
    void Update()
    {
        if(isMad == true){
            //start attacking 
            //start crying
            thisSprite.color = Color.red;
            isMad=false;
            //play audio que its like taking candy from a baby
        }
        if(isMad=false){
               thisSprite.color = Color.blue;
        }
    }
    void AttackPlayer(){
        //find player follow them until they get beat up


    

    }
}
