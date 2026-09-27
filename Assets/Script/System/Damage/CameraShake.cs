using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform _cameraTrnasform;
    public float shakeTime=2f;
    public float shakeAmount=3f;
    public float shakeSpeed=2f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraTrnasform=GetComponent<Transform>();
    }

    public IEnumerator Shake(){
        Vector3 pos=_cameraTrnasform.localPosition;
        float elapseTime=0f;
        while(elapseTime<shakeTime){
            Vector3 randomPoint=pos+Random.insideUnitSphere*shakeAmount;
            _cameraTrnasform.localPosition=Vector3.Lerp(_cameraTrnasform.localPosition,randomPoint,Time.deltaTime);
            yield return null;
            elapseTime+=Time.deltaTime;
        }
        _cameraTrnasform.localPosition=pos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
