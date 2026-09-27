using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _target;
    private Camera _mainCamera;
    [SerializeField]private float _distance=7f;
    private float mouseX;
    private float mouseY;
    private float finalInputX;
    private float finalInputZ;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    private float ClampAngle = 80.0f;
    private float InputSensitivity = 150.0f;


    // Start is called before the first frame update
    void Start()
    {
        _target=GameObject.FindGameObjectWithTag("Player");
        _mainCamera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CameraSetting();

    }

    private void LateUpdate()
    {
        if(_target==null){
            _target=GameObject.FindGameObjectWithTag("Player");
        }
        var cameraPos=_target.transform.position-transform.right*_distance+transform.up;
        transform.position=_target.transform.position+transform.up*4;
        _mainCamera.transform.LookAt(transform.position);
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, cameraPos, Time.deltaTime);
    }

    private void CameraSetting()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * InputSensitivity * Time.deltaTime;
        rotX += finalInputZ * InputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -ClampAngle, ClampAngle);

        Quaternion localRotation = Quaternion.Euler(0, rotY, Mathf.Clamp(rotX, -70, 5));
        transform.rotation = localRotation;
    }
}
