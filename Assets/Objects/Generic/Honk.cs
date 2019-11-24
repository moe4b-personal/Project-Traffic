using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Honk : MonoBehaviour
	{
		[SerializeField]
        protected AudioSource source;
        public AudioSource Source { get { return source; } }

        [SerializeField]
        protected AudioClip clip;
        public AudioClip Clip { get { return clip; } }

        public void Use()
        {
            source.PlayOneShot(clip);
        }
    }
}