using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GlobalParameter;

public class PlayerControl : MonoBehaviour
{
    private State _state;
    public enum State {
        think,
        GetItem,
        InWater,
        GamePause,
    }
    private GameObject item;
    private Rigidbody rd;
    private float _speed=8f;
    private float _resetSpeed;
    Global global;
    [Header("CharacterChange")]
    [SerializeField]private GameObject black;
    [SerializeField]private GameObject white;
    [SerializeField]private GameObject sheep;
    Animator anim;
    Animation animation;
    public bool _inhouse;
    Damage _damage;
    private GameObject _slash;
    private GameObject _bigSkill;
    [SerializeField]private int character;
    public PlayerBar coillder;
    public bool death{get;set;}
    private bool dieAnim;
    //[SerializeField]protected AudioSource sound;
    

    // Start is called before the first frame update
    void Start()
    {
        //base.Start();
        _resetSpeed=_speed;
        //animation 
        if(gameObject.tag=="Player"){
            animation=GetComponentInChildren<Animation>();
        }else
        {
            anim=GetComponentInChildren<Animator>();
        }
        //change character
        global=Global.GetInstance();
        _state=State.think;
        //sound=GetComponent<AudioSource>();
        rd=GetComponentInChildren<Rigidbody>();
        black=Resources.Load<GameObject>("Prefab/blackPlayer01");
        white=Resources.Load<GameObject>("Prefab/whitePlayer01");
        sheep=Resources.Load<GameObject>("Prefab/Player01");
        _slash=Resources.Load<GameObject>("Prefab/Slash0"+character);
        _bigSkill=Resources.Load<GameObject>("Prefab/BigSkill0"+character);
        _damage=GetComponentInChildren<Damage>();
        if(coillder==null){
            coillder=GetComponentInChildren<PlayerBar>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(_state!=State.GamePause)
        //death
        if(coillder.sheepHp<=0 &&death && !dieAnim){
            anim.Play("death");
            _damage.audio.clip=_damage.SE[3];
            _damage.audio.Play();
            death=false;
            dieAnim=true;
        }
        if(coillder.sheepHp>=0){
            Move();
        }
    }

    private bool _run;
    private bool _walk;
    private float t1;
    private float t2;
    private float time_cd = 0.2f;
    private void Move()
    {
        if (!_damage.isAttack)
        {
            MoveControl();
        }

        Attack();
        Change();
    }
    private bool hit;
    public void Damage(bool value){
        hit=value;
    }

    private void Change()
    {
        GameObject temp;
        
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button4))
                {
                    global.character=1;
                    global.changeAngle=true;
                    temp = Instantiate(black, transform.position, transform.localRotation);
                    temp.GetComponent<PlayerControl>()._speed = 5f;
                    Destroy(gameObject);
                }
        if(gameObject.tag=="Player" && global.change){
            if(!global.changeAngle){
                //angle change
                
            }
            if(!global.changeDevil){
                //devil change
                if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button5))
                {
                    global.character=2;
                    global.changeDevil=true;
                    temp = Instantiate(white, transform.position, transform.localRotation);
                    temp.GetComponent<PlayerControl>()._speed = 5f;
                    Destroy(gameObject);
                }
            }
            
        }
        //sheep change
        if (Input.GetKeyDown(KeyCode.V))
        {
            global.character=0;
            temp = Instantiate(sheep, transform.position, transform.localRotation);
            temp.GetComponent<PlayerControl>()._speed = 6f;
            Destroy(gameObject);
        }
    }

    private void Attack()
    {
        if(hit){
            if(gameObject.tag=="Player"){
                animation.Play("getHit");
            }else
            {
                anim.SetTrigger("Hit");
            }
            hit=false;
            return;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (gameObject.tag!="Player")
            {
                if (!_damage.isAttack)
                {
                    //attack
                    anim.SetTrigger("Attack");
                }
            }
            //BroadcastMessage("Attack",true,SendMessageOptions.DontRequireReceiver);
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            if (gameObject.tag!="Player")
            {
                //key
                if (Input.GetKey(KeyCode.E))
                {
                    if (!_damage.isAttack)
                    {
                        //bigSkill
                        anim.SetTrigger("BigSkill");
                        
                        
                        coillder.SkillBar=0.3f;
                        GameObject temp= Instantiate(_bigSkill,transform);
                        temp.transform.parent=null;
                        Destroy(temp,6f);
                    }
                }
                else
                {
                    if (!_damage.isAttack)
                    {
                        //skill
                        anim.SetTrigger("Skill");
                        
                        coillder.SkillBar=0.1f;
                        GameObject temp= Instantiate(_slash,transform);
                        Destroy(temp,1f);
                        
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button1)){
            if (gameObject.tag!="Player")
            {
                if (!_damage.isAttack)
                {
                    //bigSkill
                    anim.SetTrigger("BigSkill");
                    coillder.SkillBar=0.3f;
                    GameObject temp= Instantiate(_bigSkill,transform);
                    temp.transform.parent=null;
                    Destroy(temp,6f);
                }
            }
        }
    }

    IEnumerator wait(float time=1f){
        yield return new WaitForSeconds(0.1f);
        
        
    }
    float time;
    private void MoveControl()
    {
        
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //key
        #region
        // var keyDown=Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D);
        // var keyUp=Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.D);
        // if (keyDown && _walk == false)
        // {
        //     t2 = Time.realtimeSinceStartup;
        //     if (t2 - t1 < 0.5f)
        //     {
        //         if((h != 0 || v != 0))
        //         {
        //             _run = true;
        //             if(gameObject.tag=="Player"){
        //                 animation.Play("run");
        //             }else
        //             {
        //                 anim.SetBool("Run",true);
        //                 anim.SetBool("Walk",false);
        //             }
                    
        //             _speed=_resetSpeed*2f;
        //         }
        //         //Debug.Log("double click");
        //     }
        //     t1 = t2;
        // }
        // else if(_walk == true)
        // {
        //     time_cd -= Time.fixedDeltaTime;
        //     if(time_cd<=0)
        //     {
        //         _walk = false;
        //     }
        //     if (_walk == false)
        //     {
        //         time_cd = 0.2f;
        //     }
        // }
        // // if (!_run)
        // // {
        // //     if (key)
        // //     {
        // //         Debug.Log("Walking");
        // //     }
        // //     if (keyUp)
        // //     {
        // //         Debug.Log("Stopping");
        // //     }
        // // }
        // if (_run)
        // {
        //     // if (key)
        //     // {
        //     //     Debug.Log("Running");
        //     // }
        //     if(keyUp && (h == 0 || v == 0))
        //     {
        //         //Debug.Log("Stopping");
        //         _run = false;
        //         _walk = true;
        //         if(gameObject.tag=="Player"){
        //                 animation.Play("walk");
        //         }else{
        //         anim.SetBool("Run",false);
        //         anim.SetBool("Walk",true);
        //         }
        //         _speed=_resetSpeed;
        //     }
        // }
        #endregion
    
        if(_inhouse){
            
            return;
        }
        if(transform.position.y>3f){
            //don't fly
            transform.position=new Vector3(transform.position.x,0,transform.position.z);
        }
        if((h != 0 || v != 0)){
            
            time+=Time.deltaTime;
            
            if(time>2f){
                if(gameObject.tag=="Player"){
                        animation.Play("run");
                    }else
                    {
                        anim.SetBool("Run",true);
                    }
                _speed=_resetSpeed*1.5f;
            }else{
                if(gameObject.tag=="Player"){
                    animation.Play("walk");
                }else{
                    anim.SetBool("Run",false);
                    anim.SetBool("Walk",true);
                }
                _speed=_resetSpeed;
            }
            
            Vector3 direction = new Vector3(h, 0, v).normalized;
            float y = Camera.main.transform.rotation.eulerAngles.y;
            direction = Quaternion.Euler(0, y, 0) * direction;
            Vector3 target = Vector3.Lerp(transform.forward, direction, 0.2f);
            transform.LookAt(transform.position + target);
            transform.Translate(target * Time.deltaTime * _speed, Space.World);
        }else
        {
            if(gameObject.tag=="Player"){
                animation.Play("idle1");
            }else{
                anim.SetBool("Walk",false);
                anim.SetBool("Run",false);
            }
            time=0;
        }
            
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.name=="door_collider" && global.character==0){
            if(!_inhouse){
                StartCoroutine(Entering(other.transform));
                
            }
            if(Input.GetKey(KeyCode.S)){
                StartCoroutine(Leaveing(other.transform));
            }
        }
    }
    IEnumerator Entering(Transform obj){
        
        while (Vector3.Distance(obj.position,transform.position)>0.5f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position=Vector3.Lerp(transform.position,obj.position-Vector3.right*0.5f,0.1f);
        }
        rd.isKinematic=true;
        _inhouse=true;
    }
    IEnumerator Leaveing(Transform obj){
        
        while (Vector3.Distance(obj.position,transform.position)<4f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position=Vector3.Lerp(transform.position,obj.position+Vector3.right*5f,0.1f);
        }
        rd.isKinematic=false;
        _inhouse=false;
    }

    public State GetState{get{return _state;}}
    public State SetState{set{ _state=value;}}
}
