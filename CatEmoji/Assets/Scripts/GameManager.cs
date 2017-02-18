using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ketsu
{
    public class GameManager : MonoBehaviour
    {
        public float FadeInTime;

        ScreenFaider Faider;

        void Awake()
        {

        }

        void Start()
        {
            Faider = ScreenFaider.instance;
            Faider.SetTo(Color.black);
            Faider.FadeOut(Color.black, FadeInTime, null);
        }

        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Application.Quit();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
        }
    }
}