﻿using System;
using System.Security.Cryptography;

namespace PowerForensics.Utilities
{
    #region HashClass

    class Hash
    {
        #region StaticMethods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private static HashAlgorithm GetAlgorithm(string algorithm)
        {
            switch (algorithm)
            {
                case "MD5":
                    return MD5.Create();
                case "SHA1":
                    return SHA1.Create();
                default:
                    throw new Exception("Invalid Hash Algorithm Provided");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        internal static string Get(byte[] bytes, string algorithm)
        {
            // Create a hash algorithm for specified algorithm
            HashAlgorithm hashAlgorithm = GetAlgorithm(algorithm);

            //Output the computed MD5 Hash as a string to the PowerShell pipeline
            return BitConverter.ToString(hashAlgorithm.ComputeHash(bytes)).Replace("-", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="count"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        internal static string Get(byte[] bytes, int count, string algorithm)
        {
            // Create a hash algorithm for specified algorithm
            HashAlgorithm hashAlgorithm = GetAlgorithm(algorithm);

            //Output the computed MD5 Hash as a string to the PowerShell pipeline
            return BitConverter.ToString(hashAlgorithm.ComputeHash(Helper.GetSubArray(bytes, 0x00, count))).Replace("-", "");
        }

        #endregion StaticMethods
    }

    #endregion HashClass
}