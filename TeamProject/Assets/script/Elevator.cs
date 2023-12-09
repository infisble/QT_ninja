using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorSwitch;

    public Transform[] floorPositions;
    public GameObject systemCanvas;

    public float speed;
    private bool isMoving = false;
    private Vector3 targetPosition;

    public PlayerScript playerMovement;

    void Start()
    {
        systemCanvas.SetActive(false);
    }

    void Update()
    {
        if (Vector2.Distance(player.position, elevatorSwitch.position) < 1f && Input.GetKeyDown(KeyCode.E))
        {
            ShowSystem();
        }
        if (isMoving)
        {
            MoveElevator();
        }
    }

    private void ShowSystem()
    {
        systemCanvas.SetActive(true);
        playerMovement.CanMove = false;
    }

    public void GoToFloor(int floorIndex)
    {
        if (floorIndex >= 0 && floorIndex < floorPositions.Length)
        {
            targetPosition = floorPositions[floorIndex].position;
            isMoving = true;
            systemCanvas.SetActive(false);
        }
    }

    private void MoveElevator()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        playerMovement.CanMove = false;
        if (transform.position == targetPosition)
        {
            isMoving = false;
            playerMovement.CanMove = true;
        }
    }
}
