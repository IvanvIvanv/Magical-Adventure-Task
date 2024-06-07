using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Inverts a scale vector by dividing 1 by each component
    /// </summary>
    public static Vector3 Invert(this Vector3 vec)
    {
        return new Vector3(1 / vec.x, 1 / vec.y, 1 / vec.z);
    }

    /// <summary>
    /// Adds number to each component of a vector
    /// </summary>
    public static Vector3 Add(this Vector3 vec, float num)
    {
        return new Vector3(vec.x + num, vec.y + num, vec.z + num);
    }

    /// <summary>
    /// Subtracts number from each component of a vector
    /// </summary>
    public static Vector3 Subtract(this Vector3 vec, float num)
    {
        return vec.Add(-num);
    }
}
