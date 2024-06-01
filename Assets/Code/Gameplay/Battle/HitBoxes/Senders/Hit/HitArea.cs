using System;
using Battle.HitBoxes.Receiver.Hit;
using Extensions;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Battle.HitBoxes.Senders.Hit {
   [RequireComponent(typeof(Collider2D))]
   public class HitArea : HitDataSender<HitArea, HitReceiver> {
      protected virtual void OnDrawGizmos() {
         Collider2D uCollider = GetComponent<Collider2D>();

         Gizmos.color = Color.green;

         switch (uCollider) {
            case BoxCollider2D boxCollider2D:
               new Rect(boxCollider2D.offset, boxCollider2D.size).DrawGizmos(transform);
               break;

            case CapsuleCollider2D capsuleCollider2D:
               Matrix4x4          matrix    = transform.localToWorldMatrix;
               CapsuleDirection2D direction = capsuleCollider2D.direction;
               Vector2            size      = capsuleCollider2D.size;
               float              width     = size.x;
               float              height    = size.y;

               float   radius;
               Vector3 radiusOffsetDir;

               switch (direction) {
                  case CapsuleDirection2D.Vertical:
                     radius          = width * .5f;
                     radiusOffsetDir = Vector3.up;
                     break;
                  case CapsuleDirection2D.Horizontal:
                     radius          = height * .5f;
                     radiusOffsetDir = Vector3.right;
                     break;
                  default:
                     throw new ArgumentOutOfRangeException();
               }

               size -= (Vector2)radiusOffsetDir * 2f * radius;
               size = new Vector2( //
                  Mathf.Max(a: 0, size.x),
                  Mathf.Max(a: 0, size.y)
               );

               float radiusOffsetLength = direction switch {
                  CapsuleDirection2D.Vertical   => size.y * .5f,
                  CapsuleDirection2D.Horizontal => size.x * .5f,
                  _                             => throw new ArgumentOutOfRangeException()
               };

               Vector3 radiusOffsetGlobal = radiusOffsetDir * radiusOffsetLength;
               Vector3 offsetGlobal       = capsuleCollider2D.offset;

               UGizmos.DrawFilledSphere(radius, offsetGlobal + radiusOffsetGlobal, matrix);
               UGizmos.DrawFilledSphere(radius, offsetGlobal - radiusOffsetGlobal, matrix);

               new Rect(offsetGlobal, size).DrawGizmos(transform);
               break;

            case CircleCollider2D circleCollider2D:
               UGizmos.DrawFilledSphere( //
                  circleCollider2D.radius,
                  circleCollider2D.offset,
                  transform.localToWorldMatrix
               );
               break;

            case CompositeCollider2D compositeCollider2D:
               break;

            case CustomCollider2D customCollider2D:
               break;

            case EdgeCollider2D edgeCollider2D:
               break;

            case PolygonCollider2D polygonCollider2D:
               break;

            case TilemapCollider2D tilemapCollider2D:
               break;

            default:
               throw new ArgumentOutOfRangeException(nameof(uCollider));
         }
      }
   }
}