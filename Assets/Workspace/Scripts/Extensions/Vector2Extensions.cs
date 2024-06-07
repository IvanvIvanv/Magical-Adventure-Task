using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extensions
{
    /// <summary>
    /// Inverts a scale vector by dividing 1 by each component
    /// </summary>
    public static Vector2 Invert(this Vector2 vec)
    {
        return new Vector2(1 / vec.x, 1 / vec.y);
    }

    /// <summary>
    /// Adds number to each component of a vector
    /// </summary>
    public static Vector2 Add(this Vector2 vec, float num)
    {
        return new Vector2(vec.x + num, vec.y + num);
    }

    /// <summary>
    /// Subtracts number from each component of a vector
    /// </summary>
    public static Vector2 Subtract(this Vector2 vec, float num)
    {
        return vec.Add(-num);
    }

    /// <summary>
    /// Projects (x, y) vector on (x, 0f, z)
    /// </summary>
    public static Vector3 InputDirectionToWorldDirection(this Vector2 inputDirection)
    {
        return new Vector3(inputDirection.x, 0f, inputDirection.y);
    }
}
