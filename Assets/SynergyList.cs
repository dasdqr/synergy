using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyList : MonoBehaviour
{
    private map1 Map;
    private Race race;
    private Orc orc;

    private void Start()
    {
        Map = GameObject.Find("map1").GetComponent<map1>();                     // map1.cs �� Race.cs ������Ʈ ã��
        race = GameObject.FindGameObjectWithTag("unit").GetComponent<Race>();
    }

    public void UpdateOrcSynergy() // Orc �ó���
    {
        // ����: Orc
        if (Map.prevOrcCount < Map.currentOrcCount && Map.currentOrcCount > 1) // ���� ��ũ ���ڰ� ������ں��� �۰� ���� ���ڰ� 1���� ũ��
        {
            race.UpdateSynergyStats(20f, 0f, 0f, 0f, 0f);                      // ü�� 20f ����
            Debug.Log($"ü���� {20f * (Map.currentOrcCount - 1)} ��ŭ ����");  // �α� ��� -1�� orc�� 2���� �̻��� �� �ó����� ���۵Ǳ� ����
        }
        else if (Map.prevOrcCount > Map.currentOrcCount && Map.currentOrcCount >= 1) // ���� ��ũ ���ڰ� ���� ���ں��� ũ�� ���� ���ڰ� 1���� ũ�ų� ������ 
        {
            race.UpdateSynergyStats(-20f, 0f, 0f, 0f, 0f);                      // ü�� 20f ����
            Debug.Log($"ü���� {20f * Map.currentOrcCount} ��ŭ ����");         // �α� ���
        }
        race.PrintSynergy();                                                    // Race.cs�� PrintSynergy()�޼��� ȣ��  �ɷ�ġ ��Ÿ��
    }
    public void UpdateElfSynergy()                                              // ���� ���� 
    {
        // ����: elf
        if (Map.prevElfCount < Map.currentElfCount && Map.currentElfCount > 1)
        {
            race.UpdateSynergyStats(0f, 10f, 0f, 0f, 0f);
            Debug.Log($"ȸ�ǰ� {10f * (Map.currentElfCount - 1)} ��ŭ ����");
        }
        else if (Map.prevElfCount > Map.currentElfCount && Map.currentElfCount >= 1)
        {
            race.UpdateSynergyStats(0f, -10f, 0f, 0f, 0f);
            Debug.Log($"ȸ�ǰ� {10f * Map.currentElfCount} ��ŭ ����");
        }
        race.PrintSynergy();
    }
    public void UpdateDwarfSynergy()
    {
        // ����: dwarf
        if (Map.prevDwarfCount < Map.currentDwarfCount && Map.currentDwarfCount > 1)
        {
            race.UpdateSynergyStats(0f, 0f, 15f, 0f, 0f);
            Debug.Log($"������ {15f * (Map.currentDwarfCount - 1)} ��ŭ ����");
        }
        else if (Map.prevDwarfCount > Map.currentDwarfCount && Map.currentDwarfCount >= 1)
        {
            race.UpdateSynergyStats(0f, 0f, -15f, 0f, 0f);
            Debug.Log($"������ {15f * Map.currentDwarfCount} ��ŭ ����");
        }
        race.PrintSynergy();
    }

    public void UpdateWarriorSynergy()
    {
        // ����: warrior
        if (Map.prevWarriorCount < Map.currentWarriorCount && Map.currentWarriorCount > 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, 12f, 0f);
            Debug.Log($"���ݷ��� {12f * (Map.currentWarriorCount - 1)} ��ŭ ����");
        }
        else if (Map.prevWarriorCount > Map.currentWarriorCount && Map.currentWarriorCount >= 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, -12f, 0f);
            Debug.Log($"���ݷ��� {12f * Map.currentWarriorCount} ��ŭ ����");
        }
        race.PrintSynergy();
    }
    public void UpdateArcherSynergy()
    {
        // ����: archer
        if (Map.prevArcherCount < Map.currentArcherCount && Map.currentArcherCount > 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, 0f, -0.1f);
            Debug.Log($"���ݼӵ��� {-0.1f * (Map.currentArcherCount - 1)} ��ŭ ����");
        }
        else if (Map.prevArcherCount > Map.currentArcherCount && Map.currentArcherCount >= 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, 0f, +0.1f);
            Debug.Log($"���ݼӵ��� {0.1f * Map.currentArcherCount} ��ŭ ����");
        }
        race.PrintSynergy();
    }
}

// �� �߰��ϰ� ������ ������ �����ؼ� �Ȱ��� ���ָ� ��


