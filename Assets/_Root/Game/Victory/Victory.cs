using UnityEngine;

internal sealed class Victory
{
    private bool _isCreated = false;

    public void Instantiate()
    {
        if (_isCreated) return;

        GameObject prefab = Resources.Load<GameObject>("Victory");
        GameObject.Instantiate(prefab);
        _isCreated = true;
    }
}
