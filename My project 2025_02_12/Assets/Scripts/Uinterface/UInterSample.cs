using UnityEngine;
using UnityEngine.EventSystems;

// ����Ƽ���� �������ִ� Event, Ipointer

// Ipointer Interface
// Unity�� EventSystems���� �⺻������ �����Ǵ� �������̽��̴�.
// ����ϱ� ���ؼ��� ������ ���� ������ �ʿ��ϴ�.

// Ŭ��, ��ġ, �巡�� ���� �̺�Ʈ�� ������ �� ����մϴ�.

// 1. UI ������Ʈ���� Graphic Raycaster ������Ʈ�� �߰��Ǿ��־�� �Ѵ�.
//    �߰������� Raycast Target�� üũ�� �� ���¿��� �Ѵ�.
// 2. Scene���� Event System ������Ʈ�� �����ؾ� �Ѵ�.
// 3. ������Ʈ�� ���� �۾� �ÿ��� Collider ������Ʈ�� �߰��Ǿ��־�� �Ѵ�.
// 4. Main Camera�� Phisics Raycaster ������Ʈ�� �߰��Ǿ� �־�� �Ѵ�.

public class UInterSample : MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ŭ���� �����߽��ϴ�!");
    }
    // ��� ���
    // 1. �� ����� ����� ������Ʈ�� �����Ѵ�.
    // 2. ���� Event System ������Ʈ�� ��ġ�Ѵ�.
    //    ���࿡ ���� ķ���� ������ �����ߴٸ�, �ڵ����� ��ġ�� �Ǹ�
    //    �ƴ� ����� ���� ���� �����մϴ�.
    // 3. ������Ʈ�� �ݶ��̴��� �����մϴ�.
    // 4. ī�޶� Physics Raycaster ������Ʈ�� �����Ѵ�.


    // IPointerClickHandler
    // �ش� I�� �߰��ϸ� ���콺�� Ŭ�� �Ǵ� ��ġ�� �� �ѹ� ȣ��Ǵ� �̺�Ʈ
    // ������ ���� ��� Ȧ���

    // IPointerDownHandler
    // ������ ������ ȣ��Ǵ� ���콺 Ŭ��/��ġ �̺�Ʈ�̴�.

    // IPointerUpHandler
    // �� ��Ȳ�� ȣ��Ǵ� ���콺 Ŭ��/��ġ �̺�Ʈ�̴�.

    // IBeginDragHandler
    // �巡�� ���Խ� ȣ��Ǵ� �̺�Ʈ

    // IEndDragHandler
    // �巡�װ� ������� �� ȣ��Ǵ� �̺�Ʈ

    // IDropHandler
    // �巡�׸� ������ �� ȣ��Ǵ� �̺�Ʈ

}
