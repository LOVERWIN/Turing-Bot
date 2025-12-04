using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    float _speed = 20f;
    public Animator animator;
    InputController inputController = null;
    [SerializeField] Transform _cameraMause = null;
    public void Awake()
    {
        inputController = GetComponent<InputController>();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 input = inputController.MoveInput();
        Vector3 _angleCameraMouse = _cameraMause.rotation.eulerAngles;

        if (input.y > 0)
        {
            _angleCameraMouse.x = 0f;
            _angleCameraMouse.z = 0f;
            transform.eulerAngles = _angleCameraMouse;
            animator.SetBool("Running", true);
            transform.position += transform.forward * input.y * Time.deltaTime * _speed;
            _cameraMause.position += transform.forward * input.y * Time.deltaTime * _speed;
        }
        else if (input.y < 0)
        {
            _angleCameraMouse.z = 0f;
            _angleCameraMouse.x = 0f;
            _angleCameraMouse.y = 180f;
            transform.eulerAngles = _angleCameraMouse;
            transform.position -= transform.forward * input.y * Time.deltaTime * _speed;
            _cameraMause.position -= transform.forward * input.y * Time.deltaTime * _speed;
            animator.SetBool("Running", true);
        }
        else if (input.y == 0 && input.x == 0)
        {
            animator.SetBool("Running", false);
        }
        else if (input.x != 0)
        {
            _angleCameraMouse.z = 0f;
            _angleCameraMouse.x = 0f;
            _angleCameraMouse.y = 90f* input.x;
            transform.eulerAngles = _angleCameraMouse;

            if (input.x < 0)
            {

                transform.position -= transform.forward * input.x * Time.deltaTime * _speed;
                _cameraMause.position -= transform.forward * input.x * Time.deltaTime * _speed;
                animator.SetBool("Running", true);
            }
            else if(input.x > 0)
            {
                transform.position += transform.forward * input.x * Time.deltaTime * _speed;
                _cameraMause.position += transform.forward * input.x * Time.deltaTime * _speed;
                animator.SetBool("Running", true);
            }
        }
        else if (input.y == 0 && input.x == 0)
        {
            animator.SetBool("Running", false);
        }
    }

}
