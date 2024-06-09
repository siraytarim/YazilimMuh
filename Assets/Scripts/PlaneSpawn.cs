using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneSpawn : MonoBehaviour
{
    public GameObject[] floor;
    public GameObject[] environment;
    public int zPos;
    public bool creatingSection = false;
     int secNum;


    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());

        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(floor[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        Instantiate(environment[secNum], new Vector3(-0.01f, 0f, zPos), Quaternion.identity);
        zPos += 30;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
       