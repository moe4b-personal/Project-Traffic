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
    [DefaultExecutionOrder(ExecutionOrder)]
	public class Core : MonoBehaviour
	{
        public const int ExecutionOrder = -200;

		public static Core Instance { get; protected set; }

        private void Awake()
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }
}