using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    Transform cam;

    Vector3 moveDirection = Vector3.zero;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Mouselook")]
    public float mouseSensitivity = 2f;
    Quaternion targetRotation;

    float mouseX, mouseY;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor Lock
        Cursor.lockState = CursorLockMode.Locked;

        //Get character controller
        characterController = GetComponent<CharacterController>();

        //Get Camera
        cam = GetComponentInChildren<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse input
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //Vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.localRotation = Quaternion.Euler(new Vector3(xRotation, 0, 0));

        //Horizontal
        transform.Rotate(Vector3.up * (mouseX));


        //Get direction
        moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDirection *= moveSpeed;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);


        //Move player
        characterController.Move((moveDirection * moveSpeed * Time.deltaTime));
        

    }
}
