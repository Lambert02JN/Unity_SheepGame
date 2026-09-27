using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSkillBehaviour : StateMachineBehaviour
{
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInChildren<Damage>().BigSkill(true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInChildren<Damage>().BigSkill(false);
    }
}
