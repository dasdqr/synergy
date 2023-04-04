using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Race : MonoBehaviour
{
    // 기본 능력치 변수
    public float health;
    public float evasion;
    public float armor;
    public float damage;
    public float attackspeed;
    
    // 시너지효과 능력치 변수
    public float synergyhealth;
    public float synergyevasion;
    public float synergyarmor;
    public float synergydamage;
    public float synergyattackspeed;

    // 기본 능력치 설정
    public void UpdateStats(float health, float evasion, float armor, float damage, float attackspeed)
    {
        this.health += health;
        this.evasion += evasion;
        this.armor += armor;
        this.damage += damage;
        this.attackspeed += attackspeed;
    }

    // 능력치 배열로 반환 
    public float[] GetStats()
    {
        float[] stats = new float[5];
        stats[0] = health;
        stats[1] = evasion;
        stats[2] = armor;
        stats[3] = damage;
        stats[4] = attackspeed;

        return stats;
    }

    // SynergyList.cs에서 시너지효과 능력치를 저장
    public void UpdateSynergyStats(float synergyhealth, float synergyevasion, float synergyarmor, float synergydamage, float synergyattackspeed)
    {
        this.synergyhealth += synergyhealth;
        this.synergyevasion += synergyevasion;
        this.synergyarmor += synergyarmor;
        this.synergydamage += synergydamage;
        this.synergyattackspeed += synergyattackspeed;
    }
    // 배열로 반환
    public float[] GetSynergy()
    {
        float[] result = new float[5];
        result[0] = synergyhealth;
        result[1] = synergyevasion;
        result[2] = synergyarmor;
        result[3] = synergydamage;
        result[4] = synergyattackspeed;

        return result;
    }
    // 기본 능력치 + 시너지효과 및 출력
    public void PrintSynergy()
    {
        Orc orc = new Orc();
        Elf elf = new Elf();
        Dwarf dwarf = new Dwarf();
        float[] synergyStats = GetSynergy();
        float[] orcwarriorStats = orc.GetOrcWarriorStats();
        float[] orcarcherStats = orc.GetOrcArcherStats();
        float[] elfwarriorStats = elf.GetElfWarriorStats();
        float[] elfarcherStats = elf.GetElfArcherStats();
        float[] dwarfwarriorStats = dwarf.GetDwarfWarriorStats();
        float[] dwarfarcherStats = dwarf.GetDwarfArcherStats();

       
        Debug.Log("시너지효과:" + synergyStats[0] + ", " + synergyStats[1] + ", " + synergyStats[2] + ", " + synergyStats[3] + ", " + synergyStats[4]);
        Debug.Log("오크 전사:" + (orcwarriorStats[0] + synergyStats[0]) + ", " + (orcwarriorStats[1] + synergyStats[1]) + " , " + (orcwarriorStats[2] + synergyStats[2]) + ", " + (orcwarriorStats[3] + synergyStats[3]) + ", " + (orcwarriorStats[4] + synergyStats[4]));
        Debug.Log("오크 궁수:" + (orcarcherStats[0] + synergyStats[0]) + ", " + (orcarcherStats[1] + synergyStats[1]) + " , " + (orcarcherStats[2] + synergyStats[2]) + ", " + (orcarcherStats[3] + synergyStats[3]) + ", " + (orcarcherStats[4] + synergyStats[4]));
        Debug.Log("엘프 전사:" + (elfwarriorStats[0] + synergyStats[0]) + ", " + (elfwarriorStats[1] + synergyStats[1]) + " , " + (elfwarriorStats[2] + synergyStats[2]) + ", " + (elfwarriorStats[3] + synergyStats[3]) + ", " + (elfwarriorStats[4] + synergyStats[4]));
        Debug.Log("엘프 궁수:" + (elfarcherStats[0] + synergyStats[0]) + ", " + (elfarcherStats[1] + synergyStats[1]) + " , " + (elfarcherStats[2] + synergyStats[2]) + ", " + (elfarcherStats[3] + synergyStats[3]) + ", " + (elfarcherStats[4] + synergyStats[4]));
        Debug.Log("드워프 전사:" + (dwarfwarriorStats[0] + synergyStats[0]) + ", " + (dwarfwarriorStats[1] + synergyStats[1]) + " , " + (dwarfwarriorStats[2] + synergyStats[2]) + ", " + (dwarfwarriorStats[3] + synergyStats[3]) + ", " + (dwarfwarriorStats[4] + synergyStats[4]));
        Debug.Log("드워프 궁수:" + (dwarfarcherStats[0] + synergyStats[0]) + ", " + (dwarfarcherStats[1] + synergyStats[1]) + " , " + (dwarfarcherStats[2] + synergyStats[2]) + ", " + (dwarfarcherStats[3] + synergyStats[3]) + ", " + (dwarfarcherStats[4] + synergyStats[4]));
    }
    public enum RaceName
    {
        orc, elf, dwarf // 종족 추가할 시 적어줘야함 & 인스펙터에서 종족 변경 가능
    }
    public RaceName racename;
    public Sprite icon;
}

public class Orc : Race
{
    private Jop jop;
    private float[] orcwarriorStats;
    private float[] orcarcherStats;

    public Orc() : base()
    {
        jop = new Jop();
        jop.jopname = Jop.JopName.warrior; // 직업을 설정합니다.

        orcwarriorStats = new float[] { 150f, 0f, 30f, 10f, 1f };  // 전사 능력치 수정 가능 밑에 전사 능력치랑 같이 바꿔야함
        orcarcherStats = new float[] { 100f, 30f, 10f, 10f, 1f };  // 궁수 능력치 수정 가능 마찬가지

        if (jop.jopname == Jop.JopName.warrior)     // 전사일 때  
        {
            UpdateStats(150f, 0f, 30f ,10f, 1f);                     // 전사 능력치 수정 가능
        }
        else if (jop.jopname == Jop.JopName.archer) // 궁수일 때
        {
            UpdateStats(100f, 30f, 10f, 10f, 1f);                    // 궁수 능력치 수정 가능
        }
    }

    public float[] GetOrcWarriorStats()
    {
        jop.jopname = Jop.JopName.warrior; // 직업 설정

        if (jop.jopname == Jop.JopName.warrior)
        {
            return orcwarriorStats;
        }
        else
        {
            // 만약 직업이 전사가 아니라면 빈 배열을 반환
            return new float[5];
        }
    }

    public float[] GetOrcArcherStats()
    {
        jop.jopname = Jop.JopName.archer; // 직업 설정

        if (jop.jopname == Jop.JopName.archer)
        {
            return orcarcherStats;
        }
        else
        {
            // 만약 직업이 궁수가 아니라면 빈 배열을 반환.
            return new float[5];
        }
    }
}

public class Elf : Race
{
    private Jop jop;
    private float[] elfwarriorStats;
    private float[] elfarcherStats;

    public Elf() : base()
    {
        jop = new Jop();
        jop.jopname = Jop.JopName.warrior;

        elfwarriorStats = new float[] { 110f, 20f, 10f, 10f, 1f };
        elfarcherStats = new float[] { 90f, 30f, 10f, 10f, 1f };

        if (jop.jopname == Jop.JopName.warrior)
        {
            UpdateStats(110f, 20f, 10f, 10f, 1f);
        }
        else if (jop.jopname == Jop.JopName.archer)
        {
            UpdateStats(90f, 30f, 10f, 10f, 1f);
        }
    }

    public float[] GetElfWarriorStats()
    {
        jop.jopname = Jop.JopName.warrior;

        if (jop.jopname == Jop.JopName.warrior)
        {
            return elfwarriorStats;
        }
        else
        {
            return new float[5];
        }
    }

    public float[] GetElfArcherStats()
    {
        jop.jopname = Jop.JopName.archer;

        if (jop.jopname == Jop.JopName.archer)
        {
            return elfarcherStats;
        }
        else
        {
            return new float[5];
        }
    }
}
    public class Dwarf : Race
    {
        private Jop jop;
        private float[] dwarfwarriorStats;
        private float[] dwarfarcherStats;

        public Dwarf() : base()
        {
            jop = new Jop();
            jop.jopname = Jop.JopName.warrior; 

            dwarfwarriorStats = new float[] { 100f, 0f, 50f, 10f, 1f };
            dwarfarcherStats = new float[] { 90f, 30f, 10f, 5f, 0.5f };

            if (jop.jopname == Jop.JopName.warrior)
            {
                UpdateStats(100f, 0f, 50f, 10f, 1f);
            }
            else if (jop.jopname == Jop.JopName.archer)
            {
                UpdateStats(90f, 10f, 50f, 10f, 0.5f);
            }
        }

        public float[] GetDwarfWarriorStats()
        {
            jop.jopname = Jop.JopName.warrior; 

            if (jop.jopname == Jop.JopName.warrior)
            {
                return dwarfwarriorStats;
            }
            else
            {
                return new float[5];
            }
        }

        public float[] GetDwarfArcherStats()
        {
            jop.jopname = Jop.JopName.archer;

            if (jop.jopname == Jop.JopName.archer)
            {
                return dwarfarcherStats;
            }
            else
            {
                return new float[5];
            }
        }
    }
// 위에꺼 처럼 종족과 직업 똑같이 추가하고 이름, 능력치만 바꾸면됨 
// 68번줄 PrintSynergy 에 추가해줘야 능력치가 출력됨