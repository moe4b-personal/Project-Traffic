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
	public class VehicleWheelsSteer : MonoBehaviour, IReference<Vehicle>
	{
        public Vehicle Vehicle { get; protected set; }
        public void Set(Vehicle reference) => Vehicle = reference;

        public VehicleWheels Wheels => Vehicle.Wheels;

        [SerializeField]
        protected float range = 40f;
        public float Range { get { return range; } }

        [SerializeField]
        protected float speed = 360f;
        public float Speed { get { return speed; } }

        float _angle = 0f;
        public float Angle
        {
            get => _angle;
            set
            {
                value = Mathf.Clamp(value, -range, range);

                _angle = value;

                for (int i = 0; i < Wheels.Count; i++)
                {
                    if (Wheels[i].steer == false) continue;

                    Wheels[i].collider.steerAngle = _angle;
                }
            }
        }

        public float Rate { set => Angle = value * range; }

        float _target;
        public float Target
        {
            get => _target;
            set
            {
                value = Mathf.Clamp(value , - 1f, 1f);

                _target = value;
            }
        }

        private void Update()
        {
            Angle = Mathf.MoveTowards(Angle, Target * range, speed * Time.deltaTime);
        }
    }
}