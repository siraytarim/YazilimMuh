using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class SoruPanelleri : MonoBehaviour
    {
        public static SoruPanelleri Instance { get; private set; }
        public List<GameObject> sorular;
        private int secileceksoruDegeri;
        public static GameObject secilecekSoru;
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
            foreach (GameObject soru in sorular)
            {
                secileceksoruDegeri = UnityEngine.Random.Range(0,sorular.Count);
                secilecekSoru = sorular[secileceksoruDegeri];
                //sorular.Remove(secilecekSoru);

            }
        }

    }
}