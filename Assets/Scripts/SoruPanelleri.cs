using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class SoruPanelleri : MonoBehaviour
    {
        public static SoruPanelleri Instance { get; private set; }
        public List<Transform> sorular;
        private int secileceksoruDegeri;
        public Transform secilecekSoru;
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
        
        public void soruSec()
        {
            foreach (Transform soru in sorular)
            {
                secileceksoruDegeri = UnityEngine.Random.Range(0,sorular.Count);
                secilecekSoru = sorular[secileceksoruDegeri];
                Invoke("RemoveQuestion",5f);
            }
        }

        void RemoveQuestion()
        {
            sorular.Remove(secilecekSoru);
        }

    }
}