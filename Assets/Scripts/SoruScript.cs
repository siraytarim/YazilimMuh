using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace  Player{
public class SoruScript : MonoBehaviour
{
     public static SoruScript Instance { get; private set; }
     [SerializeField] GameObject SorununPaneli;
    [SerializeField] Button dogrucevap;
    [SerializeField] GameObject obstacle;
    [SerializeField] Animator _animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void OnMouseDown()
    {
        if (dogrucevap.name == "dogrucevap")
        {
            _animator.SetBool("dogruCevap",true);
            Manager.numberOfCoins += 15;
            Invoke("PanelGeriKapa",.6f);
          
            PlayerController.Instance.forwardSpeed = PlayerController.Instance.forwardSpeed;
            Destroy(obstacle);
            Time.timeScale = 1;
        }
        else if(dogrucevap.name != "dogrucevap")
        {
            PanelGeriKapa();
            Manager.gameOver = true;
        }
    }

    void PanelGeriKapa()
    {
        SoruPanelleri.secilecekSoru.SetActive(false);
    }
}
}