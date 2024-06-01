namespace Units.Behavior.Tree {
   public class SequenceNode : CompositionNode {
      private int _id;


      public SequenceNode(params Node[] children) : base(children) { }

      protected override void OnBegin() => _id = 0;

      protected override Status OnRun() {
         Status status;

         do {
            status = Children[_id].Run();
         } while (status == Status.Succes && ++_id < Children.Count);

         return status;
      }
   }
}