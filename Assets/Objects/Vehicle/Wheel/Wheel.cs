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
    [RequireComponent(typeof(WheelCollider))]
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public class Wheel : MonoBehaviour
	{
        public WheelCollider collider { get; protected set; }

        private void Awake()
        {
            collider = GetComponent<WheelCollider>();
        }

        private void Update()
        {
            transform.Rotate(collider.rpm / 60 * 360 * Time.deltaTime * Vector3.right, Space.Self);
        }
    }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
}