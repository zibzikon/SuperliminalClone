using UnityEngine;

namespace Code.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 WithNewY(this Vector3 vector, float value) => new (vector.x, value, vector.z);
        public static Vector3 WithNewX(this Vector3 vector, float value) => new (value, vector.y, vector.z);
        public static Vector3 WithNewZ(this Vector3 vector, float value) => new (vector.x, vector.y, value);
        
        public static Vector2 WithNewY(this Vector2 vector, float value) => new (vector.x, value);
        public static Vector2 WithNewX(this Vector2 vector, float value) => new (value, vector.y);
        
        public static Vector3 Project(this Vector3 vector, Vector3 on)
        {
            var magnitude = on.magnitude;
            return Vector2.Dot(vector, on) / (magnitude * magnitude) * on;
        }
    }
}