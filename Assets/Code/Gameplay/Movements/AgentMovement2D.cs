using UnityEngine;
using UnityEngine.AI;

namespace Movements {
   public class AgentMovement2D : Movement2D {
      public NavMeshAgent agent;

      public override Vector2 Direction => agent.velocity.normalized;
      public override Vector2 Velocity  => agent.velocity;



      public override void SetSpeed(float value) {
         base.SetSpeed(value);
         agent.speed = Speed;
      }

      public override void SetDestination(Vector2 destination) {
         if (NavMesh.SamplePosition(destination, out NavMeshHit hit, float.MaxValue, NavMesh.AllAreas)
          || NavMesh.FindClosestEdge(destination, out hit, NavMesh.AllAreas))
            destination = hit.position;

         base.SetDestination(destination);

         agent.SetDestination(destination);
      }
   }
}