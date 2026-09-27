using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : Damage
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        for(int i=1;i<5;i++){
            SE.Add(Resources.Load<AudioClip>("Sound/Player0"+i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(isAttack){
            //audio.PlayOneShot(attackSE);
            if(other.gameObject.tag=="Wolf"|| other.gameObject.tag=="Boar"){
                other.SendMessageUpwards("Damage",true,SendMessageOptions.DontRequireReceiver);
                other.SendMessage("enemyBar",true,SendMessageOptions.DontRequireReceiver);
                other.SendMessage("HpBar",damage*0.1f,SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    public override void Attack(bool attack){
        base.Attack(attack);
        if(attack){
            audio.clip=SE[0];
            audio.Play();
        }
    }
    public override void Skill(bool skill){
        base.Skill(skill);
        if(skill){
            audio.clip=SE[1];
            audio.Play();
        }
        
    }
    public override void BigSkill(bool bigSkill){
        base.BigSkill(bigSkill);
        if(bigSkill){
            audio.clip=SE[2];
            audio.Play();
        }
        
    }
}
