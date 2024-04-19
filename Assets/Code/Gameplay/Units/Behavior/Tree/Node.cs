namespace Units.Behavior.Tree {
   public abstract class Node {
      public Entity Entity   { get; private set; }
      public Status Status   { get; private set; }
      public bool   IsActive { get; private set; }



      public void Init(Entity entity) {
         Entity = entity;
         OnInit();
      }

      public Status Run() {
         Begin();
         Status = OnRun();
         Finish();
         return Status;
      }

      private void Begin() {
         if (IsActive)
            return;

         IsActive = true;
         OnBegin();
      }

      private void Finish() {
         if (Status == Status.Run)
            return;

         OnFinish();
         IsActive = false;
      }



      protected virtual void   OnInit()   { }
      protected virtual void   OnBegin()  { }
      protected virtual Status OnRun()    => Status.Succes;
      protected virtual void   OnFinish() { }
   }
}