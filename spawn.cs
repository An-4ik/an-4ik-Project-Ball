using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class  spawn: MonoBehaviour
{
    public List<GameObject> obj = new List<GameObject>();
    public GameObject[] objectToSpawn = new GameObject[6]; // Предполагается, что у вас есть префаб для спавна
    public float spawnInterval; // Интервал спавна в секундах
    public float moveSpeed = 15f; // Скорость движения объекта по оси X

    
  
    private void Start()
    {
        StartCoroutine(SpawnObjects());
        StartCoroutine(IncreaseVariableRoutine());
    }

    private GameObject obb;

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            
            for (byte i = 0; i < objectToSpawn.Length; i++)
            {   // Создание нового объекта
               
                GameObject obb = Instantiate(objectToSpawn[UnityEngine.Random.Range(0, objectToSpawn.Length)],  new Vector3(/*UnityEngine.Random.Range(-47, -20)*/ -30f, 2.10f, UnityEngine.Random.Range(-7, 10)), Quaternion.identity) as GameObject;
                obj.Add(obb);
                // Запуск корутины для движения объекта
                StartCoroutine(MoveObject(obb));

                //Obj.Add(objectToSpawn[i]);

                // Ожидание перед созданием следующего объекта
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private IEnumerator MoveObject(GameObject obj)
    {
        while (obj != null)
        {
            
            // Движение объекта по оси X
            obj.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
            yield return null;
        }
    }


   private IEnumerator IncreaseVariableRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            if (moveSpeed <= 40f)
            {
                moveSpeed *= 1.25f;
                spawnInterval /= 1.30f;
            }
            Debug.Log("Значение скорости увеличено! Новое значение: " + moveSpeed);
            Debug.Log("Значение спавна увеличено! Новое значение: " + spawnInterval);
        }
    }

}