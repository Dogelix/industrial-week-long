﻿using System;
using UnityEngine;


namespace Utilities
{
    public static class Extensions
    {
        public static GameObject Find(this MonoBehaviour script, string tag)
        {
            var result = GameObject.FindGameObjectWithTag(tag);
            if (result == null)
                throw new Exception();

            return result;
        }

        public static T Find<T>(this MonoBehaviour script, string tag)
            where T : MonoBehaviour
        {
            var result = Find(script, tag)
                .GetComponent<T>();

            if (result == null)
                throw new Exception();

            return result;
        }

        public static T FindInChild<T>(this MonoBehaviour script, string tag)
        {
            var result = Find(script, tag)
                .GetComponentInChildren<T>();

            if (result == null)
                throw new Exception();

            return result;
        }
    }
}