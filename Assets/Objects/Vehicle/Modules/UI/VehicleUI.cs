﻿using System;
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
	public class VehicleUI : MonoBehaviour, IReference<Vehicle>
	{
        public Vehicle Vehicle { get; protected set; }
        public void Set(Vehicle reference) => Vehicle = reference;

        public VehicleControlUI Controls { get; protected set; }

        private void Awake()
        {
            Controls = this.GetDependancy<VehicleControlUI>();
        }
    }
}