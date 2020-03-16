using System;

namespace FractCshp
{
    public class Fraction : IComparable
    {
        public long denominator
        {
            get;
            set
            {
                if (denom == 0)
                {
                    throw new DivideByZeroException
                        ("fixed an attempt to divide by zero");
                }
                denominator = denom;
                Reduce();
            }
        }

        public long nomerator
        {
            get;
            set
            {
                SetNom(nom, true);
            }
        }
        protected long denominator;
        protected static long NOD(long a, long b)
        {
            while (b != 0)
            {
                long temp;
                temp = b;
                b = a % b;
                a = temp;

            }
            return a;
        }
        protected void Reduce()
        {
            if (denominator < 0)
            {
                nomerator = -nomerator;
                denominator = -denominator;
            }
            long res = NOD(Math.Abs(nomerator), Math.Abs(denominator));
            denominator /= res;
            nomerator /= res;
        }
        protected void SetNom(long nom, bool ShouldReduce)
        {
            if (ShouldReduce)
            {
                nomerator = nom;
                Reduce();
            }
            else
                nomerator = nom;
        }
        public long GetNomerator()
        {
            return nomerator;
        }
     
        private void SetNomerator(long nom)
        {
            SetNom(nom, true);
        }
      
        public Fraction()
        {
            SetNom(0, false);
            SetDenominator(1);
        }
        public Fraction(long nomerator, long denominator)
        {
            if (nomerator == 0 && denominator != 0)
            {
                SetNom(0, false);
                SetDenominator(1);
            }

            SetNom(nomerator, false);
            SetDenominator(denominator);
        }
        public static Fraction operator -(Fraction f1)
        {
            Fraction t = new Fraction(-f1.nomerator, f1.denominator);
            return t;
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            long nom;
            long denom;
            denom = f1.denominator * f2.denominator;
            nom = f1.nomerator * f2.denominator + f2.nomerator * f1.denominator;
            Fraction t = new Fraction(nom, denom);
            return t;
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long nom;
            long denom;
            denom = f1.denominator * f2.denominator;
            nom = f1.nomerator * f2.denominator - f2.nomerator * f1.denominator;
            Fraction t = new Fraction(nom, denom);
            return t;
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction t = new Fraction(f1.nomerator * f2.nomerator, f1.denominator * f2.denominator);
            return t;
        }
        public static Fraction operator /(Fraction f1,
  Fraction f2)
        {
            Fraction t = new Fraction(f1.nomerator * f2.denominator, f1.denominator * f2.nomerator);
            return t;
        }
        public static Fraction operator +(Fraction f1, long a)
        {
            long nom;
            long denom;
            denom = f1.denominator;
            nom = f1.nomerator + a * f1.denominator;
            Fraction t = new Fraction(nom, denom);
            return t;
        }
        public static Fraction operator -(Fraction f1, long a)
        {
            long nom;
            long denom;
            denom = f1.denominator;
            nom = f1.nomerator - a * f1.denominator;
            Fraction t = new Fraction(nom, denom);
            return t;
        }
        public static Fraction operator /(Fraction f1, long a)
        {
            Fraction t = new Fraction(f1.nomerator, f1.denominator * a);
            return t;
        }
        public static Fraction operator *(Fraction f1, long a)
        {
            Fraction t = new Fraction(f1.nomerator * a, f1.denominator);
            return t;
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Equals(f2);
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !f1.Equals(f2);
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.CompareTo(f2) == 1;
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.CompareTo(f2) == -1;
        }
        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return f1.CompareTo(f2) >= 0;
        }
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return f1.CompareTo(f2) <= 0;
        }
        public double ToDouble()
        {
            return this.nomerator * 1.0 / this.denominator * 1.0;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            if (!(obj is Fraction))
                throw new ArgumentException
                ("Argument should be Temperature type");
            return (this.ToDouble() == (obj as Fraction).ToDouble());
        }
        public override int GetHashCode()
        {
            return this.ToDouble().GetHashCode();
        }
        public override string ToString()
        {
            return (this.nomerator + "/" + this.denominator);
        }
        public static Fraction Parse(string s)
        {
            if (s == null) throw new ArgumentNullException();
            if (s.Length < 3)
            {
                throw new FormatException
                ("Parameter length is too small");
            }
            int i = 0;
            while (true)
            {
                if (Char.IsDigit(s[i]))
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            if (!(s[i].Equals('/')))
            {
                throw new FormatException
                ("Parameter doesn't terminate by fraction mode");
            }

            long nom = Int32.Parse(s.Substring(0, i));
            long denom = Int32.Parse(s.Substring(i + 1));
            Fraction f = new Fraction(nom, denom);
            return f;
        }
        public int CompareTo(object obj)
        {
            if ((obj is double))
            {
                double d = (double)obj;
                if (this.ToDouble() < d)
                    return -1;
                if (this.ToDouble() > d)
                    return 1;
                return 0;
            }
            if (!(obj is Fraction))
            {
                throw new ArgumentException("object is not a Fraction");
            }
            Fraction otherFraction = (Fraction)obj;
            if (this.ToDouble() < otherFraction.ToDouble())
                return -1;
            if (this.ToDouble() > otherFraction.ToDouble())
                return 1;
            return 0;
        }
    }
}

