using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    public float speedInterpolation = 10;
    private Rigidbody2D rigidbody;
    private Vector2 movementVector;
    public bool canMove = true;

    public GameObject ship;
    public Vector2 shipOffset;

    void Start()
    {
        if (!rigidbody) rigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector2 targetVector = new Vector2();
        if (canMove)
        {
            targetVector = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.up;
        }
        movementVector = Vector2.Lerp(movementVector, targetVector, Time.deltaTime * speedInterpolation);
    }
    private void FixedUpdate()
    {
        if (IsOnShip())
        {
            transform.rotation = ship.transform.rotation;
            rigidbody.velocity = ship.GetComponent<Rigidbody2D>().velocity + movementSpeed * movementVector;
        }
        else
        {
            rigidbody.MovePosition(rigidbody.position + movementSpeed * movementVector * Time.fixedDeltaTime);
        }
    }

    public void EnterShip(GameObject ship)
    {
        this.ship = ship;
    }

    public void LeaveShip()
    {
     
    }

    public bool IsOnShip ()
    {
        return ship != null;
    }


    public void SetMobility(bool value)
    {
        canMove = value;
    }

}
