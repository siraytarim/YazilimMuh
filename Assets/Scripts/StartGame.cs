using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
     void Start()
    {
       Button btn = GetComponent<Button>();
        // Butona tıklandığında `ChangeScene` fonksiyonunu çağır
        btn.onClick.AddListener(() => ChangeScene() );
    }
    void ChangeScene()
    {
        // Sahneyi değiştir
        Debug.Log("fg");
        SceneManager.LoadScene(1);
    }
   
}
