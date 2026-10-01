using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetPosition;
    [SerializeField] float smoothTime = 0.3f;

    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
                transform.position,
                new Vector3(
                        targetPosition.position.x,
                        targetPosition.position.y,
                        transform.position.z
                    ),
                ref velocity,
                smoothTime
            );
    }
}
