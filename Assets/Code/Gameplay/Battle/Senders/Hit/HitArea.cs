using UnityEngine;

namespace Gameplay.Battle.Senders.Hit {
   [RequireComponent(typeof(Collider2D))] public abstract class HitArea : HitDataSender { }
}