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

using UnityEngine.EventSystems;

namespace Game
{
	public class UIEventPassThrough : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
	{
        [SerializeField]
        uint depth = 1;
        public uint Depth => depth;

        public bool PointerClick = true;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (PointerClick == false) return;

            Pass(gameObject, eventData, depth, ExecuteEvents.pointerClickHandler);
        }

        public bool PointerDown = true;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (PointerDown == false) return;

            Pass(gameObject, eventData, depth, ExecuteEvents.pointerDownHandler);
        }

        public bool PointerUp = true;
        public void OnPointerUp(PointerEventData eventData)
        {
            if (PointerUp == false) return;

            Pass(gameObject, eventData, depth, ExecuteEvents.pointerUpHandler);
        }

        static List<RaycastResult> list = new List<RaycastResult>();
        public static void Pass<TInterface>(GameObject source, PointerEventData eventData, uint depth, ExecuteEvents.EventFunction<TInterface> functor)
            where TInterface : IEventSystemHandler
        {
            EventSystem.current.RaycastAll(eventData, list);

            var count = 0;
            for (int i = 0 ; i < list.Count; i++)
            {
                if (list[i].gameObject == source) continue;

                var handler = ExecuteEvents.ExecuteHierarchy(list[i].gameObject, eventData, functor);

                if(handler == null)
                {

                }
                else
                {
                    count += 1;
                }

                if (count >= depth) break;
            }
        }
    }
}