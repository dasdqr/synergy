using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map1 : MonoBehaviour
{
    public Orc orc;
    public Race race;
    public SynergyList synergyList;
    
    // ���� ī��Ʈ
    public int prevOrcCount = 0;
    public int currentOrcCount = 0;
    public int prevElfCount = 0;
    public int currentElfCount = 0;
    public int prevDwarfCount = 0;
    public int currentDwarfCount = 0;

    // ���� ī��Ʈ 
    public int prevWarriorCount = 0;
    public int currentWarriorCount = 0;
    public int prevArcherCount = 0;
    public int currentArcherCount = 0;

    private void Start() // �޼��� ȣ��
    {      
        synergyList = FindObjectOfType<SynergyList>();
        synergyList.UpdateOrcSynergy();
        synergyList.UpdateElfSynergy();
        synergyList.UpdateDwarfSynergy();
        synergyList.UpdateWarriorSynergy();
        synergyList.UpdateArcherSynergy();
    }

    // �浹 ����
    private void OnCollisionEnter(Collision collision)
    {       
        // �浹�� ������Ʈ�� jop, race ������ ��������
        Jop jop = collision.gameObject.GetComponent<Jop>();
        Race race = collision.gameObject.GetComponent<Race>();
    
            if (race != null) // ����
            {
                if (race.racename == Race.RaceName.orc)         // ������ orc�϶�
                {
                    prevOrcCount = currentOrcCount;             // ���� ī��Ʈ�� ���� ī��Ʈ�ֱ�
                    currentOrcCount++;                          // ���� ī��Ʈ ++
                    synergyList.UpdateOrcSynergy();             // SynergyList.cs�� �ִ� UpdateOrcSynergy �޼��� ȣ��
                }
                else if (race.racename == Race.RaceName.elf)    // ���� ����
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

            if (jop != null) // ����
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

    // �浹 ����
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