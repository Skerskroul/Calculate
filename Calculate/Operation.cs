using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class ObjectBinaryOperation
    {
        private string operation;
        private ICalcBinary calcOperation;

        public ObjectBinaryOperation(string operation, ICalcBinary calcOperation)
        {
            this.operation = operation;
            this.calcOperation = calcOperation;
        }

        public string GetOperation()
        {
            return operation;
        }

        public ICalcBinary GetInterface()
        {
            return calcOperation;
        }
    }

    interface IListBinaryOperation
    {
        List<ObjectBinaryOperation> Operations { get; }

        bool CheckOperation(string operation, out ICalcBinary obj);
    }

    class ListBinaryOperation : IListBinaryOperation
    {
        public List<ObjectBinaryOperation> Operations
        {
            get{
                return new List<ObjectBinaryOperation>()
                {
                    new ObjectBinaryOperation("+", new AddCalc()),
                    new ObjectBinaryOperation("-", new SubtractCalc()),
                    new ObjectBinaryOperation("*", new ProductCalc()),
                    new ObjectBinaryOperation("/", new DivideCalc())
                };
            }
        }

        public bool CheckOperation(string operation, out ICalcBinary obj)
        {
            List<ObjectBinaryOperation> calcOperation = Operations;

            obj = null;

            foreach (ObjectBinaryOperation value in calcOperation)
            {
                if(value.GetOperation() == operation)
                {
                    obj = value.GetInterface();
                    return true;
                }
            }
            return false;
        }
    }


    class ObjectUnaryOperation
    {
        private string operation;
        private ICalcUnary calcOperation;

        public ObjectUnaryOperation(string operation, ICalcUnary calcOperation)
        {
            this.operation = operation;
            this.calcOperation = calcOperation;
        }

        public string GetOperation()
        {
            return operation;
        }

        public ICalcUnary GetInterface()
        {
            return calcOperation;
        }
    }

    interface IListUnaryOperation
    {
        List<ObjectUnaryOperation> Operations { get; }

        bool CheckOperation(string operation, out ICalcUnary obj);
    }

    class ListUnaryOperation : IListUnaryOperation
    {
        public List<ObjectUnaryOperation> Operations
        {
            get{
                return new List<ObjectUnaryOperation>()
                {
                    new ObjectUnaryOperation("+/-", new ChangeSignCalc()),
                    new ObjectUnaryOperation("1/X", new OneDivideXCalc()),
                    new ObjectUnaryOperation("Kor", new SQRTCalc())
                };
            }
        }

        public bool CheckOperation(string operation, out ICalcUnary obj)
        {
            List<ObjectUnaryOperation> calcOperation = Operations;

            obj = null;

            foreach(ObjectUnaryOperation value in calcOperation)
                if(value.GetOperation() == operation)
                {
                    obj = value.GetInterface();
                    return true;
                }
            return false;
        }
    }


    class ObjectUnaryOperationWithTwoArgument
    {
        private string operation;
        private ICalcUnaryWithTwoArgument calcOperation;

        public ObjectUnaryOperationWithTwoArgument(string operation, ICalcUnaryWithTwoArgument calcOperation)
        {
            this.operation = operation;
            this.calcOperation = calcOperation;
        }

        public string GetOperation()
        {
            return operation;
        }

        public ICalcUnaryWithTwoArgument GetInterface()
        {
            return calcOperation;
        }
    }

    interface IListUnaryOperationWithTwoArgument
    {
        List<ObjectUnaryOperationWithTwoArgument> Operations { get; }

        bool CheckOperation(string operation, out ICalcUnaryWithTwoArgument obj);
    }

    class ListUnaryOperationWithTwoArgument : IListUnaryOperationWithTwoArgument
    {
        public List<ObjectUnaryOperationWithTwoArgument> Operations
        {
            get
            {
                return new List<ObjectUnaryOperationWithTwoArgument>()
                {
                    new ObjectUnaryOperationWithTwoArgument("%", new PerCent())
                };
            }
        }

        public bool CheckOperation(string operation, out ICalcUnaryWithTwoArgument obj)
        {
            List<ObjectUnaryOperationWithTwoArgument> calcOperation = Operations;

            obj = null;

            foreach (ObjectUnaryOperationWithTwoArgument value in calcOperation)
                if (value.GetOperation() == operation)
                {
                    obj = value.GetInterface();
                    return true;
                }
            return false;
        }
    }
}