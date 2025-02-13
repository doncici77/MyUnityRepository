using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalkText : ScriptableObject
{
    public List<string> TalkTextList; // 대화를 저장할 리스트
}
