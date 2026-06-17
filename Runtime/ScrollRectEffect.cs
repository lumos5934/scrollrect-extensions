using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(ScrollRect))]
public abstract class ScrollRectEffect : MonoBehaviour
{ 
    [SerializeField] protected float _effectDistance = 100f;
    [SerializeField] private AnimationCurve _effectCurve;
    
    
    protected ScrollRect _scrollRect;
    
    protected RectTransform ViewPort => _scrollRect.viewport;
    protected RectTransform Content => _scrollRect.content;
    
    
    protected virtual void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }


    protected virtual void LateUpdate()
    {
        if (ViewPort == null || 
            Content == null ||
            _effectCurve == null || 
            _effectDistance <= 0f)
            return;


        Vector2 center = ViewPort.rect.center;

        for (int i = 0; i < Content.childCount; i++)
        {
            var child = Content.GetChild(i) as RectTransform;
            if (child == null || 
                !child.gameObject.activeSelf)
                continue;

            Vector2 childPos = ViewPort.InverseTransformPoint(child.position);
            Vector2 offset = childPos - center;

            float distance = offset.magnitude;
            float clampedDistance = Mathf.Clamp01(distance / _effectDistance);

            float curveValue = _effectCurve.Evaluate(clampedDistance);

            
            Vector2 direction = offset.normalized;
            
            ApplyEffect(child, direction, curveValue);
        }
    }


    protected abstract void ApplyEffect(RectTransform target, Vector2 direction, float curvedValue);
}
