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
	public class VehicleEngine : MonoBehaviour, IReference<Vehicle>
    {
        public Vehicle Vehicle { get; protected set; }
        public void Set(Vehicle reference) => Vehicle = reference;

        public VehicleEngineTorque Torque { get; protected set; }

        private void Awake()
        {
            Torque = this.GetDependancy<VehicleEngineTorque>();
        }
    }
}