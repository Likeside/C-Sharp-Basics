using System;

public class Fraction
{
    //Зиновьев Александр Алексеевич

    //В классе два свойства - числитель и знаменатель. 
    public int n;
    public int m;

    //Описываем конструктор класса, принимающий два целых числа и присваивающий их числителю и знаменателю, если второй не равен нулю
    public Fraction(int n, int m)
    {
        if (m != 0)
        {
            this.n = n;
            this.m = m;
        }
        else
        {
            throw new ArgumentException("Знаменатель не может быть равен 0");
        }
    
    }

    /*Операции по порядку - сложение, вычитание, умножение, деление. Все методы принимают два объекта типа "Fraction" и
    возвращают третий объект того же типа */
    public static Fraction Sum(Fraction one, Fraction two)
    {
        Fraction three = new Fraction(1,1);
        int n = one.n * two.m + one.m * two.n;
        int m = one.m * two.m;

        three.n = n;
        three.m = m;

        return three;
    }

    public static Fraction Subtract(Fraction one, Fraction two)
    {
        Fraction three = new Fraction(1, 1);
        int n = one.n * two.m - one.m * two.n;
        int m = one.m * two.m;

        three.n = n;
        three.m = m;

        return three;
    }

    public static Fraction Multiple(Fraction one, Fraction two)
    {
        Fraction three = new Fraction(1, 1);
        int n = one.n * two.n;
        int m = one.m * two.m;

        three.n = n;
        three.m = m;

        return three;
    }

    public static Fraction Divide(Fraction one, Fraction two)
    {
        Fraction three = new Fraction(1, 1);
        int n = one.n * two.m;
        int m = one.m * two.n;

        three.n = n;
        three.m = m;

        return three;
    }

}
