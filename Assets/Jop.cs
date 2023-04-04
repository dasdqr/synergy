using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jop : MonoBehaviour
{
    public enum JopName
    {
       warrior, archer  // 직업 추가할 시 적어줘야함 & 인스펙터에서 직업 변경 가능
    }

    public JopName jopname;
    public Sprite icon;
}  