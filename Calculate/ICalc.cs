using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    interface ICalcBinary
    {
        double Calc(double first, double second);
    }

    interface ICalcUnary
    {
        double Calc(double first);
    }

    interface ICalcUnaryWithTwoArgument
    {
        double Calc(double first, double second);
    }



    class AddCalc : ICalcBinary
    {
        public double Calc(double first, double second)
        {
            return first + second;
        }
    }

    class SubtractCalc : ICalcBinary
    {
        public double Calc(double first, double second)
        {
            return first - second;
        }
    }

    class ProductCalc : ICalcBinary
    {
        public double Calc(double first, double second)
        {
            return first * second;
        }
    }

    class DivideCalc : ICalcBinary
    {
        public double Calc(double first, double second)
        {
            return first / second;
        }
    }



    class SQRTCalc : ICalcUnary
    {
        public double Calc(double first)
        {
            return Math.Sqrt(first);
        }
    }

    class OneDivideXCalc : ICalcUnary
    {
        public double Calc(double first)
        {
            return 1.0 / first;
        }
    }

    class ChangeSignCalc : ICalcUnary
    {
        public double Calc(double first)
        {
            return -first;
        }
    }



    class PerCent : ICalcUnaryWithTwoArgument
    {
        public double Calc(double first, double second)
        {
            return first / 100 * second;
        }
    }

}