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
        Map = GameObject.Find("map1").GetComponent<map1>();                     // map1.cs 와 Race.cs 컴포넌트 찾기
        race = GameObject.FindGameObjectWithTag("unit").GetComponent<Race>();
    }

    public void UpdateOrcSynergy() // Orc 시너지
    {
        // 종족: Orc
        if (Map.prevOrcCount < Map.currentOrcCount && Map.currentOrcCount > 1) // 이전 오크 숫자가 현재숫자보다 작고 현재 숫자가 1보다 크면
        {
            race.UpdateSynergyStats(20f, 0f, 0f, 0f, 0f);                      // 체력 20f 증가
            Debug.Log($"체력이 {20f * (Map.currentOrcCount - 1)} 만큼 증가");  // 로그 출력 -1은 orc가 2마리 이상일 때 시너지가 시작되기 때문
        }
        else if (Map.prevOrcCount > Map.currentOrcCount && Map.currentOrcCount >= 1) // 이전 오크 숫자가 현재 숫자보다 크고 현재 숫자가 1보다 크거나 같으면 
        {
            race.UpdateSynergyStats(-20f, 0f, 0f, 0f, 0f);                      // 체력 20f 감소
            Debug.Log($"체력이 {20f * Map.currentOrcCount} 만큼 감소");         // 로그 출력
        }
        race.PrintSynergy();                                                    // Race.cs의 PrintSynergy()메서드 호출  능력치 나타냄
    }
    public void UpdateElfSynergy()                                              // 이하 동문 
    {
        // 종족: elf
        if (Map.prevElfCount < Map.currentElfCount && Map.currentElfCount > 1)
        {
            race.UpdateSynergyStats(0f, 10f, 0f, 0f, 0f);
            Debug.Log($"회피가 {10f * (Map.currentElfCount - 1)} 만큼 증가");
        }
        else if (Map.prevElfCount > Map.currentElfCount && Map.currentElfCount >= 1)
        {
            race.UpdateSynergyStats(0f, -10f, 0f, 0f, 0f);
            Debug.Log($"회피가 {10f * Map.currentElfCount} 만큼 감소");
        }
        race.PrintSynergy();
    }
    public void UpdateDwarfSynergy()
    {
        // 종족: dwarf
        if (Map.prevDwarfCount < Map.currentDwarfCount && Map.currentDwarfCount > 1)
        {
            race.UpdateSynergyStats(0f, 0f, 15f, 0f, 0f);
            Debug.Log($"방어력이 {15f * (Map.currentDwarfCount - 1)} 만큼 증가");
        }
        else if (Map.prevDwarfCount > Map.currentDwarfCount && Map.currentDwarfCount >= 1)
        {
            race.UpdateSynergyStats(0f, 0f, -15f, 0f, 0f);
            Debug.Log($"방어력이 {15f * Map.currentDwarfCount} 만큼 감소");
        }
        race.PrintSynergy();
    }

    public void UpdateWarriorSynergy()
    {
        // 직업: warrior
        if (Map.prevWarriorCount < Map.currentWarriorCount && Map.currentWarriorCount > 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, 12f, 0f);
            Debug.Log($"공격력이 {12f * (Map.currentWarriorCount - 1)} 만큼 증가");
        }
        else if (Map.prevWarriorCount > Map.currentWarriorCount && Map.currentWarriorCount >= 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, -12f, 0f);
            Debug.Log($"공격력이 {12f * Map.currentWarriorCount} 만큼 감소");
        }
        race.PrintSynergy();
    }
    public void UpdateArcherSynergy()
    {
        // 직업: archer
        if (Map.prevArcherCount < Map.currentArcherCount && Map.currentArcherCount > 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, 0f, -0.1f);
            Debug.Log($"공격속도가 {-0.1f * (Map.currentArcherCount - 1)} 만큼 증가");
        }
        else if (Map.prevArcherCount > Map.currentArcherCount && Map.currentArcherCount >= 1)
        {
            race.UpdateSynergyStats(0f, 0f, 0f, 0f, +0.1f);
            Debug.Log($"공격속도가 {0.1f * Map.currentArcherCount} 만큼 감소");
        }
        race.PrintSynergy();
    }
}

// 더 추가하고 싶으면 위에꺼 참고해서 똑같이 해주면 됨


