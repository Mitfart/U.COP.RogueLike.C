using System;

namespace Units.Behavior.Tree {
   public abstract class ConditionNode : CompositionNode {
      private readonly Node _true;
      private readonly Node _false;



      protected ConditionNode(Node @true, Node @false) : base(@true, @false) {
         _true  = @true;
         _false = @false;
      }

      protected override Status OnRun() => Condition() ? True() : False();

      private Status True()  => _true?.Run()  ?? throw new Exception(message: "Not set required node @true");
      private Status False() => _false?.Run() ?? throw new Exception(message: "Not set required node @false");

      internal abstract bool Condition();
   }
}