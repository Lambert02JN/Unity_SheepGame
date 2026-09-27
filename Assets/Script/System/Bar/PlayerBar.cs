using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalParameter;

public class PlayerBar : BarManager
{
    // Start is called before the first frame update
    Global global;
    private float _skill;
    public float sheepHp{get;private set;}
    protected override void Start()
    {
        global=global=Global.GetInstance();
        base.Start();
        sheepHp=_bars[2].value;
        _skill=_bars[1].value;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        _bars[1].value=Mathf.Lerp(_bars[1].value,_skill,Time.deltaTime);
        _bars[2].value=Mathf.Lerp(_bars[2].value,sheepHp,Time.deltaTime);
    }

    public override void HpBar(float damage){
        if(global.character==0){
            sheepHp-=damage;
        }else{
            hp-=damage;
        }
        }
    public float SkillBar{
        set{
            _skill-=value;}
        }
}
