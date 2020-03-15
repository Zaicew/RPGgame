using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame
{
    class Program
    {
        //private static int seed; //why it is there? ;D
        static void Main(string[] args)
        {

            Random rnd = new Random();

            //testing randomnumbers:
            //Console.WriteLine("Random number is: {0}", randomNumber);
            //Console.WriteLine("Random number is: {0}", randomNumber);

            Warrior testWarrior = new Warrior("temporaryWarrior", 10);
            Console.WriteLine(testWarrior.ToString());
            Console.WriteLine();
            Console.WriteLine("_________________________________________________________________");
            Warrior eemptyWarrior = new Warrior();
            Console.WriteLine(eemptyWarrior.ToString());
            Console.WriteLine();
            Console.WriteLine("_________________________________________________________________");
            Sorcer testSorcerer = new Sorcer("temporarySorcerer", 5, 7);
            Console.WriteLine(testSorcerer.ToString());
            Console.WriteLine();
            Console.WriteLine("_________________________________________________________________");
            Sorcer emptySorcerer = new Sorcer();
            Console.WriteLine(emptySorcerer.ToString());
            //Console.WriteLine(test);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************testing changing of hp points********************");
            Console.WriteLine();

            testSorcerer.changeHealth(-rnd.Next(1,100));
            Console.WriteLine(testSorcerer.ToString());
            emptySorcerer.changeHealth(-rnd.Next(1, 100));
            Console.WriteLine(emptySorcerer.ToString());

            eemptyWarrior.changeHealth(-rnd.Next(1, 100));
            Console.WriteLine(eemptyWarrior.ToString());
            testWarrior.changeHealth(-rnd.Next(1, 100));
            Console.WriteLine(testWarrior.ToString());


            Console.WriteLine("**************testing counting power********************");


            Console.WriteLine(testSorcerer.PowerAttack());
            Console.WriteLine(emptySorcerer.PowerAttack());
            Console.WriteLine(eemptyWarrior.PowerAttack());
            Console.WriteLine(testWarrior.PowerAttack());


            Console.WriteLine("**************testing team ********************");



            Sorcer bohater1 = new Sorcer();
            Sorcer bohater2 = new Sorcer("Gargamel", 10, 5);

            Console.WriteLine(bohater1);
            Console.WriteLine(bohater2);

            Warrior bohater3 = new Warrior();
            Warrior bohater4 = new Warrior("Rumcajs", 10);
            bohater3.changeHealth(-90);

            Console.WriteLine(bohater3.ToString());
            Console.WriteLine(bohater4);


            Console.WriteLine("**************\nTworze druzyne\n*************");

            Team druzyna = new Team("Druzyna pierscienia");
            druzyna.Add(bohater1);
            druzyna.Add(bohater2);
            druzyna.Add(bohater3);
            druzyna.Add(bohater4);

            Console.WriteLine(druzyna);





            Console.ReadKey();


        //  konstruktor domyślny ustawiający pola obiektów wg schematu:
        //  Mag: imię = „Xardas”, żywotność = 100%, siła = 1k6, punkty magii = 2k6,
        //  stestowałem losowanie, jest do poprawienia (wymyśleć metodę do losoawniaa wartosci sily itp!! done! :D
        }
    }
}

public interface Character
{
    string Name { get; }
    double Health { get; }
    double PowerAttack();
}

    class Sorcer : Character
    {

    //    konstruktor domyślny ustawiający pola obiektów wg schematu:
    //Wojownik: imię = „Geralt”, żywotność = 100%, siła = 3k6(losowa wartość od 3 do 18, wynik rzutu trzema kostkami),
    //Mag: imię = „Xardas”, żywotność = 100%, siła = 1k6, punkty magii = 2k6,

    private int _strength, _magicPoints;
    public string Name { get; private set; }
    public double Health{ get; private set; }
    
    Random rnd = new Random();



    public Sorcer()
    {
        Name = "Xardas";
        this.Health = 100;
        _strength = rnd.Next(1, 6);
        _magicPoints = rnd.Next(1, 6) + rnd.Next(1, 6);
    }

    public Sorcer(string name, int strength, int magicPoints)
        {
            Name = name;
            Health = 100;
            _strength = strength;
            _magicPoints = magicPoints;
    }

    public double changeHealth(int x)
    {
        Health += x;
        if (Health <= 0) Health = 0;
        if (Health > 100) Health = 100;
        return Health;
    }

    public double PowerAttack ()
    {
        return (_magicPoints + _strength) * Health;
    }

    public override string ToString()
    {
            return "Name: " + Name + ", strength points: " + _strength + ", health: " + Health + ", magic points: " + _magicPoints;
        }

    }

    class Warrior : Character
    {

    Random rnd = new Random();
    public string Name { get; set; }
    public double Health { get;  set; }
    private int _strength;


//konstruktor domyślny ustawiający pola obiektów wg schematu:
//Wojownik: imię = „Geralt”, żywotność = 100%, siła = 3k6(losowa wartość od 3 do 18, wynik rzutu trzema kostkami),
//Mag: imię = „Xardas”, żywotność = 100%, siła = 1k6, punkty magii = 2k6,
    public Warrior()
    {
        
        Name = "Geralt";
        Health = 100;
        _strength = rnd.Next(1, 6) + rnd.Next(1, 6) + rnd.Next(1, 6);
    }
         public Warrior(string name, int strength)
        {
            Name = name;
            Health = 100;
            _strength = strength;
        }

    public double changeHealth(int x)
    {
        Health += x;
        if (Health <= 0) Health = 0;
        if (Health > 100) Health = 100;
        return Health;
    }

    public double PowerAttack()
    {
        return _strength * Health;
    }
    //     int Strength
    //{
    //    get { return strength; }
    //    set { }
    //}
    public override string ToString()
    {
        return "Name: " + Name + ", health: " + Health + ", strength points: " + _strength;
    }


}

class Team
{
    private string _name;
    private List<Character> _list;

    public Team(string name)
    {
        _name = name;
        _list = new List<Character>();
    }

    public void Add(Character character)
    {
        _list.Add(character);
    }

    public double AmountOfPower()
    {
        double power = 0;
        foreach (var character in _list)
        {
            power = power + character.PowerAttack();
        }

        return power;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Team: " + _name);
        sb.AppendLine("Amount of power: " + AmountOfPower());
        for (int i = 0; i < _list.Count; i++)
        {
            sb.AppendLine(_list[i].ToString());
        }
        return sb.ToString();
    }
}


//dodaje cos zeby zobaczyc