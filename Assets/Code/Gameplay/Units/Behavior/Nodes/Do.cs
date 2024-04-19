using System;
using Units.Behavior.Tree;

namespace Units.Behavior.Nodes {
   public class Do : Node {
      private readonly Action       _action;
      private readonly Func<Status> _runAction;

      public Do(Action       action) => _action = action;
      public Do(Func<Status> action) => _runAction = action;

      protected override void   OnBegin() => _action?.Invoke();
      protected override Status OnRun()   => _runAction?.Invoke() ?? Status.Succes;
   }
}