using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarControl : Animal
{
    // Start is called before the first frame update
    private List<GameObject> _targers=new List<GameObject>();
    protected override void Start()
    {
        base.Start();
        //enemyHp=transform.Find("boar_collider/Canvas/Bar").gameObject;
        foreach (var item in GameObject.FindGameObjectsWithTag("Lettuce"))
        {
            _targers.Add(item);
        }
        target=_targers[Random.Range(0,3)];
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(bar.hp<=0){
            gameObject.tag="Boar";
        }
    }
    protected override void Move(){

        transform.Translate(Vector3.forward * Time.deltaTime * 2);
        
        distTarget= Vector3.Distance(transform.position, target.transform.position);
        
        if(!_isRandom && time>=2f){
            x=Random.Range(12,30);
            z=Random.Range(-42,-22);
            _isRandom=true;
        }
        base.Move();

        if(distTarget < searchRange){//see
			transform.LookAt(target.transform);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //attack Range
            if(hit){
                anim.Play("getHit");
                StartCoroutine(wait());
                return;
            }
			if (distTarget < attackRange)
			{
                if(!damage.isAttack){
                    anim.Play("attack1");
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
    void OnTriggerEnter(Collider other)
    {
       if(hit){
            target=other.gameObject;
        }
    }

    public override void Damage(bool value){
        base.Damage(damage);
    }
    protected override IEnumerator wait(){
        yield return StartCoroutine(base.wait());
    }

    protected override void OnDrawGizmosSelected () {
		base.OnDrawGizmosSelected();		
	}
}
