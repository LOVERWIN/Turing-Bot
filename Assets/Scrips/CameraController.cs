using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class CameraController : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 30f;
    private float UpLim = 80f;      
    private float LowLim = 1f;
    InputController _inpuController = null;

    private void Awake()
    {
        _inpuController = GetComponent<InputController>();
    }

    private void Update()
    {
        MouseCamera();
    }

    void MouseCamera()
    {
        Vector2 input = _inpuController.MouseInput();
        Vector3 angle = transform.rotation.eulerAngles;

        float _rotationX = angle.x - input.y * _mouseSensitivity * Time.deltaTime;

        float _rotationY = angle.y - input.x * _mouseSensitivity * Time.deltaTime;

        _rotationX = Mathf.Clamp(_rotationX, LowLim, UpLim);
        transform.rotation = Quaternion.Euler(_rotationX,_rotationY, angle.z);
    }

}
