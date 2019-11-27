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
	public class VehicleWheels : MonoBehaviour, IReference<Vehicle>
    {
		public List<Wheel> List { get; protected set; }

        public int Count => List.Count;
        public Wheel this[int index] => List[index];

        public VehicleWheelsSteer Steer { get; protected set; }

        public Vehicle Vehicle { get; protected set; }
        public void Set(Vehicle reference) => Vehicle = reference;

        private void Awake()
        {
            List = Dependancy.GetAll<Wheel>(Vehicle.gameObject);

            Steer = this.GetDependancy<VehicleWheelsSteer>();
        }
    }
}