using UnityEngine;

namespace LLib
{
    public class ScrollRectScaleEffect : ScrollRectEffect
    {
        protected override void ApplyEffect(RectTransform target, Vector2 direction, float curvedValue)
        {
            target.localScale = Vector2.one * curvedValue;
        }
    }
}