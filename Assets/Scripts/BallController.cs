using UnityEngine;
using static UnityEngine.Input;


public class BallController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

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
            Movement(Vector3.forward);
        }
        else if (GetKey(KeyCode.S))
        {
            Movement(Vector3.back);
        }
        else if (GetKey(KeyCode.A))
        {
            Movement(Vector3.left);
        }
        else if (GetKey(KeyCode.D))
        {
            Movement(Vector3.right);
        }
    }
    private void Movement(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }
}
