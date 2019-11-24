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

        public float speed;
        public float maxSpeed = 60f;

        Vehicle vehicle;

        private void Awake()
        {
            vehicle = GetComponent<Vehicle>();

            wheels = GetComponentsInChildren<Wheel>();
        }

        private void Update()
        {
            speed = vehicle.rigidbody.velocity.magnitude * 3.6f;
            if (speed > maxSpeed)
                vehicle.rigidbody.velocity = vehicle.rigidbody.velocity.normalized * (maxSpeed / 3.6f);

            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxis("Horizontal");

            foreach (var wheel in wheels)
            {
                if (wheel.drive)
                    wheel.collider.motorTorque = torque * vertical;

                if (wheel.steer)
                    wheel.collider.steerAngle = horizontal * steer;

                if(wheel.brake)
                {
                    if (Input.GetKey(KeyCode.Space))
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
}