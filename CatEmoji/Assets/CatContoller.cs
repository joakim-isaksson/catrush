using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ketsu
{
    public class CatContoller : MonoBehaviour
    {
        public float PushForce;
        public float PushTorque;

        Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            
        }

        void Update()
        {
            if (Input.anyKeyDown)
            {
                rb.AddForce(Vector2.right * PushForce);
                rb.AddTorque(-PushTorque);
            }
        }
    }
}