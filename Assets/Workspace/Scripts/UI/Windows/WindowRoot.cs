using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class WindowRoot : MonoBehaviour
{
    public Image ImageToColor;
    public TextMeshProUGUI _nameTmpu;
    public RectTransform ContentContainer;
    public ScrollRect ScrollRect;

    [System.NonSerialized] public GameObject WindowSource;
    [System.NonSerialized] public float CloseDistance;

    private WindowNecessaries _windowNecessaries;
    public WindowNecessaries WindowNecessaries
    {
        get
        {
            if (_windowNecessaries == null) throw new System.NullReferenceException("WindowNecessaries is null, probably you forgot to construct WindowRoot");
            return _windowNecessaries;
        }
        private set
        {
            _windowNecessaries = value;
        }
    }

    private GameObject _content;

    public void SetName(string name)
    {
        _nameTmpu.text = name;
    }

    public void SetColor(Color color)
    {
        ImageToColor.color = color;
    }

    public void SetCloseDistance(float distance, GameObject source)
    {
        CloseDistance = distance;
        WindowSource = source;
    }

    public void SetContent(GameObject content)
    {
        if (_content != null) Destroy(_content);
        _content = Instantiate(content, ContentContainer);
        ScrollRect.content = _content.GetComponent<RectTransform>();
    }

    public void Construct(WindowNecessaries windowNecessaries)
    {
        WindowNecessaries = windowNecessaries;
    }

    public void SetInteraction(bool enable)
    {
        ScrollRect.verticalScrollbar.enabled = enable;
    }

    private void Update()
    {
        if (CloseDistance <= 0) return;
        if (WindowSource == null) return;
        if (WindowNecessaries.Player == null) return;
        if (Vector3.Distance(WindowNecessaries.Player.transform.position, WindowSource.transform.position) >= CloseDistance)
            Destroy(gameObject);
    }
}
