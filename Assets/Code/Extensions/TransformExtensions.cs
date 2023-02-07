using UnityEngine;

namespace Code.Domain.Extensions
{
    public static class TransformExtensions
    {
        public static RectTransform ResetToDefaults(this RectTransform rectTransform)
        {
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            
            return rectTransform;
        }
    }
}