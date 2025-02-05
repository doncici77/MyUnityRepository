using UnityEngine;

public class MaterialChange : MonoBehaviour
{

    public Material skyboxMaterial; // 스카이박스 재질

    void Start()
    {
        RenderSettings.skybox = skyboxMaterial; // 스카이박스 재질 변경
    }

    void Update()
    {
        
    }
}
