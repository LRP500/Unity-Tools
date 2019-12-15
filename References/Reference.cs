using Tools.Variables;

namespace Tools.References
{
    /// <summary>
    /// Reference object allowing switching between constant value and shared variable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Reference<TValue, TVariable> where TVariable : Variable<TValue>
    {
        /// <summary>
        /// Dictates if using constant or shared variable.
        /// </summary>
        public bool useConstant = true;

        /// <summary>
        /// Constant value.
        /// </summary>
        public TValue constant = default;

        /// <summary>
        /// Shared variable.
        /// </summary>
        public TVariable variable = default;

        /// <summary>
        /// Returns value if using constant, else returns variable's value.
        /// </summary>
        public TValue Value
        {
            get => useConstant ? constant : variable;
            set
            {
                if (useConstant) constant = value;
                else variable.SetValue(value);
            }
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Reference()
        { }

        /// <summary>
        /// Constructs with initial constant value.
        /// </summary>
        /// <param name="value"></param>
        public Reference(TValue value)
        {
            useConstant = true;
            constant = value;
        }

        /// <summary>
        /// Constructs with initial variable.
        /// </summary>
        /// <param name="variable"></param>
        public Reference(TVariable variable)
        {
            this.variable = variable;
        }

        public void SetValue(TValue value)
        {
            if (useConstant)
            {
                constant = value;
            }
            else
            {
                variable.SetValue(value);
            }
        }

        public override string ToString()
        {
            return useConstant ? constant.ToString() : variable.ToString();
        }

        public static implicit operator TValue(Reference<TValue, TVariable> reference)
        {
            return reference.Value;
        }
    }
}
