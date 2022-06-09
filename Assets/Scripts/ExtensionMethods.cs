using System;
using System.Collections;
using System.Collections.Generic;



namespace Memory.Utilities
{


    public static class ExtensionMethods
    {
        private static Random _random = new Random();

        public static List<T> Shuffle<T>(this List<T> original)
        {
            List<T> ShallowInputClone = new List<T>(original);
            List<T> result = new List<T>(ShallowInputClone.Count);
            while (ShallowInputClone.Count > 0)
            {
                int index = _random.Next(0, ShallowInputClone.Count);
                result.Add(ShallowInputClone[index]);
                ShallowInputClone.RemoveAt(index);
            }
            return result;

        }
    }
}