using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfDamage : Damage
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        for(int i=1;i<4;i++){
            SE.Add(Resources.Load<AudioClip>("Sound/wolf0"+i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(isAttack){

            if(other.gameObject.tag=="Player" || other.gameObject.tag=="Boar"){
                other.SendMessageUpwards("Damage",true,SendMessageOptions.DontRequireReceiver);
                other.SendMessage("HpBar",damage*0.1f,SendMessageOptions.DontRequireReceiver);
                StartCoroutine(EnterAttack());
            }
            
        }
    }
    IEnumerator EnterAttack(){
        yield return new WaitForSeconds(1.5f);
        audio.Pause();
        isAttack=false;
    }
    public override void Attack(bool attack){
        base.Attack(attack);
        audio.clip=SE[0];
        audio.Play();
    }

}
