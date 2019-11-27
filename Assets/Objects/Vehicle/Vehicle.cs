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
    [DefaultExecutionOrder(ExecutionOrder)]
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public class Vehicle : MonoBehaviour
	{
        public const int ExecutionOrder = -20;

        public Honk Honk { get; protected set; }

        public VehicleWheels Wheels { get; protected set; }

        public VehicleEngine Engine { get; protected set; }

        public VehicleDestination Destination { get; protected set; }

        public Rigidbody rigidbody { get; protected set; }

        public Selectable3D Selectable { get; protected set; }

        private void Awake()
        {
            Honk = this.GetDependancy<Honk>();

            Wheels = this.GetDependancy<VehicleWheels>();

            Engine = this.GetDependancy<VehicleEngine>();

            Destination = this.GetDependancy<VehicleDestination>();

            rigidbody = this.GetDependancy<Rigidbody>();

            Selectable = this.GetDependancy<Selectable3D>();

            References.Set(this);
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