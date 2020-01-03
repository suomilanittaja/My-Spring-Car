using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementController : MonoBehaviour
{
    public CharacterController characterController;

    public float moveSpeed;

    public float sprintSpeedMultiplier = 2f;

    public float jumpHeight = 3f;

    private float _gravity = -10f;

    private float _yAxisVelocity;
	
	


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            vertical *= sprintSpeedMultiplier;
        
        Vector3 movement = horizontal * moveSpeed * Time.deltaTime * transform.right +
                           vertical * moveSpeed * Time.deltaTime * transform.forward;

        if (characterController.isGrounded)
            _yAxisVelocity = -0.5f;


        if (Input.GetKeyDown(KeyCode.Space))
            _yAxisVelocity = Mathf.Sqrt(jumpHeight * -2f * _gravity);

        _yAxisVelocity += _gravity * Time.deltaTime;
        movement.y = _yAxisVelocity * Time.deltaTime;
        
        characterController.Move(movement);
    }
}