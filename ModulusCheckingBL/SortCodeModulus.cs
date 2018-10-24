using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModulusCheckingBL;

namespace ModulusCheckingBL
{
    public class SortCodeModulus
    {
        private bool? c_valid;
        private string c_accountNumber;
        private bool? c_implemented;

        const int m_g = 12;
        const int m_h = 13;
        const int m_u = 0;
        const int m_b = 7;


        public string SortCode { get; set; }
        public short[] Weights { get; set; }
        public short Modulus { get; set; }
        public short Ext { get; set; }
        /// <summary>
        /// If  not true then the Exception logic for Ext is not Implemented
        /// </summary>
        public bool Implemented {
            get
            {
                if (!c_implemented.HasValue) validate();
                return c_implemented.GetValueOrDefault();
            }
            set => c_implemented = value;
        }
        public bool Valid
        {
            get
            {
                if (!c_valid.HasValue) validate();
                return c_valid.GetValueOrDefault();
            }
            set { }
        }

        public string AccountNumber
        {
            get => c_accountNumber;
            set
            {
                if (c_accountNumber != value)
                {
                    c_accountNumber = value;
                    c_valid = null;
                    c_implemented = null;

                    if (AdditionalCheck != null) AdditionalCheck.AccountNumber = value;
                }
            }
        }

        /// <summary>
        /// If this has a value than DoubleAlternate is used with this SortCodeWeight
        /// </summary>
        public SortCodeModulus AdditionalCheck { get; set; }

        private void validate()
        {
            if (string.IsNullOrWhiteSpace(c_accountNumber)) c_valid = false;
            else
            {
                var accontNumbner = AccountNumber.ToNumericOnly().PadLeft(8, '0').Substring(0,8);
                var sortCode = SortCode.ToNumericOnly().PadLeft(6, '0').Substring(0,6);
                var fullNumber = sortCode + accontNumbner;
                var weighedNumber = new int[14];
                short[] weights = new short[14]; Weights.CopyTo(weights, 0);

                if (Ext == 7 && fullNumber[m_g].ToShort() == 9) for (int i = m_u; i <= m_b; i++) weights[i] = 0;

                for (int i = 0; i < weighedNumber.Length; i++) weighedNumber[i] = fullNumber[i].ToShort() * weights[i];

                var remain = weighedNumber.Sum() % Modulus;

                Implemented = Modulus != 1; // if 1 then it's the default (none existing) weights
                var valid = remain == 0;

                if (Ext != 0)
                {
                    if (Ext == 4) valid = remain == (10 * fullNumber[m_g].ToShort() + fullNumber[m_h].ToShort());
                    else if (Ext == 7) { }
                    // All DBLAL seem to have Ext == 6
                    else if (Ext == 6) { }
                    else Implemented = false;
                }

                if (valid && AdditionalCheck != null) c_valid = AdditionalCheck.Valid;
                else c_valid = valid;
            }
        }

        public static SortCodeModulus Get(string sortCode)
        {
            var sortCodeWeights = SortCodeWeights.Get(sortCode).ToList();

            var sortCodeModules = (sortCodeWeights.Count == 0) ? weightToModulus(sortCode, SortCodeWeights.Default()) : weightToModulus(sortCode, sortCodeWeights[0]);

            if (sortCodeWeights.Count == 2) sortCodeModules.AdditionalCheck = weightToModulus(sortCode, sortCodeWeights[1]);

            return sortCodeModules;
        }

        public static SortCodeModulus Get(string sortCode, string accountNumber)
        {
            var sortCodeModulus = Get(sortCode);
            sortCodeModulus.AccountNumber = accountNumber;
            return sortCodeModulus;
        }

        private static SortCodeModulus weightToModulus(string sortCode, SortCodeWeight weight)
        {
            /* MOD01 used in Default weight to always return 0 on Modulus check. */
            return new SortCodeModulus
            {
                SortCode = sortCode,
                Weights = weight.Weights,
                Modulus = (short)(weight.Method.Contains("11") ? 11 : weight.Method.Contains("01") ? 1 : 10),
                Ext = weight.Exception
            };
        }
    }

}
