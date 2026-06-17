using UnityEngine;

namespace LLib
{
    public class ScrollRectRotationEffect : ScrollRectEffect
    {
        public enum RotationMode
        {
            Horizontal,
            Vertical,
            Radial
        }
        
        [Header("Rotation")]
        [SerializeField] private RotationMode _mode;
        [SerializeField] private Vector3 _centerRotation = Vector3.zero;
        [SerializeField] private Vector3 _edgeRotation = Vector3.zero;


        protected override void ApplyEffect(RectTransform target, Vector2 direction, float curvedValue)
        {
            Vector3 rotation = GetRotation(direction, curvedValue);

            target.localRotation = Quaternion.Euler(rotation);
        }


        private Vector3 GetRotation(Vector2 direction, float curveValue)
        {
            if (direction.sqrMagnitude <= Mathf.Epsilon)
                return _centerRotation;


            Vector3 targetRotation = _edgeRotation;


            switch (_mode)
            {
                case RotationMode.Horizontal:
                {
                    float sign = Mathf.Sign(direction.x);
                    targetRotation *= sign;
                    break;
                }

                case RotationMode.Vertical:
                {
                    float sign = Mathf.Sign(direction.y);
                    targetRotation *= sign;
                    break;
                }

                case RotationMode.Radial:
                {
                    float angle = Mathf.Atan2(
                        direction.y,
                        direction.x
                    ) * Mathf.Rad2Deg;


                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    targetRotation *= x;
                    break;
                }
            }


            return Vector3.LerpUnclamped(
                _centerRotation,
                targetRotation,
                curveValue
            );
        }
    }
}