using UnityEngine;

public static class MonoBehaviourEx
{
    public static void ThrowExceptionIfNull(this MonoBehaviour self)
    {
        if (self == null)
            throw new System.Exception($"");
    }

    public static void DebugLogIfNull(this MonoBehaviour self)
    {
        if (self == null)
            Debug.LogWarning($"");
    }

    public static void Enable(this MonoBehaviour self)
    {
        self.gameObject.SetActive(true);
    }

    public static void Disable(this MonoBehaviour self)
    {
        self.gameObject.SetActive(false);
    }
}
