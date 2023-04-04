using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Race : MonoBehaviour
{
    // �⺻ �ɷ�ġ ����
    public float health;
    public float evasion;
    public float armor;
    public float damage;
    public float attackspeed;
    
    // �ó���ȿ�� �ɷ�ġ ����
    public float synergyhealth;
    public float synergyevasion;
    public float synergyarmor;
    public float synergydamage;
    public float synergyattackspeed;

    // �⺻ �ɷ�ġ ����
    public void UpdateStats(float health, float evasion, float armor, float damage, float attackspeed)
    {
        this.health += health;
        this.evasion += evasion;
        this.armor += armor;
        this.damage += damage;
        this.attackspeed += attackspeed;
    }

    // �ɷ�ġ �迭�� ��ȯ 
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

    // SynergyList.cs���� �ó���ȿ�� �ɷ�ġ�� ����
    public void UpdateSynergyStats(float synergyhealth, float synergyevasion, float synergyarmor, float synergydamage, float synergyattackspeed)
    {
        this.synergyhealth += synergyhealth;
        this.synergyevasion += synergyevasion;
        this.synergyarmor += synergyarmor;
        this.synergydamage += synergydamage;
        this.synergyattackspeed += synergyattackspeed;
    }
    // �迭�� ��ȯ
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
    // �⺻ �ɷ�ġ + �ó���ȿ�� �� ���
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

       
        Debug.Log("�ó���ȿ��:" + synergyStats[0] + ", " + synergyStats[1] + ", " + synergyStats[2] + ", " + synergyStats[3] + ", " + synergyStats[4]);
        Debug.Log("��ũ ����:" + (orcwarriorStats[0] + synergyStats[0]) + ", " + (orcwarriorStats[1] + synergyStats[1]) + " , " + (orcwarriorStats[2] + synergyStats[2]) + ", " + (orcwarriorStats[3] + synergyStats[3]) + ", " + (orcwarriorStats[4] + synergyStats[4]));
        Debug.Log("��ũ �ü�:" + (orcarcherStats[0] + synergyStats[0]) + ", " + (orcarcherStats[1] + synergyStats[1]) + " , " + (orcarcherStats[2] + synergyStats[2]) + ", " + (orcarcherStats[3] + synergyStats[3]) + ", " + (orcarcherStats[4] + synergyStats[4]));
        Debug.Log("���� ����:" + (elfwarriorStats[0] + synergyStats[0]) + ", " + (elfwarriorStats[1] + synergyStats[1]) + " , " + (elfwarriorStats[2] + synergyStats[2]) + ", " + (elfwarriorStats[3] + synergyStats[3]) + ", " + (elfwarriorStats[4] + synergyStats[4]));
        Debug.Log("���� �ü�:" + (elfarcherStats[0] + synergyStats[0]) + ", " + (elfarcherStats[1] + synergyStats[1]) + " , " + (elfarcherStats[2] + synergyStats[2]) + ", " + (elfarcherStats[3] + synergyStats[3]) + ", " + (elfarcherStats[4] + synergyStats[4]));
        Debug.Log("����� ����:" + (dwarfwarriorStats[0] + synergyStats[0]) + ", " + (dwarfwarriorStats[1] + synergyStats[1]) + " , " + (dwarfwarriorStats[2] + synergyStats[2]) + ", " + (dwarfwarriorStats[3] + synergyStats[3]) + ", " + (dwarfwarriorStats[4] + synergyStats[4]));
        Debug.Log("����� �ü�:" + (dwarfarcherStats[0] + synergyStats[0]) + ", " + (dwarfarcherStats[1] + synergyStats[1]) + " , " + (dwarfarcherStats[2] + synergyStats[2]) + ", " + (dwarfarcherStats[3] + synergyStats[3]) + ", " + (dwarfarcherStats[4] + synergyStats[4]));
    }
    public enum RaceName
    {
        orc, elf, dwarf // ���� �߰��� �� ��������� & �ν����Ϳ��� ���� ���� ����
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
        jop.jopname = Jop.JopName.warrior; // ������ �����մϴ�.

        orcwarriorStats = new float[] { 150f, 0f, 30f, 10f, 1f };  // ���� �ɷ�ġ ���� ���� �ؿ� ���� �ɷ�ġ�� ���� �ٲ����
        orcarcherStats = new float[] { 100f, 30f, 10f, 10f, 1f };  // �ü� �ɷ�ġ ���� ���� ��������

        if (jop.jopname == Jop.JopName.warrior)     // ������ ��  
        {
            UpdateStats(150f, 0f, 30f ,10f, 1f);                     // ���� �ɷ�ġ ���� ����
        }
        else if (jop.jopname == Jop.JopName.archer) // �ü��� ��
        {
            UpdateStats(100f, 30f, 10f, 10f, 1f);                    // �ü� �ɷ�ġ ���� ����
        }
    }

    public float[] GetOrcWarriorStats()
    {
        jop.jopname = Jop.JopName.warrior; // ���� ����

        if (jop.jopname == Jop.JopName.warrior)
        {
            return orcwarriorStats;
        }
        else
        {
            // ���� ������ ���簡 �ƴ϶�� �� �迭�� ��ȯ
            return new float[5];
        }
    }

    public float[] GetOrcArcherStats()
    {
        jop.jopname = Jop.JopName.archer; // ���� ����

        if (jop.jopname == Jop.JopName.archer)
        {
            return orcarcherStats;
        }
        else
        {
            // ���� ������ �ü��� �ƴ϶�� �� �迭�� ��ȯ.
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
// ������ ó�� ������ ���� �Ȱ��� �߰��ϰ� �̸�, �ɷ�ġ�� �ٲٸ�� 
// 68���� PrintSynergy �� �߰������ �ɷ�ġ�� ��µ�