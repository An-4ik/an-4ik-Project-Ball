using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMous : MonoBehaviour
{
    private Vector3 mouseStartPosition;
    private Transform objectToMove;
    public float playerSpeed = 10f;

    private float minX = -6.9f;
    private float maxX = 10.3f;

   

    void Start()
    {
        objectToMove = this.transform;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }
         else if (Input.GetMouseButton(0))
         {
            Vector3 mouseDiff = Input.mousePosition - mouseStartPosition;
            float deltaZ = mouseDiff.x / Screen.height;
            

            float newXPosition = Mathf.Clamp(objectToMove.position.z + deltaZ, minX, maxX);


             Vector3 newPos = new Vector3(objectToMove.position.x, objectToMove.position.y, newXPosition)/* * Time.deltaTime * playerSpeed*/;
           
            //objectToMove.position = newPos;
            objectToMove.position = Vector3.Lerp(objectToMove.position, newPos, playerSpeed * Time.deltaTime);
         }
       
    }
    
}
