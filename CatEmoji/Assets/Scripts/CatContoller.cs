using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ketsu
{
    public class CatContoller : MonoBehaviour
    {
        public float PushForce;
        public float PushTorque;

        public AudioClip BoostSfx;
        public AudioClip SlowSfx;
        public AudioClip IddleSfx;

        Rigidbody2D rb;
        AudioSource asrc;
        Animator anim;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            asrc = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            asrc.PlayOneShot(IddleSfx);
            RandomSound();
        }

        void Update()
        {
            if (Input.anyKeyDown)
            {
                rb.AddForce(Vector2.right * PushForce);
                rb.AddTorque(-PushTorque);
            }
        }

        public void Boost()
        {
            anim.SetTrigger("Dead");
            asrc.PlayOneShot(BoostSfx);
            rb.AddForce(Vector2.right * PushForce * 8);
            rb.AddTorque(-PushTorque * 8);
        }

        public void Slow()
        {
            anim.SetTrigger("Dead");
            asrc.PlayOneShot(SlowSfx);
            rb.AddForce(Vector2.left * PushForce);
            rb.AddTorque(PushTorque);
        }

        public void RandomSound()
        {
            DelayedAction(1.0f + UnityEngine.Random.value * 5.0f, delegate {
                asrc.PlayOneShot(IddleSfx);
                RandomSound();
            });
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