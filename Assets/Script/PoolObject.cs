using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PoolObject<T> where T : MonoBehaviour
{
    private T prefab;
    private Transform containerPosition;
    public List<T> pool;


    public PoolObject(T prefab, Transform containerPosition)
    {
        this.prefab = prefab;
        this.containerPosition = containerPosition;
        pool = new List<T>();
    }

    private bool TryGetActiveElement(out T obj) => obj = pool.FirstOrDefault(x => !x.isActiveAndEnabled);

    public T GetOrActive()
    {
        if (!TryGetActiveElement(out var obj))
        {
            obj = Create();
        }
        obj.transform.position = containerPosition.position;
        obj.gameObject.SetActive(true);
        return obj;
    }
    
    private T Create()
    {
        var obj = Object.Instantiate(prefab, containerPosition);
        pool.Add(obj);
        return obj;
    }

    public bool IsActive(T obj) => obj.gameObject.activeSelf; 
    public void Release(T obj)
    {
        if (pool.Contains(obj))
        {
            obj.gameObject.SetActive(false);
        }
    }
}
