using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarDamage : Damage
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        for(int i=1;i<3;i++){
            SE.Add(Resources.Load<AudioClip>("Sound/boar0"+i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(isAttack){

            if(other.gameObject.tag=="Player" || other.gameObject.tag=="Wolf"){
                other.SendMessageUpwards("Damage",true,SendMessageOptions.DontRequireReceiver);
                other.SendMessage("HpBar",damage*0.1f,SendMessageOptions.DontRequireReceiver);
                StartCoroutine(EnterAttack());
            }
        }

    }
    IEnumerator EnterAttack(){
        yield return new WaitForSeconds(1f);
        isAttack=false;
    }
    public override void Attack(bool attack){
        audio.clip=SE[0];
        audio.Play();
        base.Attack(attack);
    }
}
