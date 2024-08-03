
using UnityEngine;


public class DestroeEmp : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            
        }
    }


}
