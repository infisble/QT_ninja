using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayer : MonoBehaviour
{
    public float moveSpeed = 8f;

    void Update()
    {
        Vector3 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
