using System;

public class Uziv
{

    public String Geroi(String x)
    {
        return ("Zdravim te, " + x);
    }

    public String Enemy(String x)
    {
        return ("Tvuj nepritel je: " + x + "\n ###############");
    }
}

public class Interface
{

    public int Kostka(int x)
    {
        Random random = new Random();
        int kostka = random.Next(x);
        return kostka;
    }

    public void HodHrac()
    {
        Console.WriteLine("Hrac hazi kostkou.");
    }

    public void HodEnemy()
    {
        Console.WriteLine("Nepritel hazi kostkou.");
    }

}


public class Program
{
    public static void Main(String[] args)
    {

        Uziv user = new Uziv();
        Interface inter = new Interface();

        int hracHP = 50;
        int enemyHP = 90;

        int hracDMGbonus = 0;
        int enemyDMGbonus = 0;

        int hracHPbonus = 0;
        int enemyHPbonus = 0;

        int pocetSten = 20;

        int hodNep = inter.Kostka(4);
        String[] enemies = new String[] { "Minotaurus", "Devil", "Orc", "Goblin" };

        Console.WriteLine(user.Geroi("Derek"));
        Console.WriteLine(user.Enemy(enemies[hodNep]));

        if (hodNep == 0) enemyHP = 90;
        else if (hodNep == 1) enemyHP = 120;
        else if (hodNep == 2) enemyHP = 60;
        else if (hodNep == 3) enemyHP = 30;

        System.Threading.Thread.Sleep(500);
        int bonusHrac = inter.Kostka(3);

        if (bonusHrac == 0)
        {
            Console.WriteLine("Hrac neziskava zadny bonus!\n XXXXXXX\n");
        }
        else if (bonusHrac == 1)
        {
            Console.WriteLine("Hrac ziskava mec! + 15 dmg!\n !!!!!!!!\n");
            hracDMGbonus = 15;
        }
        else if (bonusHrac == 2)
        {
            Console.WriteLine("Hrac ziskava brneni! + 30 HP!\n ++++++++\n");
            hracHPbonus = 30;
        }

        System.Threading.Thread.Sleep(20);
        int bonusEnemy = inter.Kostka(3);

        if (bonusEnemy == 0)
        {
            Console.WriteLine("Nepritel neziskal bonus!\n XXXXXXX\n");
        }
        else if (bonusEnemy == 1)
        {
            Console.WriteLine("Nepritel je obklopen plameny! + 15 dmg!\n !!!!!!!!\n");
            enemyDMGbonus = 15;
        }
        else if (bonusEnemy == 2)
        {
            Console.WriteLine("Nepritel ma kamennou kuzi! + 30 HP!\n ++++++++\n");
            enemyHPbonus = 30;
        }


        hracHP = hracHP + hracHPbonus;
        enemyHP = enemyHP + enemyHPbonus;


        int enemyHPp = enemyHP;
        int hracHPp = hracHP;

        /*int strana = inter.Zacatek(2);

        if (strana == 0){
          Console.WriteLine("Zacina hrac! \n _!-!_!-!_!-!_!-!_\n\n");
        }
        else if (strana == 1){
          Console.WriteLine("Zacina nepritel! \n *_*_*_*_*_*_*_*\n\n");
        }*/


        while (enemyHP > 0 && hracHP > 0)
        {

            int a = inter.Kostka(pocetSten);

            //Hrac:
            inter.HodHrac();
            int hracUtok = a + hracDMGbonus;
            Console.WriteLine("Hrac hodil " + a);
            if (a > 0)
            {
                Console.WriteLine("*HIT*");
            }
            else
            {
                Console.WriteLine("*MISSED*");
                hracUtok = 0;
            }


            Console.WriteLine("Hrac utoci za " + hracUtok + " dmg!");
            enemyHP = enemyHP - hracUtok;
            Console.WriteLine("Nepritel ma " + enemyHP + "/" + enemyHPp + " HP. \n ----------------\n");
            System.Threading.Thread.Sleep(1500);

            if (enemyHP <= 0)
            {
                break;
            }

            int b = inter.Kostka(pocetSten);

            //Enemy:      
            inter.HodEnemy();
            int enemyUtok = b + enemyDMGbonus;
            Console.WriteLine("Nepritel hodil " + b);
            if (b > 0)
            {
                Console.WriteLine("*HIT*");
            }
            else
            {
                Console.WriteLine("*MISSED*");
                enemyUtok = 0;
            }

            Console.WriteLine("Nepritel utoci za " + enemyUtok + " dmg!");
            hracHP = hracHP - enemyUtok;
            Console.WriteLine("Hrac ma " + hracHP + "/" + hracHPp + " HP. \n ----------------\n");
            System.Threading.Thread.Sleep(1500);

            if (hracHP <= 0)
            {
                break;
            }
        }

        if (enemyHP <= 0)
        {
            Console.WriteLine("Hrac vyhral!");
        }
        if (hracHP <= 0)
        {
            Console.WriteLine("Nepritel vyhral!");
        }

        Console.ReadKey();
    }
}
