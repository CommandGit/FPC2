using UnityEngine;

internal class ViewController<T> : PrefabController
{
    protected T _view;

    public ViewController() : base()
    {
        _view = default;
    }

    public ViewController(string prefabPath) : base(prefabPath)
    {
        _view = default;
    }

    public override void Instantiate(Vector3 position, Quaternion rotation)
    {
        base.Instantiate(position, rotation);
        _view = _rootGameObject.GetComponent<T>();
    }

    public override void Destroy()
    {
        base.Destroy();
        _view = default;
    }
}
