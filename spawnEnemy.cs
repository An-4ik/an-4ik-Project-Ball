/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawnEnemy : MonoBehaviour
{
    public GameObject[] objs = new GameObject[3];
    private void Start()
    {
        StartCoroutine(CreatEnemy());
    }
    
   
    private void Ctreat()
    {
        for (int i = 0; i = 3; i++) {
            Instantiate(obj[UnityEngine.Random.Range(0, 2)], new Vector3(UnityEngine.Random.Range(-47, -20), 11, UnityEngine.Random.Range(-7, 10), Quaternion.Euler(0, 0, 0));
        }
      
    }
   
    private IEnumerator CreatEnemy(){
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Ctreat();
        }
    }
}
*/