using System;

public class Fraction
{
    public int n;
    public int m;
    
    public Fraction(int n, int m)
    {
        this.n = n;
        this.m = m;
    }

    public Fraction Sum(Fraction one, Fraction two)
    {
        Fraction three = new Fraction();
        int n = one.n * two.m + one.m * two.n;
        int m = one.m * two.m;

        three.n = n;
        three.m = m;

        return three;
    }

}
