using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
    [SelectionBase]
    [RequireComponent(typeof(Rigidbody))]
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public class Car : MonoBehaviour
	{
        public Honk Honk { get; protected set; }

        public CarDestination Destination { get; protected set; }

        public Rigidbody rigidbody { get; protected set; }

        public Selectable3D Selectable { get; protected set; }

        private void Awake()
        {
            Honk = GetComponentInChildren<Honk>();

            Destination = GetComponentInChildren<CarDestination>();
            Destination.Set(this);

            rigidbody = GetComponent<Rigidbody>();

            Selectable = GetComponentInChildren<Selectable3D>();
        }

        private void Start()
        {
            Selectable.PointerClick.AddListener(ClickCallback);
        }

        void ClickCallback()
        {
            Honk.Use();
        }
    }
}
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword