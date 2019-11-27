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
    [RequireComponent(typeof(Rigidbody))]
	public class CenterOfGravity : MonoBehaviour
	{
#pragma warning disable IDE1006 // Naming Styles
        public new Rigidbody rigidbody { get; protected set; }
#pragma warning restore IDE1006 // Naming Styles

        [SerializeField]
        Vector3 value = Vector3.zero;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();

            rigidbody.centerOfMass = value;
        }

#if UNITY_EDITOR
        private void Update()
        {
            rigidbody.centerOfMass = value;
        }
#endif

#if UNITY_EDITOR
        private void OnDrawGizmos() => OnDrawGizmos(false);

        private void OnDrawGizmosSelected() => OnDrawGizmos(true);

        void OnDrawGizmos(bool selected)
        {
            Handles.matrix = Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(value, 0.05f);

            void DrawAxis(Color color, Vector3 direction)
            {
                var size = direction + (Vector3.one * 0.015f);

                Gizmos.color = color;
                Gizmos.DrawCube(value, size);
            }
            DrawAxis(Color.red, Vector3.right);
            DrawAxis(Color.blue, Vector3.forward);
            DrawAxis(Color.green, Vector3.up);
        }
#endif
    }
}