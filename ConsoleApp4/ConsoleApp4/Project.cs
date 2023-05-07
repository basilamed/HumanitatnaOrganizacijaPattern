using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
        class Program
        {
                
            // Entry point into console application.
            // Kreiramo listu donatora, svi donatori su razlicitih vrsta.
            // Donatori pozivaju FactoryMethod(), ali u zavisnosti od tipa donatora prave se razlicite vrste donacija.
                
            static void Main()
            {
                // niz donatora
                Donator[] Donators = new Donator[4];

                Donators[0] = new ConcreteDonatorA("Basila");
                Donators[1] = new ConcreteDonatorB("Halida");
                Donators[2] = new ConcreteDonatorC("Dzejlana");
                Donators[3] = new ConcreteDonatorD("Edina");

                float value = 0;
                foreach (Donator Donator in Donators)
                {
                    DateTime currentDate = DateTime.Now;

                        value = value + 1000;
                        Donation donation = Donator.FactoryMethod(value, currentDate);
                        Console.WriteLine("{3} created a {0}. The value of the donation is {1} euros, it was donated on: {2}" , donation.GetType().Name, donation.Value, donation.CreatedDate, Donator.Ime);
                        //zbog razlikovanja datuma u prikazivanju
                        Thread.Sleep(1000);
                }
                // Wait for user
                Console.ReadKey();
                
            }
        }
        
        // 'Donation' abstraktna klasa
            
        // Donacija ima vrednost i datum kreiranja
        abstract class Donation
        {
            public double Value { get; set; }
            public DateTime CreatedDate { get; set; }
        }
            // 'MoneyDonation' klasa
        class MoneyDonation : Donation
        {
            // Konstruktor za donaciju

                public MoneyDonation(float value, DateTime date)
            {
                Value = value;
                CreatedDate = date;
            }
        }
        // 'GoodsDonation' klasa
        class GoodsDonation : Donation
            {
            public GoodsDonation(float value, DateTime date)
            {
                Value = value;
                CreatedDate = date;
            }
        }
        //'ClothesDonation' klasa
        class ClothesDonation : Donation
        {
            public ClothesDonation(float value, DateTime date)
            {
                Value = value;
                CreatedDate = date;
            }
        }
        //'ShoesDonation' klasa
        class ShoesDonation : Donation
        {
            public ShoesDonation(float value, DateTime date)
            {
                Value = value;
                CreatedDate = date;
            }
        }

        // Apstraktna klasa donatora
  
        abstract class Donator
                {
            public string Ime { get; set; }
                public abstract Donation FactoryMethod(float value, DateTime date);
                }
        // Konkretne klase razlicitih vrsta donatora, u zavisnosti od tipa 
        // kreatora kreira se razlicita vrsta donacije iako svi pozivaju istu metodu FactoryMethod()
            
        class ConcreteDonatorA : Donator

        {   
            //konstruktor koji dodeljuje ime donatoru tipa A
            public ConcreteDonatorA(string v)
            {
                Ime = v;
            }
            //kada se pozove factory metoda override-uje je konstruktor za novcanu donaciju,
            //koju moze da uplati samo donator tipa A

            public override Donation FactoryMethod(float value, DateTime date)
                    {
                        return new MoneyDonation(value, date);
                    }

                }
        class ConcreteDonatorB : Donator
        {
            public ConcreteDonatorB(string v)
            {
                Ime = v;
            }
            //kada se pozove factory metoda override-uje je konstruktor za donaciju hrane,
            //koju moze da uplati samo donator tipa B

            public override Donation FactoryMethod(float value, DateTime date)
            {
                return new GoodsDonation(value, date);
            }
        }
        class ConcreteDonatorC : Donator
        {
            public ConcreteDonatorC(string v)
            {
                Ime = v;
            }
            //kada se pozove factory metoda override-uje je konstruktor za donaciju odece,
            //koju moze da uplati samo donator tipa C
                public override Donation FactoryMethod(float value, DateTime date)
            {
                return new ClothesDonation(value, date);
            }
        }
        class ConcreteDonatorD : Donator
        {

            public ConcreteDonatorD(string v)
            {
                Ime = v;
            }
            //kada se pozove factory metoda override-uje je konstruktor za donaciju obuce,
            //koju moze da uplati samo donator tipa D
            public override Donation FactoryMethod(float value, DateTime date)
            {
                return new ShoesDonation(value, date);
            }
        }
}
