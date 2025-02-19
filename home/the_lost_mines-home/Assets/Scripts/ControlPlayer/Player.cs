using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] JoystickController left;
    [SerializeField] Transform face;

    [SerializeField, Range(1f, 1000f)] float speedMove;
    [SerializeField, Range(1f, 100f)] float speedUp;

    void Update()
    {
        ControlPlayer();
    }

    void ControlPlayer()
    {
         Vector3 movePosition = ((camera.transform.right * left.LocalPositionEnd.x / 10000f)
                                + (Vector3.zero)
                                + ((camera.transform.forward - Vector3.up * camera.transform.forward.y) * left.LocalPositionEnd.y) / 10000);

        transform.LookAt(transform.position + movePosition.normalized);

        transform.position += movePosition * speedMove;
        face.transform.localScale = new Vector3(face.transform.localScale.x, face.transform.localScale.y, .02f + movePosition.magnitude);
    }
}
