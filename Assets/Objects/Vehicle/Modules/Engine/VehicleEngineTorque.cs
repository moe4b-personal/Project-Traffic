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
	public class VehicleEngineTorque : MonoBehaviour, IReference<Vehicle>
    {
        public Vehicle Vehicle { get; protected set; }
        public void Set(Vehicle reference) => Vehicle = reference;

        public VehicleWheels Wheels => Vehicle.Wheels;

        [SerializeField]
        protected float reverse;
        public float Reverse { get { return reverse; } }

        [SerializeField]
        protected float drive;
        public float Drive { get { return drive; } }

        float _value;
        public float Value
        {
            get => _value;
            set
            {
                for (int i = 0; i < Wheels.Count; i++)
                {
                    if (Wheels[i].drive == false) continue;

                    Wheels[i].collider.motorTorque = value;
                }
            }
        }

        /// <summary>
        /// 0 = reverse, 1 = drive
        /// </summary>
        public float Rate { set => this.Value = Mathf.LerpUnclamped(-reverse, drive, value); }

        /// <summary>
        /// -1 = reverse, 0 = 0, 1 = drive
        /// </summary>
        public float Scale
        {
            set
            {
                if (Mathf.Approximately(value, 0f))
                    Rate = 0f;
                else
                {
                    var direction = Mathf.Sign(value);

                    var target = direction < 0f ? reverse : drive;

                    this.Value = Mathf.LerpUnclamped(0f, target, Mathf.Abs(value)) * direction;
                }
            }
        }
    }
}