using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoruScript : MonoBehaviour
{
    [SerializeField] Button dogrucevap;
    [SerializeField] GameObject obstacle;

    public void OnMouseDown()
    {
        if (dogrucevap.name == "dogrucevap")
        {
            Manager.numberOfCoins += 15;
            gameObject.SetActive(false);
            PlayerController.forwardSpeed = PlayerController.forwardSpeed;
            Destroy(obstacle);
        }
    }
}
