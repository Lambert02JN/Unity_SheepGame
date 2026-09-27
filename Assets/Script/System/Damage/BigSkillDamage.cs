using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSkillDamage : Damage
{
    protected override void Start()
    {
        if(self==null){
            self=GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Wolf"||other.gameObject.tag=="Boar"){
            other.SendMessageUpwards("Damage",true,SendMessageOptions.DontRequireReceiver);
            other.SendMessage("enemyBar",true,SendMessageOptions.DontRequireReceiver);
            other.SendMessage("HpBar",damage*0.1f,SendMessageOptions.DontRequireReceiver);
        }
    }
}
