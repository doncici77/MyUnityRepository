using UnityEngine;

public class MaterialChange : MonoBehaviour
{

    public Material skyboxMaterial; // ��ī�̹ڽ� ����

    void Start()
    {
        RenderSettings.skybox = skyboxMaterial; // ��ī�̹ڽ� ���� ����
    }

    void Update()
    {
        
    }
}
