using Tools.Variables;

namespace Tools.References
{
    [System.Serializable]
    public class IntReference : Reference<int, IntVariable>
    {
        public void Add(int value)
        {
            if (useConstant) constant += value;
            else variable.SetValue(variable.Value + value);
        }

        public void Substract(int value)
        {
            if (useConstant) constant -= value;
            else variable.SetValue(variable.Value - value);
        }

        public void MultiplyBy(int value)
        {
            if (useConstant) constant *= value;
            else variable.SetValue(variable.Value * value);
        }

        public void DivideBy(int value)
        {
            if (useConstant) constant = (value == 0) ? constant : constant / value;
            else variable.SetValue(value == 0 ? variable.Value : variable.Value / value);
        }
    }
}
