using UnityEngine;

namespace LLib
{
    public abstract class ScrollRectLayoutEffect : ScrollRectEffect
    {
        [SerializeField, Min(0)] protected float _effectDistanceX = 100f;
        [SerializeField, Min(0)] protected float _effectDistanceY = 100f;
        [SerializeField] protected AnimationCurve _curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);


        public AnimationCurve Curve
        {
            get => _curve;
            set => _curve = value;
        }
        
        public float EffectDistanceX
        {
            get => _effectDistanceX;
            set => _effectDistanceX = Mathf.Max(0f, value);
        }
        
        public float EffectDistanceY
        {
            get => _effectDistanceY;
            set => _effectDistanceY = Mathf.Max(0f, value);
        }
        
        protected float GetNormalizedDistance(ScrollItem item)
        {
            if (_effectDistanceX <= 0f || 
                _effectDistanceY <= 0f) 
                return 1f;
            
            float absX = Mathf.Abs(item.Direction.x);
            float absY = Mathf.Abs(item.Direction.y);
            
            float factorX = absX > 0 ? _effectDistanceX / absX : float.MaxValue;
            float factorY = absY > 0 ? _effectDistanceY / absY : float.MaxValue;
            
            float maxDist = Mathf.Min(factorX, factorY);

            return Mathf.Clamp01(item.Distance / maxDist);
        }
    }
}
