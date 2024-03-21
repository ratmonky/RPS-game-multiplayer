using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerScript : NetworkBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject scissors;
    [SerializeField] private GameObject ready;

    private GameObject currentObject; // Reference to the currently instantiated object
    private bool keyPressed = false; // Flag to track if any key is currently pressed

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { this.enabled = false; }

        // Make sure the "ready hand" object is initially visible
        ready.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Only execute this code if this is the owner client with Id 0
        if (IsOwner && OwnerClientId == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(rock, transform.position, Quaternion.identity);
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("A (rock) key is pressed.");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(paper, transform.position, Quaternion.identity);
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("S (paper) key is pressed.");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(scissors, transform.position, Quaternion.identity);
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("D (scissors) key is pressed.");
            }

            // Destroy the object when any key is released and no key is pressed
            if (!Input.anyKey && keyPressed)
            {
                DestroyCurrentObject();
                SetReadyHandVisibility(true); // Show the ready hand
                currentObject = Instantiate(ready, transform.position, Quaternion.identity);
                keyPressed = false;
                Debug.Log("All keys are released.");
            }
        }
        if (!IsOwner && OwnerClientId == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(rock, transform.position, Quaternion.identity);
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("A (rock) key is pressed.");
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(paper, transform.position, Quaternion.identity);
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("S (paper) key is pressed.");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(scissors, transform.position, Quaternion.identity);
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("D (scissors) key is pressed.");
            }

            // Destroy the object when any key is released and no key is pressed
            if (!Input.anyKey && keyPressed)
            {
                DestroyCurrentObject();
                SetReadyHandVisibility(true); // Show the ready hand
                currentObject = Instantiate(ready, transform.position, Quaternion.identity);
                keyPressed = false;
                Debug.Log("All keys are released.");
            }
        }


    }

    // Destroy the current object if it exists
    private void DestroyCurrentObject()
    {
        if (currentObject != null)
        {
            Destroy(currentObject);
        }
    }

    // Set the visibility of the ready hand object
    private void SetReadyHandVisibility(bool isVisible)
    {
        ready.SetActive(isVisible);
    }
}
