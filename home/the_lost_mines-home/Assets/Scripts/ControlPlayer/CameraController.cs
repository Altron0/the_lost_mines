using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float distance;
    [SerializeField] Transform player;

    [SerializeField] JoystickController right;
    void Update()
    {
        transform.position += (transform.right * right.LocalPositionEnd.x + transform.up * right.LocalPositionEnd.y) / 300f * Time.deltaTime;

        Vector3 difference = (player.position - transform.position);
        if (difference.magnitude != distance)
            transform.position += (difference.normalized - Vector3.up * difference.normalized.y) * (difference.magnitude - distance);

    }
}
