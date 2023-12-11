using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_losk : MonoBehaviour
{
   

    private PolygonCollider2D boundsCollider;

    void Start()
    {
        // Отримуємо колайдер полігону нашої області
        boundsCollider = GetComponent<PolygonCollider2D>();
        if (boundsCollider == null)
        {
            Debug.LogError("Polygon Collider 2D component is missing.");
        }
    }

    // LateUpdate викликається після усіх оновлень
    void LateUpdate()
    {
        // Отримуємо поточні координати камери
        Vector3 currentPos = transform.position;

        // Перевіряємо, чи поточне положення камери знаходиться в середині полігону
        if (!boundsCollider.OverlapPoint(currentPos))
        {
            // Якщо не знаходиться, обмежуємо рух до найближчої точки на полігоні
            Vector2 closestPoint = boundsCollider.ClosestPoint(currentPos);
            transform.position = new Vector3(closestPoint.x, closestPoint.y, transform.position.z);
        }
    }
}
