using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    public GameObject groundcheckObject;
    private Rigidbody2D _playerRigidbody;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MovePlayer();

        if (Input.GetButton("Jump") && IsGrounded())
            Jump();
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() => _playerRigidbody.velocity = new Vector2( 0, jumpPower);

    private bool IsGrounded()
    {
        
        var groundCheck = Physics2D.Raycast(groundcheckObject.transform.position,Vector2.down, 0.7f);
        if (groundCheck.collider != null)
        {
            //Debug.Log(groundCheck.collider.tag);
            return groundCheck.collider.CompareTag("Ground");
        }
        return false;
        
    }

}