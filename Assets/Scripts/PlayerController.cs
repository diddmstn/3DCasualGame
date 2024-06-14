using UnityEngine;
using UnityEngine.InputSystem;

// public enum Rotate
// {
//     UP,
//     DOWN,
//     LEFT,
//     RIGHT
// }

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed;
    Vector2 curMoveDirection;
    CharacterController controller;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller=GetComponent<CharacterController>();
    }
    void Start()
    {
        CharacterManager.Instance.Player.OnMoveEvent+=Move;
    }
    // private void Update() 
    // {
    //     Move();
    // }
 
    void Move()
    {
        Vector3 dir = transform.forward *curMoveDirection.y+-transform.right*curMoveDirection.x;

        dir *=moveSpeed;
        transform.Translate(dir);
    }
    void Rotate(Vector2 direction)
    {
        if(direction==Vector2.up)
        {
            this.transform.rotation =Quaternion.Euler(0,0,0);
        }
        else if(direction==Vector2.down)
        {
            this.transform.rotation =Quaternion.Euler(0,180,0);
        }
        else if(direction==Vector2.right)
        {
            this.transform.rotation =Quaternion.Euler(0,90,0);
        }
        else
        {
            this.transform.rotation =Quaternion.Euler(0,-90,0);
        }
        
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMoveDirection = context.ReadValue<Vector2>();
            Rotate(curMoveDirection);
           // Move();
            CharacterManager.Instance.Player.OnMoveEvent?.Invoke();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
           curMoveDirection=Vector2.zero;
        }
        


    }
}
