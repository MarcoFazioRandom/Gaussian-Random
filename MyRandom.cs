// Coded by Marco Fazio. GitHub: MarcoFazioRandom.
using System;
public class MyRandom : Random {
    private bool hasSpare = false;
    private double spare;

    public MyRandom() : base() { }

    public MyRandom(int seed) : base(seed) { }

    private double NextGaussianStandard() {
        if (hasSpare) {
            hasSpare = false;
            return spare;
        }
        else {
            double u, v, s;
            do {
                u = base.Sample() * 2 - 1;
                v = base.Sample() * 2 - 1;
                s = u * u + v * v;
            } while (s > 1 || s == 0);
            s = Math.Sqrt(-2 * Math.Log(s) / s);
            spare = v * s;
            hasSpare = true;
            return u * s;
        }
    }

    /// <summary>
    /// Return a number in the range (-1, +1) with a Normal distribuited probability using the Marsaglia polar method.
    /// </summary>
    /// <param name="standardDeviation"> 
    /// It is a measure of the amount of variation or dispersion of the values.
    /// </param>
    /// <returns></returns>
    public double NextGaussian(double standardDeviation = 1) {
        double x;
        do {
            x = NextGaussianStandard() * standardDeviation / 3;
        } while (x < -1 || x > 1);
        return x;
    }
}