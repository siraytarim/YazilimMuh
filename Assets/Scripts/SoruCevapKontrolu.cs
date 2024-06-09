using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class SoruCevapKontrolu : MonoBehaviour
    {
        public static SoruCevapKontrolu Instance { get; private set; }
        public Button[] answerButtons; // Cevap butonları
        
        [SerializeField] GameObject SorununPaneli;
         string correctAnswer = "dogrucevap" ; // Doğru cevabın ismi
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
        void Start()
        {
            // Her butona tıklandığında ilgili fonksiyonu çağır
            foreach (Button btn in answerButtons)
            {
                btn.onClick.AddListener(() => CheckAnswer(btn.name));
            }
        }

        public void CheckAnswer(string answer)
        {
            if (answer == correctAnswer)
            {
                Manager.numberOfCoins += 15;
                Invoke("PanelGeriKapa", .15f);
                PlayerController.Instance.forwardSpeed = PlayerController.Instance.forwardSpeed;
                Time.timeScale = 1;
            }
            else
            {
                Invoke("PanelGeriKapa", .05f);
                Time.timeScale = 0; // Oyunu durdur
                Manager.gameOver=true;
                
            }
        }

        void PanelGeriKapa()
        {
            SoruPanelleri.secilecekSoru.SetActive(false);
        }
    }
}