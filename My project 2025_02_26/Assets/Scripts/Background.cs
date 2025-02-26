using UnityEngine;

// ��� ��ũ�� ����� ���� �̴ϴ�
// Ȯ���� �� : ��Ƽ���� offet�� �ǵ�ȴ��� �̹����� �и�����

// �ʿ��� �� : ��Ƽ����, ��ũ�Ѹ� �ӵ�
// ��� ������ ���ΰ�? ����? �Ʒ���? ������?

public class Background : MonoBehaviour
{
    public Material backgroundMaterial;
    public float scrollSpeed = 0.2f;

    private void Update()
    {
        Vector2 dir = Vector2.up;

        backgroundMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
