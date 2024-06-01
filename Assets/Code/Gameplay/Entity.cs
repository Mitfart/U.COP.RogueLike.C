using Attributes.ReadOnly;
using Structs.Optional;
using Units;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour {
   [field: SerializeField, SpaceAfter] private Transform body;
   [field: SerializeField]             public  string    Name { get; private set; }
   [field: SerializeField]             public  Team      Team { get; private set; }

   [field: SerializeField] public Optional<Health>          Health          { get; private set; }
   [field: SerializeField] public Optional<Invulnerability> Invulnerability { get; private set; }
   [field: SerializeField] public Optional<View>            View            { get; private set; }
   [field: SerializeField] public Optional<WeaponOwner>     WeaponOwner     { get; private set; }



   public Vector2 Position {
      get => body.Position2D();
      set => body.position = value;
   }

   public Quaternion Rotation {
      get => body.rotation;
      set => body.rotation = value;
   }

   public Vector3 Angles => body.eulerAngles;

   public float Scale {
      get => body.localScale.x;
      set => body.localScale = Vector3.one * value;
   }

   public Matrix4x4 Matrix => body.localToWorldMatrix;

   public bool Invulnerable => Invulnerability.enabled && Invulnerability.value.Invulnerable;



   private void Awake()        => body = body.IsUnityNull() ? transform : body;
   private void OnDrawGizmos() => body = body.IsUnityNull() ? transform : body;



   public void SetTeam(Team team) => Team = team;

   public void Die() => Destroy(gameObject);

   public Transform GetBody() => body;
}