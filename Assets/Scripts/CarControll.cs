using UnityEngine;
using static UnityEngine.Input;


public class CarControll : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private float _angle = 0f;
    private float _smooth = 5.0f;

    void Start()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0);
    }

    void Update()
    {
        ControllMove();
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
            Rotate(1);
        }
        else if (GetKey(KeyCode.A))
        {
            Rotate(-1);
        }
    }
    private void Movement(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void Rotate(float direction)
    {
        _angle += direction;
        Quaternion target = Quaternion.Euler(0, _angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
    }
}
