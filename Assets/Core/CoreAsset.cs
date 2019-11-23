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
    [CreateAssetMenu]
    public class CoreAsset : ScriptableObject
    {
        [SerializeField]
        protected GameObject prefab;
        public GameObject Prefab { get { return prefab; } }

        public GameObject Instance { get; protected set; }

        [RuntimeInitializeOnLoadMethod]
        static void OnLoad()
        {
            foreach (var core in Resources.LoadAll<CoreAsset>(""))
            {
                core.Configure();
            }
        }

        public void Configure()
        {
            Instance = GameObject.Instantiate(prefab);

            Instance.name = prefab.name;
        }
    }
}