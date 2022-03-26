using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    Transform cam;
    HUD hud;
    Interactables noteData;
    Transform item;
    Rigidbody itemrb;
    Collider itemcol;
    public LayerMask Objects;
    public LayerMask Interactables;
    Vector3 moveDirection = Vector3.zero;
    float gravity = 9.81f;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Mouselook")]
    public float mouseSensitivity = 2f;
    public Transform hands;

    [Header("Viewbob")]
    public Transform viewbobRoot;
    public float viewbobAmount = 0.05f;
    float viewbobHeight;

    float moveX, moveZ;
    float mouseX, mouseY;
    float xRotation = 0f;
    public bool isLookingAtNote = false;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor Lock
        Cursor.lockState = CursorLockMode.Locked;

        //Get character controller
        characterController = GetComponent<CharacterController>();

        //Get Camera
        cam = GetComponentInChildren<Camera>().transform;


        //Get Item
        if (itemcol == null)
            itemcol = GetComponentInChildren<Collider>();

        //Get Hud
        hud = GetComponent<HUD>();

        viewbobHeight = viewbobRoot.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        Mouselook();

        Movement();

        Viewbob();

        //If looking at object, pick item up
        if (Input.GetMouseButtonDown(0))
        {
            if (IsLookingObject() && !HasItemInHands())
            {
                PickItemUp();
            }
            else if (HasItemInHands())
            {
                DropItem();
            }
        }
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }

    void GetInput()
    {
        //Get move input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //Get mouse input
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

    void Mouselook()
    {
        //Vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.localRotation = Quaternion.Euler(new Vector3(xRotation, 0, 0));

        //Horizontal
        transform.Rotate(Vector3.up * (mouseX));
    }
     
    void Movement()
    {
        //Get direction
        moveDirection = transform.forward * moveZ + transform.right * moveX;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        //Move player
        characterController.Move((moveDirection * moveSpeed * Time.deltaTime));
    }

    void Viewbob()
    {
        Vector3 viewbobPos = new Vector3(0, viewbobHeight, 0);

        //Add bobbing if moving
        if (moveX != 0 || moveZ != 0)
        {
            float offset = Mathf.Sin(Time.time * (moveSpeed * 2f)) * viewbobAmount;
            viewbobPos.y += offset;
        }
        
        //Lerp to target position
        viewbobRoot.localPosition = Vector3.Lerp(viewbobRoot.localPosition, viewbobPos, 10f * Time.deltaTime);
    }

    public bool IsLookingObject()
    {
        //Raycast a beam forward to see if there is objects that can be picked up
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 2f, Objects) && hands.transform.childCount == 0)
        {
            item = hit.transform;
            itemrb = hit.rigidbody;
            itemcol = hit.collider;
            return true;
        }

        return false;
    }

    public void PickItemUp()
    {
        //Put object in correct position in "hands" and set its rotation to face forward 
        item.parent = hands;
        item.localPosition = Vector3.zero;
        item.eulerAngles = cam.transform.eulerAngles;

        //this one stops the momentum so it doesnt float away from your hands
        itemrb.velocity = Vector3.zero;
        itemrb.angularVelocity = Vector3.zero;

        //Disable collider & make rigidbody kinematic
        itemcol.enabled = false;
        itemrb.isKinematic = true;
    }

    public bool HasItemInHands()
    {
        if (hands.transform.childCount > 0)
            return true;

        return false;
    }

    public void DropItem()
    {
        //Disable parent
        item.parent = null;

        //Enable collider & make rigidoby dynamic
        itemcol.enabled = true;
        itemrb.isKinematic = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Note")
        {
            isLookingAtNote = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Note")
        {
            isLookingAtNote = false;
        }
    }
}
