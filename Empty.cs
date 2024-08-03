using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Empty : MonoBehaviour
{
    
    public static float speed = 5f;

   // public Transform[] transforms = new Transform[3];
   public Transform[] transforms = new Transform[3];


    void Awake()
    {
         
    }


   public void Update()
    {
        for (int i = 0; i< transforms.Length;  i++)
        {
            if (transforms[i] == null)
                continue;

             transforms[i].Translate(new Vector3(0, 0, 0) * speed * Time.deltaTime);
        }
       
    }
}
