using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoteWPF.BLL
{
    class ValidationTests
    {
        public string notPassedTests = "";
        public bool NotEmpty(string fieldToCheck)
        {
            string message = "is empty. ";
            bool passed = fieldToCheck != "";
            if (!passed)
            {
                notPassedTests += message;
            }
            return passed;
        }
        public bool EqualPasswords(string pass, string passToConfirm)
        {
            string message = "Not equal passwords. ";
            bool passed = pass == passToConfirm;
            if (!passed)
            {
                notPassedTests += message;
            }
            return passed;
        }
        public bool WithoutGeneralBannedSymbols(string fieldToCheck)
        {
            string message = "banned symbols ( ";
            List<char> generalBannedSymbols = new List<char>() { '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=',
            '{', '}', '[', ']', '|', ';', ':', '"', '\'', ',', '<', '>', '?', '/', ' ', '.' };
            List<bool> passedTests = new List<bool>() { };
            foreach (var symbol in generalBannedSymbols)
            {
                if (fieldToCheck.Contains(symbol))
                {
                    passedTests.Add(false);
                    message += $"'{symbol}' ";
                }
            }
            if (passedTests.Contains(false) == true)
            {
                message += ") ";
                notPassedTests += message;
            }
            return !passedTests.Contains(false);
        }

        // Added overrided method for email field to allow symbol point '.'
        public bool WithoutGeneralBannedSymbols(string fieldToCheck, char allowedSymbol)
        {
            string message = "banned symbols (";
            List<char> generalBannedSymbols = new List<char>() { '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=',
            '{', '}', '[', ']', '|', ';', ':', '"', '\'', ',', '<', '>', '?', '/', ' ', '.' };
            generalBannedSymbols.RemoveAll(x => x == allowedSymbol);
            List<bool> passedTests = new List<bool>() { };
            foreach (var symbol in generalBannedSymbols)
            {
                if (fieldToCheck.Contains(symbol))
                {
                    passedTests.Add(false);
                    message += $"'{symbol}' ";
                }
            }
            if (passedTests.Contains(false))
            {
                message += ") ";
                notPassedTests += message;
            }
            return !passedTests.Contains(false);
        }
        public bool WithoutNumbers(string fieldToCheck)
        {
            string message = $"numbers ( ";
            List<bool> passedTests = new List<bool>() { };
            List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            foreach (var number in numbers)
            {
                if (fieldToCheck.Contains(number))
                {
                    passedTests.Add(false);
                    message += $"{number} ";
                }
            }
            if (passedTests.Contains(false))
            {
                message += ")";
                notPassedTests += message;
            }
            return !passedTests.Contains(false);
        }
        public bool WithoutAtSymbols(string fieldToCheck)
        {
            string message = "symbol '@' ";
            bool passed = !fieldToCheck.Contains('@');
            if (!passed)
            {
                notPassedTests += message;
            }
            return passed;
        }
        public bool IsUnique(string fieldToCheck)
        {
            bool passed = false;

            return passed;
        }
    }
}
