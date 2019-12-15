namespace Prohibition.Tools
{
    /// <summary>
    /// Interface for object instance factory.
    /// </summary>
    public interface IFactory<T>
    {
        /// <summary>
        /// Creates object instance of generic type.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T CreateInstance(object[] parameters);
    }
}
