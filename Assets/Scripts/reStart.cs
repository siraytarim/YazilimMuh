using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class reStart : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => YenidenYükle());
    }

    void YenidenYükle()
    {
        SceneManager.LoadScene(1);
    }
}
