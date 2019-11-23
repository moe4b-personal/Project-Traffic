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
	public class CameraRig : MonoBehaviour
	{
        [SerializeField]
        protected UIPanZone panZone;
        public UIPanZone PanZone { get { return panZone; } }

        [SerializeField]
        protected float speed;
        public float Speed { get { return speed; } }

        public Camera Component { get; protected set; }

        private void Awake()
        {
            Component = GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            if (panZone.Delta.magnitude > 0f)
            {
                transform.Rotate(Vector3.up, panZone.Delta.x * speed * Time.deltaTime, Space.World);
            }
        }
    }
}