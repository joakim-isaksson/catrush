using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        }
    }
}