using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    private Color _color = Color.white;
    public Color Color 
    {
        get => _color; 
        set 
        {
            _color = value;
            Renderer.material.color = _color;
        }
    }

    private Renderer _renderer;
    public Renderer Renderer
    {
        get
        {
            if (_renderer == null) _renderer = GetComponent<Renderer>();
            return _renderer;
        }
        set => _renderer = value;
    }
}
