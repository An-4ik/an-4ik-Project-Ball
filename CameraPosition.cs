/*using UnityEngine;


public class CameraPosition : MonoBehaviour
{
    public Transform objectToFollow;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;



   

    void LateUpdate()
    {

        
        
            

            Vector3 desiredPosition = objectToFollow.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(objectToFollow);
        
    }
}*/

using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform[] objectsToFollow;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        foreach (Transform objectToFollow in objectsToFollow)
        {
            if (objectToFollow != null)
            {
                Vector3 desiredPosition = objectToFollow.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;

                //transform.LookAt(objectToFollow);
            }
        }
    }
}