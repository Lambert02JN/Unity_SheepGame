using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GlobalParameter
{
    class Global{
    private static Global instance;
    
    public static Global GetInstance(){
        if(instance==null){
            instance=new Global();
        }
        return instance;
    }
    private PlayerControl _player;

    public bool changeAngle{get;set;}
    public bool changeDevil{get;set;}
    public bool change{get;set;}
    public int character{get;set;}
    public PlayerControl GetPlayer{get{return _player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();}}
    }
}
