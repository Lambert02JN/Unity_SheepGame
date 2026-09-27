using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalParameter;
using System;

public class UIManager : MonoBehaviour
{
    private GameObject[] enemyHp;
    private GameObject player;
    [SerializeField]private Slider playerBar;
    [SerializeField]private GameObject _characterImg;
    [SerializeField]private Image _angleBar;
    [SerializeField]private Image _devilBar;
    Global global;
    //PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        global=Global.GetInstance();
        enemyHp=GameObject.FindGameObjectsWithTag("UI");
        _characterImg.SetActive(false);
        _angleBar.fillAmount=0f;
        _devilBar.fillAmount=0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null){
            player=GameObject.FindGameObjectWithTag("Player");
        }
        if(!global.change){
            if(playerBar.value<=0.05f){
                _characterImg.SetActive(true);
                Time.timeScale=0;
                global.change=true;
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button5)|| Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button4)){
                    Time.timeScale=1;
                    //playerBar.value=0.05f;
                    
                    _characterImg.SetActive(false);
                }
                
            }
        }
        

    }
    void FixedUpdate()
    {
        _angleBar.fillAmount-=Time.deltaTime*0.01f;
        _devilBar.fillAmount-=Time.deltaTime*0.01f;
        if(global.character==1){
            _angleBar.fillAmount=1f;
            global.character=3;
        }else if(global.character==2){
            _devilBar.fillAmount=1f;
            global.character=3;
        }
        if(_angleBar.fillAmount==0){
            global.changeAngle=false;
        }
        if(_devilBar.fillAmount==0){
            global.changeDevil=false;
        }
    }

}
