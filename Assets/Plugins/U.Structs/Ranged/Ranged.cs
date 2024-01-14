using System;
using UnityEngine;

namespace Structs.Ranged {
   [Serializable]
   public struct Ranged {
      [SerializeField] private float min;
      [SerializeField] private float max;
      [SerializeField] private float minEdge;
      [SerializeField] private float maxEdge;

      public bool rounded;

      public float Min {
         get => min;
         set => min = Mathf.Min(value, max);
      }

      public float Max {
         get => max;
         set => max = Mathf.Max(value, min);
      }

      public float MinEdge {
         get => minEdge;
         set => minEdge = Mathf.Min(value, min);
      }

      public float MaxEdge {
         get => maxEdge;
         set => maxEdge = Mathf.Max(value, max);
      }



      public float Clamp(float value) => Mathf.Clamp(value, Min, Max);
      public int   Clamp(int   value) => Mathf.RoundToInt(Clamp((float)value));

      public float Random()    => UnityEngine.Random.Range(Min, Max);
      public int   RandomInt() => Mathf.RoundToInt(Random());



      public override string ToString() => $"Value: ({Min}, {Max}),  Edges: ({MinEdge}, {MaxEdge})";
   }
}