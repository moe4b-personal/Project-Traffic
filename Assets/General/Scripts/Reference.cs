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
    public interface IReference<T>
    {
        void Set(T reference);
    }

    public static class References
    {
        public static List<IReference<TReference>> Set<TReference>(TReference reference)
            where TReference : Component
        {
            var targets = Dependancy.GetAll<IReference<TReference>>(reference.gameObject);

            for (int i = 0; i < targets.Count; i++)
                targets[i].Set(reference);

            return targets;
        }
    }
}