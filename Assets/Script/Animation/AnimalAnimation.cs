using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    protected Animation _anim;
    protected AudioSource _sound;
    protected Rigidbody _rbody;
    public List<AnimationClip> animations = new List<AnimationClip>( );
    
    protected void SetAnim(int index){_anim.Play(animations[index].name);}
    protected void SetSound(){_sound.Play();}
    public virtual void Start(){
        _anim = GetComponent<Animation>();
        _sound= GetComponent<AudioSource>();
        _rbody= GetComponent<Rigidbody>();
        foreach (AnimationState state in _anim)
        {
            state.speed = 0.5F;
            this.animations.Add( state.clip );
            //anim.Play(state.name);
        }
        //anim.Play( this.animations[3].name ); 
    }
}
