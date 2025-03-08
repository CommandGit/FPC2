using UnityEngine;

internal class PrefabController
{
    public bool IsCreated => _isCreated;
    public bool IsShow => _isShow;

    private GameObject _prefab;
    protected GameObject _rootGameObject;
    private bool _isCreated;
    private bool _isShow;

    public PrefabController()
    {
        _prefab = null;
        _rootGameObject = null;
        _isCreated = false;
        _isShow = false;
    }

    public PrefabController(string prefabPath)
    {
        InitPrefab(prefabPath);
        _rootGameObject = null;
        _isCreated = false;
        _isShow = false;
    }

    public void InitPrefab(string prefabPath)
    {
        _prefab = Resources.Load<GameObject>(prefabPath);
    }

    public virtual void Instantiate()
    {
        Instantiate(Vector3.zero, Quaternion.identity);
    }

    public virtual void Instantiate(Vector3 position, Quaternion rotation)
    {
        if (_isCreated) return;
        _rootGameObject = GameObject.Instantiate(_prefab, position, rotation);
        _isCreated = true;
        _isShow = _rootGameObject.activeSelf;
    }

    public virtual void Destroy()
    {
        if (!_isCreated) return;
        GameObject.Destroy(_rootGameObject);
        _isCreated = false;
        _isShow = false;
    }

    public void Show()
    {
        if (!_isCreated) return;
        if (_isShow) return;

        _rootGameObject.SetActive(true);
        _isShow = true;
    }

    public void Hide()
    {
        if (!_isCreated) return;
        if (!_isShow) return;

        _rootGameObject.SetActive(false);
        _isShow = false;
    }
}
