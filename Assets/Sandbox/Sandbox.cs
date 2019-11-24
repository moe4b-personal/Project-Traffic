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
    public class Sandbox : MonoBehaviour
    {
        Wheel[] wheels;

        public float torque = 40f;

        public float steer = 30f;

        public float brake = 60f;

        private void Awake()
        {
            wheels = GetComponentsInChildren<Wheel>();
        }

        private void Update()
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxis("Horizontal");

            foreach (var wheel in wheels)
            {
                wheel.collider.motorTorque = torque * vertical;

                if(wheel.transform.localPosition.z > 0f)
                wheel.collider.steerAngle = horizontal * steer;

                if(Input.GetKey(KeyCode.Space))
                {
                    wheel.collider.motorTorque = 0f;
                    wheel.collider.brakeTorque = Input.GetAxisRaw("Jump") * brake;
                }
                else
                {
                    wheel.collider.brakeTorque = 0f;
                }
            }
        }
    }
}