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
        public bool NameConditions(string name)
        {
            ValidationTests tests = new ValidationTests();
            bool t1 = tests.NotEmpty(name);
            bool t2 = tests.WithoutAtSymbols(name);
            bool t3 = tests.WithoutGeneralBannedSymbols(name);
            bool t4 = tests.WithoutNumbers(name);
            if ((t1 && t2 && t3 && t4) == false)
            {
                Errors += $"Field Name: {tests.notPassedTests}\n";
            }
            return (t1 && t2 && t3 && t4);
        }
        public bool SurnameConditions(string surname)
        {
            ValidationTests tests = new ValidationTests();
            bool t1 = tests.NotEmpty(surname);
            bool t2 = tests.WithoutAtSymbols(surname);
            bool t3 = tests.WithoutGeneralBannedSymbols(surname);
            bool t4 = tests.WithoutNumbers(surname);
            if ((t1 && t2 && t3 && t4) == false)
            {
                Errors += $"Field Surname: {tests.notPassedTests}\n";
            }
            return (t1 && t2 && t3 && t4);
        }
        public bool NicknameConditions(string nickname)
        {
            ValidationTests tests = new ValidationTests();
            bool t1 = tests.NotEmpty(nickname);
            bool t2 = tests.WithoutGeneralBannedSymbols(nickname);
            if ((t1 && t2) == false)
            {
                Errors += $"Field Nickname: {tests.notPassedTests}\n";
            }
            return t1 && t2;
        }
        public bool EmailConditions(string email)
        {
            ValidationTests tests = new ValidationTests();
            bool t1 = tests.NotEmpty(email);
            //bool t2 = tests.WithoutAtSymbols(email);
            bool t2 = tests.WithoutGeneralBannedSymbols(email, '.');
            if ((t1 && t2) == false)
            {
                Errors += $"Field Email: {tests.notPassedTests}\n";
            }
            return t1 && t2;
        }
        public bool PasswordConditions(string pass1, string pass2)
        {
            ValidationTests tests = new ValidationTests();
            bool t1 = tests.NotEmpty(pass1);
            bool t2 = tests.NotEmpty(pass2);
            bool t3 = tests.EqualPasswords(pass1, pass2);
            if ((t1 && t2 && t3) == false)
            {
                Errors += $"Field Password: {tests.notPassedTests}\n";
            }
            return (t1 && t2 && t3);
        }
        public bool CheckOnValidation(List<string> parameters)
        {
            bool t1 = NameConditions(parameters[0]);
            bool t2 = SurnameConditions(parameters[1]);
            bool t3 = NicknameConditions(parameters[2]);
            bool t4 = EmailConditions(parameters[3]);
            bool t5 = PasswordConditions(parameters[4], parameters[5]);
            return (t1 && t2 && t3 && t4 && t5);
        }
    }
}
