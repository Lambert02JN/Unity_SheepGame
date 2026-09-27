using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfControl : Animal
{
    public GameObject boar;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //enemyHp=transform.Find("wolf_collider/Canvas/Bar").gameObject;
        // foreach(var index in GameObject.FindGameObjectsWithTag("BoarEnemy")){
        //     boar.Add(index);            
        // }
        boar=GameObject.FindGameObjectWithTag("BoarEnemy");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(boar.tag=="Boar"){
            boar=GameObject.FindGameObjectWithTag("BoarEnemy");
            if(boar==null){
                boar=target=player;
            }
        }

        
    }

    float distance;
    float distBoar;

    protected override void Move(){
        distance = Vector3.Distance(transform.position, player.transform.position);
        // for(int i=0;i<4;i++){
        //     distBoar[i] = Vector3.Distance(transform.position, boar[i].transform.position);
        //     if(distBoar[i]<distance){
        //         target=boar[i];
        //     }
        // }
        distBoar = Vector3.Distance(transform.position, boar.transform.position);
        target= distance > distBoar ? boar : player;

        distTarget= Vector3.Distance(transform.position, target.transform.position);
        if(!_isRandom && time>=2f){
            x=Random.Range(-20,-8);
            z=Random.Range(-48,-55);
            _isRandom=true;
        }
        base.Move();

        if(distTarget < searchRange){//see
			transform.LookAt(target.transform);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //attack Range
            if(hit){
                anim.Play("Beaten");
                StartCoroutine(wait());
                return;
            }
			if (distTarget < attackRange)
			{
                if(!damage.isAttack){
                    anim.Play("Attack1");
                    BroadcastMessage("Attack",true,SendMessageOptions.DontRequireReceiver);
                }							
			}
			else
			{		
				transform.Translate(Vector3.forward * Time.deltaTime * 5);
				anim.Play("run");
			}	
		}
        
    }
    public override void Damage(bool value){
        base.Damage(damage);
    }
    protected override IEnumerator wait(){
        yield return StartCoroutine(base.wait());
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.name=="fenceBroken01_collider"){
            other.gameObject.GetComponent<Rigidbody>().isKinematic=false;
            Destroy(other.transform.parent.gameObject,5f);
        }
    }
    protected override void OnDrawGizmosSelected () {
		base.OnDrawGizmosSelected();		
	}
}
