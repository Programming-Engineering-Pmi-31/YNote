using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoteWPF.BLL
{
    class FieldsConditions
    {
        public string Errors { get; private set; }

        // also nicknames must be unique?
        private bool NameConditions(string name)
        {
            string messageForField = $"Field {name} contains: ";
            ValidationTests tests = new ValidationTests();
            bool passed = tests.NotEmpty(name) && tests.WithoutAtSymbols(name) &&
                tests.WithoutGeneralBannedSymbols(name) && tests.WithoutNumbers(name);
            if (!passed)
            {
                messageForField += tests.notPassedTests;
                Errors += messageForField + "\n";
                // Errors += $"Field {name} contains: " + message + "\n";
            }
            return passed;
        }
        private bool SurnameConditions(string surname)
        {
            ValidationTests tests = new ValidationTests();
            string messageForField = $"Field {surname} contains: ";
            bool passed = tests.NotEmpty(surname) && tests.WithoutAtSymbols(surname) &&
                tests.WithoutGeneralBannedSymbols(surname) && tests.WithoutNumbers(surname);
            if (!passed)
            {
                messageForField += tests.notPassedTests;
                Errors += messageForField + "\n";
                // Errors += $"Field {name} contains: " + message + "\n";
            }
            return passed;
        }
        private bool NicknameConditions(string nickname)
        {
            ValidationTests tests = new ValidationTests();
            string messageForField = $"Field {nickname} contains: ";
            bool passed = tests.NotEmpty(nickname) && tests.WithoutGeneralBannedSymbols(nickname); // GenBannedSymb can be hear?
            if (!passed)
            {
                messageForField += tests.notPassedTests;
                Errors += messageForField + "\n";
                // Errors += $"Field {name} contains: " + message + "\n";
            }
            return passed;
        }
        private bool EmailConditions(string email)
        {
            ValidationTests tests = new ValidationTests();
            string messageForField = $"Field {email} contains: ";
            bool passed = tests.NotEmpty(email) && tests.WithoutAtSymbols(email) && tests.WithoutGeneralBannedSymbols(email, '.');
            if (!passed)
            {
                messageForField += tests.notPassedTests;
                Errors += messageForField + "\n";
                // Errors += $"Field {name} contains: " + message + "\n";
            }
            return passed;
        }
        private bool PasswordConditions(string pass1, string pass2)
        {
            ValidationTests tests = new ValidationTests();
            string messageForField = $"Field {pass1} contains: ";
            bool passed = tests.NotEmpty(pass1) && tests.NotEmpty(pass2) && tests.EqualPasswords(pass1, pass2);
            if (!passed)
            {
                messageForField += tests.notPassedTests;
                Errors += messageForField + "\n";
                // Errors += $"Field {name} contains: " + message + "\n";
            }
            return passed;
        }
        public bool CheckOnValidation(List<string> parameters)
        {
            bool passed = NameConditions(parameters[0]) && SurnameConditions(parameters[1]) && NicknameConditions(parameters[2])
                && EmailConditions(parameters[3]) && PasswordConditions(parameters[4], parameters[5]);
            return passed;
        }
    }
}
