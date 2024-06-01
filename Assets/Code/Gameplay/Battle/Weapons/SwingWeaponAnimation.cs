using DG.Tweening;
using EasyButtons;
using UnityEngine;

namespace Battle.Weapons {
   public class SwingWeaponAnimation : MonoBehaviour {
      public Weapon    weapon;
      public Transform body;
      public Transform view;
      public Vector2   offset      = new(x: 1f, y: .25f);
      public Vector2   swingOffset = new(x: 2f, y: 0f);
      public float     rotation    = 25f;
      public Ease      ease        = Ease.OutBack;

      private bool _isSecondSwing;



      private void Start() {
         body.transform.localRotation = Quaternion.Euler(x: 0, y: 0, z: 90f);

         Transform viewT = view.transform;
         viewT.localRotation = Quaternion.Euler(x: 0f, y: 0f, rotation);
         viewT.localPosition = offset;
      }

      private void OnEnable()  => weapon.OnBeginAttack += Swing;
      private void OnDisable() => weapon.OnBeginAttack -= Swing;



      private void OnValidate() {
         if (Application.isPlaying)
            return;

         body.transform.localRotation = Quaternion.Euler(x: 0, y: 0, z: 90f);

         Transform viewT = view.transform;
         viewT.localRotation = Quaternion.Euler(x: 0f, y: 0f, rotation);

         viewT.localPosition = offset;
      }



      [Button]
      private void Swing() {
         int sign = _isSecondSwing ? 1 : -1;
         _isSecondSwing = !_isSecondSwing;

         offset.y *= -1;

         body.DOLocalRotate(Vector3.forward * (sign * 180f), weapon.reloadDuration, RotateMode.LocalAxisAdd)
             .SetUpdate(UpdateType.Fixed)
             .SetEase(ease);
         view.DOLocalRotate(
                 Vector3.forward * (sign * (180f + rotation * 2f)),
                 weapon.reloadDuration,
                 RotateMode.LocalAxisAdd
              )
             .SetUpdate(UpdateType.Fixed)
             .SetEase(ease);

         view.DOLocalMove(swingOffset, weapon.reloadDuration * .5f)
             .SetEase(ease)
             .SetUpdate(UpdateType.Fixed)
             .OnComplete(
                 () => view.DOLocalMove(offset, weapon.reloadDuration * .5f) //
                           .SetUpdate(UpdateType.Fixed)
                           .SetEase(ease)
              );
      }
   }
}