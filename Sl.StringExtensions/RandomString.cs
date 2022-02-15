using System;
using System.Collections.Generic;
using System.Text;

namespace Sl.StringExtensions
{
    public static class RandomString
    {
        private const string _uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string _uppercaseTR = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
        private const string _lowercaseTR = "abcçdefgğhıijklmnoöpqrsştuüvwxyz";
        private const string _uppercaseTrEng = "ABCÇDEFGĞHIIJKLMNOÖPQRSŞTUÜVWXYZ";
        private const string _lowercaseTrEng = "abcçdefgğhıijklmnoöpqrsştuüvwxyz";
        private const string numbers = "1234567890";

        private static readonly Random _rng = new Random(unchecked((int)DateTime.Now.Ticks));

        public enum RandomStringCulture
        {
            En,
            Tr,
            TrEn,
        };

        public enum RandomStringMode
        {
            LowerCase,
            UpperCase,
            Numeric,
            LowerCaseAlphaNumeric,
            UpperCaseAlphaNumeric,
            LowerAndUpperCaseAlphaNumeric
        };
        public static string GetRandomString(int size,
            RandomStringMode Mode = RandomStringMode.UpperCase,
            RandomStringCulture Culture = RandomStringCulture.En)
        {
            char[] buffer = new char[size];

            string upperCaseChars;
            string lowerCaseChars;
            switch (Culture)
            {
                case RandomStringCulture.Tr:
                    upperCaseChars = _uppercaseTR;
                    lowerCaseChars = _lowercaseTR;
                    break;
                case RandomStringCulture.TrEn:
                    upperCaseChars = _uppercaseTrEng;
                    lowerCaseChars = _lowercaseTrEng;
                    break;
                case RandomStringCulture.En:
                default:
                    upperCaseChars = _uppercaseChars;
                    lowerCaseChars = _lowercaseChars;
                    break;
            }

            string _chars;
            switch (Mode)
            {
                case RandomStringMode.LowerCase:
                    _chars = lowerCaseChars;
                    break;
                case RandomStringMode.UpperCase:
                    _chars = upperCaseChars;
                    break;
                case RandomStringMode.Numeric:
                    _chars = numbers;
                    break;
                case RandomStringMode.LowerCaseAlphaNumeric:
                    _chars = lowerCaseChars + numbers;
                    break;
                case RandomStringMode.UpperCaseAlphaNumeric:
                    _chars = upperCaseChars + numbers;
                    break;
                case RandomStringMode.LowerAndUpperCaseAlphaNumeric:
                    _chars = upperCaseChars + lowerCaseChars + numbers;
                    break;
                default:
                    throw new Exception("Unknown RandomStringMode: " + Mode);
            }

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
