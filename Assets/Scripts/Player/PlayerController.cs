using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed;
    Vector2 curMoveDirection;
    
    void Start()
    {
        CharacterManager.Instance.Player.OnMoveEvent+=Move;
    }
   
    void Move()
    {
        this.transform.rotation =Quaternion.Euler(0,0,0);

        Vector3 dir =new Vector3(curMoveDirection.x*transform.forward.z,0, curMoveDirection.y*transform.forward.z);
        dir *=moveSpeed;
        StartCoroutine(Moving(dir));
      
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
    IEnumerator Moving(Vector3 pos)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = currentPosition+pos;
        while(true)
        {
            transform.position= Vector3.Lerp(this.transform.position,targetPosition,1f);
            if(transform.position==targetPosition) break;
            yield return null;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed&&Time.timeScale!=0)
        {
            curMoveDirection = context.ReadValue<Vector2>();
            CharacterManager.Instance.Player.OnMoveEvent?.Invoke();
            Rotate(curMoveDirection);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
           curMoveDirection=Vector2.zero;
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //만약 장애물에 부딪히면, 이전 포지션으로 다시 이동해야함
        if(other.TryGetComponent(out ICollidable collidable))
        {
            collidable.OnCollide();
        }
    }
}
