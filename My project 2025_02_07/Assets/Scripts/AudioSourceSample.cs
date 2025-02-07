using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{
    // 0) �ν����Ϳ��� ���� �����ϴ� ���
    public AudioSource audioSourceBGM;

    // 1)AudioSourceSample ��ü�� ��ü������ ����� �ҽ��� ������ �ִ� ���
    //private AudioSource own_audioSource;

    // 3) ������ ã�Ƽ� �����ϴ� ���
    // 4) Resources.Load() ��ɸ� �̿��� ���ҽ� ������ �ִ� ����� �ҽ��� Ŭ���� �޾ƿ��ڽ��ϴ�.
    public AudioSource audioSourceSFX;

    public AudioClip bgm; // ����� Ŭ���� ���� ����
    bool pause = false;

    void Start()
    {
        // 1)�� ��� GetComponent<T>�� ���� �ش� ��ü�� ������ �ִ� ����� �ҽ� ���� ����
        //own_audioSource = GetComponent<AudioSource>();

        // 3)�� ��� GameObject.Find().GetComponent<T> Ȱ��
        // GameObject.Find()�� ������ ã�� GameObject�� return �ϴ� ����� ������ ����. �� �� ���� GameObject��.
        // GameObject �̱� ������ GetComponet<T>�� �̾� �ۼ������ν� ������Ʈ�� ���� ������Ʈ�� ���� return��.
        // ���� �� ������� AudioSource�� ��.
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        audioSourceBGM.clip = bgm;
        // ����� �ҽ��� Ŭ���� bgm���� ������.
        Debug.Log("1"+audioSourceBGM.clip);

        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        // Resources.Load()�� ���ҽ� �������� ������Ʈ�� ã�� �ε��ϴ� ���
        // �̶� �޾ƿ��� ���� Object�̹Ƿ�, as Ŭ�������� ���� �ش� �����Ͱ� � �������� ǥ�����ָ�
        // �� ���·� �޾ƿ��� ��.

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        // ���ҽ� �ε� �� ��ΰ� �������ִٸ� ������/���ϸ����� �ۼ��մϴ�.
        // ���ҽ� �ε� �� �ۼ��ϴ� �̸����� Ȯ���ڸ�(ex: .json, .avi)�� �ۼ����� �ʽ��ϴ�.

        // UnityWebRequest�� GetAudioClip ��� Ȱ��
        StartCoroutine("GetAudioClip");

        // ����� �ҽ� ��ũ��Ʈ ���
        audioSourceBGM.Play(); // Ŭ���� �����ϴ� ����
        //audioSourceBGM.Pause(); // �Ͻ� ���� ���
        //audioSourceSFX.PlayOneShot(bgm); // Ŭ�� �ϳ��� �Ѽ��� �÷��̸� �����մϴ�.
        //audioSourceBGM.Stop(); // ����� Ŭ�� ��� ����
        //audioSourceBGM.UnPause(); // �Ͻ� ���� ����
        //audioSourceBGM.PlayDelayed(1.0f); // 1�� �ڿ� ���
    }

    IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/Explosion.wav", AudioType.WAV);
        yield return uwr.Send(); // ����

        var new_clip = DownloadHandlerAudioClip.GetContent(uwr);
        // ���� ��θ� ������� �ٿ�ε� ����

        audioSourceBGM.clip = new_clip; // Ŭ�� ���
        Debug.Log("2" + audioSourceBGM.clip);
        audioSourceBGM.Play(); //�÷���

        audioSourceBGM.clip = Resources.Load("Audio/bgm") as AudioClip;
        Debug.Log("3" + audioSourceBGM.clip);
    }
    // �̰ɷ� ȣ���� ��� �۾� ������ �� �����.

    public void OnClickPlay()
    {
        if(pause == false)
        {
            audioSourceBGM.Play();
            Debug.Log("�÷���!");
            pause = true;
        }
        else if(pause == true)
        {
            audioSourceBGM.UnPause();
            Debug.Log("�ٽ� �÷���!");
        }
    }

    public void OnClickPause()
    {
        audioSourceBGM.Pause();
        Debug.Log("����~");
    }

    void Update()
    {
        
    }
}
