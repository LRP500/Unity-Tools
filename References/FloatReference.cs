using Tools.Variables;

namespace Tools.References
{
    [System.Serializable]
    public class FloatReference : Reference<float, FloatVariable>
    {
        public void Add(float value)
        {
            if (useConstant) constant += value;
            else variable.Add(value);
        }

        public void Substract(float value)
        {
            if (useConstant) constant -= value;
            else variable.Substract(value);
        }

        public void MultiplyBy(float value)
        {
            if (useConstant) constant *= value;
            else variable.MultiplyBy(value);
        }

        public void DivideBy(float value)
        {
            if (useConstant) constant /= (value == 0) ? 1 : value;
            else variable.DivideBy(value);
        }
    }
}
