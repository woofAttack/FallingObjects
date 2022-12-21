using UnityEngine;

public static class Vector3Ex
{
    public static Vector3 WithValueX(this Vector3 self, float x)
    {
        return new Vector3(x, self.y, self.z);
    }
}