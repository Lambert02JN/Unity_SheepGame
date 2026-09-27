using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalParameter;

public class GameManager : MonoBehaviour
{
    public enum State{
        Level1,
        Level2,
        Level3,
    }
    [SerializeField]
    private State _state;
    private FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        fadeManager=GetComponent<FadeManager>();
        fadeManager.FadeInComplete += EnableInput;
        fadeManager.FadeIn();
    }
void EnableInput()
    {
        fadeManager.FadeInComplete -= EnableInput;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
