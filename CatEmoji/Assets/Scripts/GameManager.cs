using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ketsu
{
    public class GameManager : MonoBehaviour
    {
        public float FadeSpeed;

        ScreenFaider Faider;

        void Awake()
        {

        }

        void Start()
        {
            Faider = ScreenFaider.instance;
            Faider.SetTo(Color.black);
            Faider.FadeOut(Color.black, FadeSpeed, null);
        }

        void Update()
        {
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
    }
}