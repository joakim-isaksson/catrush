using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ketsu
{
    public class GameManager : MonoBehaviour
    {
        public float FadeSpeed;
        public Text WinText;
        public Text TimeText;

        ScreenFaider Faider;

        public static bool Playing;

        float startTime;

        void Awake()
        {
            
        }

        void Start()
        {
            Playing = true;
            startTime = 0.0f;

            WinText.text = "Rush my little kitten!";
            DelayedAction(2.0f, delegate {
                WinText.text = "! RUSH !";
                DelayedAction(1.5f, delegate { WinText.text = ""; });
            });

            Faider = ScreenFaider.instance;
            Faider.SetTo(Color.black);
            Faider.FadeOut(Color.black, FadeSpeed, null);
        }

        void Update()
        {
            if (Playing)
            {
                startTime += Time.deltaTime;
                TimeText.text = "Time: " + startTime.ToString("00.00");
            }

            if (Input.GetButtonDown("Cancel"))
            {
                Faider.FadeIn(Color.black, FadeSpeed, delegate
                {
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                });
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Faider.FadeIn(Color.black, FadeSpeed, delegate
                {
                    SceneManager.LoadScene("Main", LoadSceneMode.Single);
                });
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Playing = false;
                WinText.text = "You Win";
                DelayedAction(3.0f, delegate {
                    Faider.FadeIn(Color.black, FadeSpeed, delegate
                    {
                        SceneManager.LoadScene("End", LoadSceneMode.Single);
                    });
                });
            }
        }

        public void DelayedAction(float time, Action action)
        {
            StartCoroutine(RunDelayedAction(time, action));
        }

        IEnumerator RunDelayedAction(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            if (action != null) action();
        }
    }
}