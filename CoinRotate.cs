using UnityEngine;


public class CoinRotate : MonoBehaviour
{
    void Update()
    {
        
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }
}