using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSystem : MonoBehaviour
{
    public Elevator elevator;

    public void OnButtonClick(int floorIndex)
    {
        Debug.Log(floorIndex);
        elevator.GoToFloor(floorIndex);
    }
}
