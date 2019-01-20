using System;

namespace DataStructures
{
    public interface IBigInteger:IComparable<BigInteger>
    {
        /// <summary>
        /// Gets the sign of the interger. False if negative, True if positive
        /// </summary>
        bool Sign { get; }
        /// <summary>
        /// Adds two big integers and return the resulting integer
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Sum</returns>
        IBigInteger Add(IBigInteger number);
        /// <summary>
        ///Subtracts two big integers and return the resulting integer
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Differens</returns>
        IBigInteger Subtract(IBigInteger number);
        /// <summary>
        /// Multiplies two big integers and return the resulting integer
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Product</returns>
        IBigInteger Multiply(IBigInteger number);
    }
}
