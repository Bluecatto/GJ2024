using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator anim;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetBool("isWalking", true);
            transform.position += new Vector3(movementInput.x * speed * 0.025f, 0, movementInput.y * speed * 0.025f);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
