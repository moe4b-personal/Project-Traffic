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

using UnityEngine.Events;

namespace Game
{
	public class VehicleDestination : MonoBehaviour
	{
        [SerializeField]
        protected ExitArea target;
        public ExitArea Target { get { return target; } }

        public Vehicle Car { get; protected set; }

        public void Set(Vehicle reference) => Car = reference;

        private void Start()
        {
            target.TriggerEnter.AddListener(TargetTriggerCallback);
        }

        void TargetTriggerCallback(Collider collider)
        {
            if (collider.attachedRigidbody == null) return;

            if (collider.attachedRigidbody == Car.rigidbody)
            {
                Reached();
            }
        }

        [SerializeField]
        protected UnityEvent onReached;
        public UnityEvent OnReached { get { return onReached; } }
        void Reached()
        {
            onReached.Invoke();
        }
    }
}