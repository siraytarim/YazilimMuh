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
         string correctAnswer = "correct" ; // Doğru cevabın ismi
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
            foreach (Button btn in answerButtons)
            {
                btn.onClick.AddListener(() => CheckAnswer(btn.name));
                Debug.Log(btn.name);
            }
        }

        public void CheckAnswer(string answer)
        {
            if (answer == correctAnswer)
            {
                Manager.numberOfCoins += 10;
                Invoke("PanelGeriKapa", .001f);
                Time.timeScale = 1;
            }
            else
            {
                Invoke("PanelGeriKapa", .001f);
                Time.timeScale = 0; // Oyunu durdur
                Manager.gameOver=true;                
            }
        }

        void PanelGeriKapa()
        {
            SoruPanelleri.Instance.secilecekSoru.gameObject.SetActive(false);
        }
    }
}