using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoteWPF.BLL
{
    class ValidationTests
    {
        public string notPassedTests;
        public bool NotEmpty(string fieldToCheck)
        {
            string message = "is empty\n";
            bool passed = fieldToCheck != "" ? true : false;
            if (!passed)
            {
                notPassedTests += message;
            }
            return passed;
        }
        public bool EqualPasswords(string pass, string passToConfirm)
        {
            string message = "Not equal passwords\n";
            bool passed = pass == passToConfirm ? true : false; if (!passed)
            {
                notPassedTests += message;
            }
            return passed;
        }
        public bool WithoutGeneralBannedSymbols(string fieldToCheck)
        {
            string message = "banned symbols (";
            List<char> generalBannedSymbols = new List<char>() { '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=',
            '{', '}', '[', ']', '|', ';', ':', '"', '\'', ',', '<', '>', '?', '/', ' ', '.' };
            List<bool> passedTests = new List<bool>() { };
            foreach (var symbol in generalBannedSymbols)
            {
                if (fieldToCheck.Contains(symbol))
                {
                    passedTests.Add(false);
                    message += $"{symbol} ";
                }
            }
            if (passedTests.Contains(false))
            {
                message += ")";
                notPassedTests += message + "\n";
            }
            return !passedTests.Contains(false);
        }

        // Added overrided method for email field to allow symbol point '.'
        public bool WithoutGeneralBannedSymbols(string fieldToCheck, char allowedSymbol)
        {
            string message = "banned symbols (";
            List<char> generalBannedSymbols = new List<char>() { '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=',
            '{', '}', '[', ']', '|', ';', ':', '"', '\'', ',', '<', '>', '?', '/', ' ', '.' };
            List<bool> passedTests = new List<bool>() { };
            foreach (var symbol in generalBannedSymbols)
            {
                if (fieldToCheck.Contains(symbol))
                {
                    if (symbol == allowedSymbol)
                    {
                        continue;
                    }
                    passedTests.Add(false);
                    message += $"{symbol} ";
                }
            }
            if (passedTests.Contains(false))
            {
                message += ")";
                notPassedTests += message + "\n";
            }
            return !passedTests.Contains(false);
        }
        public bool WithoutNumbers(string fieldToCheck)
        {
            string message = $"numbers (";
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
                notPassedTests += message + "\n";
            }
            return !passedTests.Contains(false) ? true : false;
        }
        public bool WithoutAtSymbols(string fieldToCheck)
        {
            string message = "symbol '@'";
            bool passed = !fieldToCheck.Contains('@');
            if (!passed)
            {
                notPassedTests += message + "\n";
            }
            return passed;
        }
    }
}
