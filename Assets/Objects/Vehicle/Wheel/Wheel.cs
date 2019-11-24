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
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public class Wheel : MonoBehaviour
	{
        public bool drive = true;

        public bool brake = true;

        public bool steer = true;

        [SerializeField]
        protected GameObject mesh;
        public GameObject Mesh { get { return mesh; } }

        public WheelCollider collider { get; protected set; }

        private void Reset()
        {
            mesh = GetComponentInChildren<Renderer>()?.gameObject;
        }

        private void Awake()
        {
            collider = GetComponentInChildren<WheelCollider>();
        }

        Vector3 position;
        Quaternion rotation;

        private void Update()
        {
            collider.GetWorldPose(out position, out rotation);

            mesh.transform.position = position;
            mesh.transform.rotation = rotation;
        }
    }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
}