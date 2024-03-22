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
    [SerializeField] private AudioSource slash;
    [SerializeField] private AudioSource crumple;
    [SerializeField] private AudioSource smash;

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

        if (IsOwner && OwnerClientId == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ServerRPSRpc(1);

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(paper, transform.position, Quaternion.Euler(0, 180, 0));
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
        if (OwnerClientId == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ServerRPSRpc(1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(paper, transform.position, Quaternion.Euler(0, 180, 0));
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("S (paper) key is pressed.");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Instantiate the object only on the client with OwnerClientId 0
                DestroyCurrentObject();
                currentObject = Instantiate(scissors, transform.position, Quaternion.Euler(0, 180, 0));
                SetReadyHandVisibility(false); // Hide the ready hand
                keyPressed = true;
                Debug.Log("D (scissors) key is pressed.");
            }

            // Destroy the object when any key is released and no key is pressed
            if (!Input.anyKey && keyPressed)
            {
                DestroyCurrentObject();
                SetReadyHandVisibility(true); // Show the ready hand
                currentObject = Instantiate(ready, transform.position, Quaternion.Euler(0, 180, 0));
                keyPressed = false;
                Debug.Log("All keys are released.");
            }
        }



    }
    
    //[Rpc(SendTo.ClientsAndHost)]
    private void ServerRPSRpc(int input)
    {
        if(input == 1) {
            DestroyCurrentObject();
            currentObject = Instantiate(rock, transform.position, Quaternion.identity);
            SetReadyHandVisibility(false); // Hide the ready hand
            keyPressed = true;
            Debug.Log("A (rock) key is pressed.");
            smash.Play();
        }
        if (input == 2){
            // Instantiate the object only on the client with OwnerClientId 0
            DestroyCurrentObject();
            currentObject = Instantiate(paper, transform.position, Quaternion.Euler(0, 180, 0));
            SetReadyHandVisibility(false); // Hide the ready hand
            keyPressed = true;
            Debug.Log("S (paper) key is pressed.");
            crumple.Play();
        }
        if (input == 3)
        {
            DestroyCurrentObject();
            currentObject = Instantiate(scissors, transform.position, Quaternion.identity);
            SetReadyHandVisibility(false); // Hide the ready hand
            keyPressed = true;
            Debug.Log("D (scissors) key is pressed.");
            slash.Play();


        }
        if (input == 4)
        {

            DestroyCurrentObject();
            currentObject = Instantiate(rock, transform.position, Quaternion.Euler(0, 180, 0));
            SetReadyHandVisibility(false); // Hide the ready hand
            keyPressed = true;
            Debug.Log("A (rock) key is pressed.");

        }
        if (input == 5)
        {
            DestroyCurrentObject();
            currentObject = Instantiate(paper, transform.position, Quaternion.Euler(0, 180, 0));
            SetReadyHandVisibility(false); // Hide the ready hand
            keyPressed = true;
            Debug.Log("S (paper) key is pressed.");


        }
        if (input == 6)
        {
            DestroyCurrentObject();
            currentObject = Instantiate(scissors, transform.position, Quaternion.Euler(0, 180, 0));
            SetReadyHandVisibility(false); // Hide the ready hand
            keyPressed = true;
            Debug.Log("D (scissors) key is pressed.");


        }
        if (input == 7)
        {



        }
        if (input == 8)
        {



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
