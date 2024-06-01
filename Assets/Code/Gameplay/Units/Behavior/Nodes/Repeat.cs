using Units.Behavior.Tree;

namespace Units.Behavior.Nodes {
   public class Repeat : CompositionNode {
      private readonly int  _amount;
      private readonly bool _notInfinite;

      private int _passedAmount;



      public Repeat(params Node[] children) : base(children) { }

      public Repeat(int amount, params Node[] children) : base(children) {
         _amount      = amount;
         _notInfinite = true;
      }


      protected override void OnBegin() => _passedAmount = 0;

      protected override Status OnRun() {
         base.OnRun();
         return EndRepeating() ? Status.Succes : Status.Run;
      }

      private bool EndRepeating() => _notInfinite && _passedAmount++ >= _amount;
   }
}