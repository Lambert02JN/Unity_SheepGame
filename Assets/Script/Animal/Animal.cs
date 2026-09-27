using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    protected GameObject enemyHp;
    protected GameObject player;
    protected PlayerControl playerControl;
    protected Animation anim;
    protected Damage damage;
    protected float angle;
    protected BarManager bar;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animation>();
        damage=GetComponentInChildren<Damage>();
        angle=Mathf.Cos(Mathf.PI/4f);
        bar=gameObject.GetComponentInChildren<BarManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(player==null){
            player=GameObject.FindGameObjectWithTag("Player");
            playerControl=player.GetComponent<PlayerControl>();
        }
        //death
        if(death && !dieAnim){
            anim.Play("death");
            damage.audio.clip=damage.SE[1];
            damage.audio.Play();
            death=false;
            dieAnim=true;
        }
        if(bar.hp>=0){
            Move();
        }
    }
    protected int x;
    protected int z;
    [SerializeField]protected GameObject target;
    protected float distTarget;
    protected bool _isRandom;
    protected float time;
    public bool death{get;set;}
    private bool dieAnim;
    protected virtual void Move(){
        
        if(distTarget > searchRange){
            if(!_isRandom){
            anim.Play("Standby");
            time+=Time.deltaTime;
            }
            if(_isRandom){
                Vector3 nextPos=new Vector3(x,transform.position.y,z);
                transform.LookAt(nextPos);
                transform.Translate(Vector3.forward * Time.deltaTime * 2);
                anim.Play("walk");
                float dist= Vector3.Distance(transform.position, nextPos);
                if(dist<0.1f){
                    _isRandom=false;
                    time=0;
                }

            }
        }
    }

    protected bool hit;
    public virtual void Damage(bool value){
        hit=value;
    }
    protected virtual IEnumerator wait(){
        yield return new WaitForSeconds(1f);
        hit=false;
    }

    [Header("DrawGizmos")]
    public float searchRange;
	public float attackRange;
    protected virtual void OnDrawGizmosSelected () {
		Gizmos.color = Color.green;
		//searchRange
		Gizmos.DrawWireSphere (transform.position, searchRange);
		Gizmos.color = Color.red;
		//attackRange
		Gizmos.DrawWireSphere (transform.position, attackRange);
		
	}
}
