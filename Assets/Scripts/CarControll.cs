using UnityEngine;
using static UnityEngine.Input;


public class CarControll : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _initialAngle = 0f;
    [SerializeField] private float _angle = 1f;
    [SerializeField] private float _smoothRotate = 5.0f;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        ControllMove();
    }

    void Update()
    {    
    }

    private void ControllMove()
    {
        if (GetKey(KeyCode.W))
        {
            Vector3 relative =  transform.TransformDirection(Vector3.forward);
            Movement(relative);         
        }
        else if (GetKey(KeyCode.S))
        {
            Vector3 relative = transform.TransformDirection(Vector3.back);
            Movement(relative);
        }

        else if (GetKey(KeyCode.D))
        {
            Rotate(_angle);
        }
        else if (GetKey(KeyCode.A))
        {
            Rotate(-_angle);
        }
    }
    private void Movement(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void Rotate(float direction)
    {
        _initialAngle += direction;
        Quaternion target = Quaternion.Euler(0, _initialAngle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smoothRotate);
    }
}
