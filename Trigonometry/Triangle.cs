namespace Trigonometry;

public class Triangle
{
    #region Fields

    private Point _a;
    private Point _b;
    private Point _c;

    private double _lenAB;
    private double _lenBC;
    private double _lenAC;

    private double _angA;
    private double _angB;
    private double _angC;

    #endregion Fields

    #region Ctors

    public Triangle() { }

    public Triangle(Point A, Point B, Point C)
    {
        _a = A;
        _b = B;
        _c = C;     
        CalculateAngles();
    }

    #endregion Ctors

    public static double CalculateSideLength(Point a, Point b)
    {
        return Math.Sqrt(Math.Pow((a.X - b.X), 2)
                        + Math.Pow((a.Y - b.Y), 2));
    }

    public static double CalculateAngle(double a, double b, double c) =>
        Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2))
                                         / (2 * b * c));
    public static double ConvertFromRadsToDegs(double rad) => rad * 360 / (Math.PI * 2);
    public static double ConvertFromDegsToRads(double deg) => deg * Math.PI * 2 / 360;

    public void CalculateAngles()
    {
        if (_lenAB == 0 || _lenBC == 0 || _lenAC == 0)
        {
            FindAllSidesLength();
        }

        AngA = CalculateAngle(_lenBC, _lenAC, _lenAB);
        AngB = CalculateAngle(_lenAC, _lenAB, _lenBC);
        AngC = CalculateAngle(_lenAB, _lenAC, _lenBC);
    }

    public void FindAllSidesLength()
    {
        LenAB = CalculateSideLength(A, B);
        LenAC = CalculateSideLength(A, C);
        LenBC = CalculateSideLength(B, C);
    }

    #region Properties

    public Point A { get { return _a; } set { _a = value; } }
    public Point B { get { return _b; } set { _b = value; } }
    public Point C { get { return _c; } set { _c = value; } }

    public double LenAC { get => _lenAC; set => _lenAC = value; }
    public double LenBC { get => _lenBC; set => _lenBC = value; }
    public double LenAB { get => _lenAB; set => _lenAB = value; }

    public double AngA { get => _angA; set => _angA = value; }
    public double AngB { get => _angB; set => _angB = value; }
    public double AngC { get => _angC; set => _angC = value; }

    #endregion Properties
}

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}