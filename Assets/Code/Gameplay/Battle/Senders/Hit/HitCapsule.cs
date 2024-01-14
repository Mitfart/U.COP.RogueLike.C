using System;
using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Senders.Hit {
   [RequireComponent(typeof(CapsuleCollider2D))]
   public class HitCapsule : HitArea<CapsuleCollider2D> {
      protected override void OnDrawGizmos() {
         base.OnDrawGizmos();

         Transform  self       = transform;
         Vector3    position   = self.position;
         Quaternion rotation   = self.rotation;
         Vector3    lossyScale = self.lossyScale;

         CapsuleDirection2D direction = collider.direction;
         Vector2            size      = collider.size;
         float              width     = size.x;
         float              height    = size.y;

         float   radius;
         Vector3 radiusOffsetDir;
         float   radiusOffsetLength;

         switch (direction) {
            case CapsuleDirection2D.Vertical:
               radius             = width * .5f;
               radiusOffsetDir    = Vector3.up;
               radiusOffsetLength = height;
               break;
            case CapsuleDirection2D.Horizontal:
               radius             = height * .5f;
               radiusOffsetDir    = Vector3.right;
               radiusOffsetLength = width;
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }

         radiusOffsetLength = Mathf.Max(0, radiusOffsetLength * .5f - radius);

         Vector3 radiusOffsetRelative = radiusOffsetDir * radiusOffsetLength;
         Vector3 radiusOffsetGlobal   = rotation        * radiusOffsetRelative;

         size -= (Vector2)radiusOffsetDir * 2f * radius;
         size = new Vector2(
            Mathf.Max(0, size.x),
            Mathf.Max(0, size.y)
         );

         Vector3 offsetGlobal = rotation * collider.offset;

         UGizmos.DrawFilledSphere(
            radius,
            position + offsetGlobal + radiusOffsetGlobal,
            rotation,
            lossyScale
         );

         UGizmos.DrawFilledSphere(
            radius,
            position + offsetGlobal - radiusOffsetGlobal,
            rotation,
            lossyScale
         );

         new Rect(offsetGlobal, size).DrawGizmos(transform);
      }
   }
}