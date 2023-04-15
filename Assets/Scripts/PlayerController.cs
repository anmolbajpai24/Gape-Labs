using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 180.0f;
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;
    private Camera playerCamera;
    
    PhotonView photonView;

    private float verticalLookRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        photonView = GetComponent<PhotonView>();

        if (!photonView.IsMine)
        {
            
           playerCamera.gameObject.SetActive(false);
           return;
        }

        else
        {
            // Hide and lock cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            // Character movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            movement = playerCamera.transform.TransformDirection(movement);
            movement.y = 0;
            movement.Normalize();

            rb.velocity = movement * moveSpeed + Vector3.up * rb.velocity.y;

            // Character rotation
            float yRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(Vector3.up * yRotation * Time.deltaTime * rotationSpeed);

            // Camera look
            float xRotation = Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalLookRotation -= xRotation;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -80f, 80f);

            playerCamera.transform.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);

          

        }
    }

}
