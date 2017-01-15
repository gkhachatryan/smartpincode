using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartPinCode
{
    public enum PinCodeType
    {
        Alphabet,
        Numeric,
        AlphaNumeric,
        AlphaNumericWithSymbols
    }

    public class PinCode
    {
        private Dictionary<PinCodeType, string> PinCodeAlphabets = new Dictionary<PinCodeType, string> {
            { PinCodeType.Alphabet, "abcdefghijklmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ" },
            { PinCodeType.Numeric, "0123456789" },
            { PinCodeType.AlphaNumeric, "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ" },
            { PinCodeType.AlphaNumericWithSymbols, "*$-+?_&=!%{}/0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ" },
        };
        private int _length; 
        private char[] pin;
        public PinCodeType Type { get; set; }
        public int Length 
        { 
            get
            {
                return _length;
            } 
            set 
            {
                _length = value;
                pin = new char[value];
            }
        }

        public PinCode(int length)
        {
            _length = length;
            pin = new char[_length];
        }

        public PinCode(int passwordlenght, PinCodeType type)
            : this(passwordlenght)
        {
            Type = type;
        }


        public string Generate()
        {
            byte[] randomBytes = new byte[pin.Length];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            var seed = BitConverter.ToInt32(randomBytes, 0);
            var random = new Random(seed);

            for (int i = 0; i < pin.Length; i++)
            {
                pin[i] = PinCodeAlphabets[Type][random.Next(0, PinCodeAlphabets[Type].Length - 1)];
            }

            return new string(pin);
        }
    }
}