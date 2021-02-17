using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownPlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    public float speedInterpolation = 10;
    private Rigidbody2D rigidbody;
    private Vector2 movementVector;
    private Vector4 movementConstraints;
    private BoxCollider2D footBox;
    public bool canMove = true;

    public GameObject ship;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {

        Vector2 targetVector = new Vector2();
        if (canMove)
        {
            if (IsOnShip())
            {
                targetVector = Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up;
            }
            else
            {
                targetVector = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.up;
            }
        }
        movementVector = Vector2.Lerp(movementVector, targetVector, Time.deltaTime * speedInterpolation);
        DoAnimation(movementVector);
    }
    private void FixedUpdate()
    {
        SetMovementConstraints();
        DoMovement();
    }

    public void DoAnimation(Vector2 movement)
    {
        if(movement.x < 0 )
        {
            SetCharacterXScale(-1);
        }
        else if (movement.x > 0) {
            SetCharacterXScale(1);
        }
    }

    public void SetCharacterXScale (int scale)
    {
        Vector3 characterScale = transform.localScale;
        characterScale.x = scale;
        transform.localScale = characterScale;
    }

    public void EnterShip(GameObject ship)
    {
        this.ship = ship;
    }

    public void DoMovement()
    {
        if (IsOnShip())
        {
            transform.rotation = ship.transform.rotation;
        }
        rigidbody.MovePosition((Vector2)transform.position + movementVector * Time.deltaTime * movementSpeed);
    }

    public void LeaveShip()
    {

    }

    public bool IsOnShip()
    {
        return ship != null;
    }


    public void SetMobility(bool value)
    {
        canMove = value;
    }
    

    public void SetMovementConstraints ()
    {

    }

}
