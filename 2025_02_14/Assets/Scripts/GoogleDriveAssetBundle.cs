using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{
    private string imageFileURL = "https://drive.usercontent.google.com/u/0/uc?id=1Sny7Efo8CAsWDyy7vVm_dKY1x600Nzk4&export=download";

    public Image image;
    public Button button;

    public void OnClickButton()
    {
        StartCoroutine("DownLoadImage");
    }
    
    IEnumerator DownLoadImage()
    {
        // �ش� �ּҸ� ���� �ؽ�ó�� ������Ʈ ��û�Ѵ�.
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        // ������Ʈ�� �Ϸ�� ������ ����մϴ�.
        yield return www.SendWebRequest();

        // ������Ʈ�� ����� �����̶��
        if(www.result == UnityWebRequest.Result.Success)
        {
            // �ٿ���� �ؽ�ó�� �����ϴ� �ڵ�
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Texture2D�� UI���� ���� ���� Sprite ���·� ����
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
           
            Debug.Log("�̹����� ���������� �����Խ��ϴ�.");

            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("�̹����� �������� ���߽��ϴ�.");
        }
    }
}
