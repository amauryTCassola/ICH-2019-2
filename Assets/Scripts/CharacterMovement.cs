using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;

    string verticalInputAxis = "Vertical", horizontalInputAxis = "Horizontal", verticalMouseAxis = "Mouse Y", horizontalMouseAxis = "Mouse X";
    float movementSpeed = 20.0f, turnSpeed = 200.0f;
    float mouseThreshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
        MouseAiming();

    }

    void KeyboardMovement() {
        if (Input.GetAxis(verticalInputAxis) > 0)
            Move(transform.forward);

        if (Input.GetAxis(verticalInputAxis) < 0)
            Move(-transform.forward);

        if (Input.GetAxis(horizontalInputAxis) > 0)
            Move(transform.right);

        if (Input.GetAxis(horizontalInputAxis) < 0)
            Move(-transform.right);
    }

    void Move(Vector3 movement) {
        characterController.SimpleMove(movement*movementSpeed*Time.deltaTime);
    }

    void MouseAiming()
    {
        float verticalRotation = Input.GetAxis(verticalMouseAxis), horizontalRotation = Input.GetAxis(horizontalMouseAxis);
        Vector3 currentRotation = transform.rotation.eulerAngles;

        if ((verticalRotation < mouseThreshold && verticalRotation > -mouseThreshold)) {
            verticalRotation = 0.0f;
        }

        if (horizontalRotation < mouseThreshold && horizontalRotation > -mouseThreshold )
        {
            horizontalRotation = 0.0f;
        }

        Vector3 rotationDelta = new Vector3(-verticalRotation, horizontalRotation, 0.0f);

        transform.rotation = Quaternion.Euler(currentRotation + rotationDelta);
        //transform.Rotate(horizontalRotationAxis, horizontalRotation * turnSpeed * Time.deltaTime);
    }
}
