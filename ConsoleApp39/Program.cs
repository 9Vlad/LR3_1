using System;

class Parent
{
    protected int pole1;

    public Parent(int pole1)
    {
        this.pole1 = pole1;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Кількість функцій: {pole1}");
    }

    public virtual double Metod()
    {
        return pole1 * 100;
    }
}

class Child1 : Parent
{
    private int pole2;

    public Child1(int pole1, int pole2) : base(pole1)
    {
        this.pole2 = pole2;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Рік виробництва: {pole2}");
        Console.WriteLine($"Мобільний: {Metod()}");
    }

    public override double Metod()
    {
        int currentYear = DateTime.Now.Year;
        if (currentYear - pole2 < 2)
        {
            return base.Metod() * 1.20;
        }
        else if (currentYear - pole2 > 3)
        {
            return base.Metod() * 0.40;
        }
        return base.Metod();
    }
}

class Child2 : Parent
{
    private bool pole3;

    public Child2(int pole1, bool pole3) : base(pole1)
    {
        this.pole3 = pole3;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Мобільність: {(pole3 ? "переносний" : "не переносний")}");
        Console.WriteLine($"Стационарний: {Metod()}");
    }

    public override double Metod()
    {
        if (pole3)
        {
            return base.Metod() * 1.01;
        }
        else
        {
            return base.Metod() * 0.97;
        }
    }
}

class Program
{
    static void Main()
    {
        Parent parentPhone = new Parent(50);
        Child1 mobilePhone = new Child1(50, 2020);
        Child1 oldMobilePhone = new Child1(50, 2010);
        Child2 portablePhone = new Child2(20, true);
        Child2 nonPortablePhone = new Child2(20, false);

        parentPhone.Print();
        Console.WriteLine($"Телефон: {parentPhone.Metod()}");
        Console.WriteLine();

        mobilePhone.Print();
        Console.WriteLine();
        oldMobilePhone.Print();
        Console.WriteLine();
        portablePhone.Print();
        Console.WriteLine();
        nonPortablePhone.Print();
    }
}