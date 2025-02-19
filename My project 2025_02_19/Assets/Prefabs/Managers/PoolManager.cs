using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting;

// Ǯ(������)
// ������Ʈ�� Ǯ�� �����ΰ�, �ʿ��� ������ Ǯ �ȿ� �ִ� ��ü�� ������ ����ϴ� ���.
// �Ź� �ǽð����� �ı��ϰ�, �����ϴ� ������ cpu�� �δ��� ���� �� �ִ�.
// ��� �̸� �Ҵ��صδ� ����̱� ������ �޸𸮸� ����ؼ� ������ ���̴� ����Դϴ�.

// Ǯ�� ���� �۾� �� �ʿ��� �������� �����ϰ� �ִ� �������̽�
public interface IPool
{
    // Property
    Transform parent { get; set; }

    Queue<GameObject> pool { get; set; } // FIFO(First In First Out)

    // Function
    // default parameter : ���� ���� ���� �ʾ��� �ܿ� ������ ������ �ڵ� ó���˴ϴ�.
    // ex) var go = GetGameObject()
    // ex) var go = GetGameObject(action)

    // ���͸� �������� ���
    GameObject GetGameObject(Action<GameObject> action = null);
    /*GameObject Ŭ������ ��ȯ�ϴ� �Լ��� GetGameObject
    GameObject Ÿ���� �Ű������� �޴� Action ��������Ʈ(�Լ��� �����ϴ� �ڷ���) �ڷ����� ���� action
    �Լ� ȣ�� �� action ���� �������� ������ �⺻�� null�� ������ (GetGameObject(); ȣ�� ��)*/

    // ���͸� �ݳ��ϴ� ���
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);
}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public void ggg(int k, int gg = 5)
    {
        gg += 3;
    }

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue(); // Ǯ�� �ִ� �� �ϳ� �����ڴ�.

        obj.SetActive(true);// ������Ʈ Ȱ��ȭ ����

        // �׼����� ���޹��� ���� �ִٸ�?
        if(action != null)
        {
            action?.Invoke(obj);
            // ���޹��� �׼��� �����մϴ�.
            // ?�� null�� ���� ����
        }

        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);

        // �׼����� ���޹��� ���� �ִٸ�?
        if (action != null)
        {
            action?.Invoke(ob);
            // ���޹��� �׼��� �����մϴ�.
            // ?�� null�� ���� ����
        }
    }
}

public class PoolManager : MonoBehaviour
{
    public Dictionary<string, IPool> pool_dict = new Dictionary<string, IPool>();
    // Key: string
    // Value : IPool

    public IPool PoolObject(string path)
    {
        // �ش� Ű�� ���ٸ� �߰��� �����մϴ�.
        if(!pool_dict.ContainsKey(path))
        {
            Add(path);
        }

        return pool_dict[path];
        // ��ųʸ���[Ű] = ��;
    }

    public GameObject Add(string path)
    {
        var obj = new GameObject(path + "pool");
        // ���޹��� �̸����� Ǯ ������Ʈ ����

        ObjectPool object_pool = new ObjectPool();
        // ������Ʈ Ǯ ����

        pool_dict.Add(path, object_pool);
        // ��ο� ������Ʈ Ǯ�� ��ųʸ��� ����

        object_pool.parent = obj.transform;
        // Ʈ������(��ġ) ����

        return obj;
    }

}
