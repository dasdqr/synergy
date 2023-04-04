using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map1 : MonoBehaviour
{
    public Orc orc;
    public Race race;
    public SynergyList synergyList;
    
    // 종족 카운트
    public int prevOrcCount = 0;
    public int currentOrcCount = 0;
    public int prevElfCount = 0;
    public int currentElfCount = 0;
    public int prevDwarfCount = 0;
    public int currentDwarfCount = 0;

    // 직업 카운트 
    public int prevWarriorCount = 0;
    public int currentWarriorCount = 0;
    public int prevArcherCount = 0;
    public int currentArcherCount = 0;

    private void Start() // 메서드 호출
    {      
        synergyList = FindObjectOfType<SynergyList>();
        synergyList.UpdateOrcSynergy();
        synergyList.UpdateElfSynergy();
        synergyList.UpdateDwarfSynergy();
        synergyList.UpdateWarriorSynergy();
        synergyList.UpdateArcherSynergy();
    }

    // 충돌 감지
    private void OnCollisionEnter(Collision collision)
    {       
        // 충돌한 오브젝트의 jop, race 정보를 가져오기
        Jop jop = collision.gameObject.GetComponent<Jop>();
        Race race = collision.gameObject.GetComponent<Race>();
    
            if (race != null) // 종족
            {
                if (race.racename == Race.RaceName.orc)         // 종족이 orc일때
                {
                    prevOrcCount = currentOrcCount;             // 이전 카운트에 현재 카운트넣기
                    currentOrcCount++;                          // 현재 카운트 ++
                    synergyList.UpdateOrcSynergy();             // SynergyList.cs에 있는 UpdateOrcSynergy 메서드 호출
                }
                else if (race.racename == Race.RaceName.elf)    // 이하 동문
                {
                    prevElfCount = currentElfCount;
                    currentElfCount++;
                    synergyList.UpdateElfSynergy();
                }
                else if (race.racename == Race.RaceName.dwarf)
                {
                    prevDwarfCount = currentDwarfCount;
                    currentDwarfCount++;
                    synergyList.UpdateDwarfSynergy();
                }              
            }

            if (jop != null) // 직업
            {
                if (jop.jopname == Jop.JopName.warrior)
                {
                    prevWarriorCount = currentWarriorCount;
                    currentWarriorCount++;
                    synergyList.UpdateWarriorSynergy();
                }
                else if (jop.jopname == Jop.JopName.archer)
                {
                    prevArcherCount = currentArcherCount;
                    currentArcherCount++;
                    synergyList.UpdateArcherSynergy();
                }              
            }
        }

    // 충돌 해제
    private void OnCollisionExit(Collision collision)
    {
        Jop jop = collision.gameObject.GetComponent<Jop>();
        Race race = collision.gameObject.GetComponent<Race>();

        if (race != null)
        {
            if (race.racename == Race.RaceName.orc)
            {
                prevOrcCount = currentOrcCount;
                currentOrcCount--;
                synergyList.UpdateOrcSynergy();
            }
            else if (race.racename == Race.RaceName.elf)
            {
                prevElfCount = currentElfCount;
                currentElfCount--;
                synergyList.UpdateElfSynergy();
            }
            else if (race.racename == Race.RaceName.dwarf)
            {
                prevDwarfCount = currentDwarfCount;
                currentDwarfCount--;
                synergyList.UpdateDwarfSynergy();
            }            
        }

        if (jop != null)
        {
            if (jop.jopname == Jop.JopName.warrior)
            {
                prevWarriorCount = currentWarriorCount;
                currentWarriorCount--;
                synergyList.UpdateWarriorSynergy();
            }

            else if (jop.jopname == Jop.JopName.archer)
            {
                prevArcherCount = currentArcherCount;
                currentArcherCount--;
                synergyList.UpdateArcherSynergy();
            }           
        }        
    }
}