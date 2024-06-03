using FinalProject.Shared.Enums;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.DTOs
{
    public class PersonalInformationDTO
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required Gender Gender { get; set; }
        public required DateOnly Birthday { get; set; }
        public required string PersonalCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }
        public required PlaceOfResidenceDTO PlaceOfResidence { get; set; }

        private readonly string nameAndLastNameCheck = @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž]{2,50}$";
        private readonly string phoneNumberCheck = @"^3706.*\d{7}$";
        private readonly string emailCheck = @"^(?i)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

        public bool Validate()
        {
            //Name, LastName, Gender, Birthday, PersonalCode, PhoneNumber, EmailAddress
            var isNameNndLasName = ValidateFirstAndLastName();
            var isBirthday = Birthday < DateOnly.FromDateTime(DateTime.Now);
            var isPersonalCode = ValidatePersonalCode();
            var isPhoneNumber = ValidatePhoneNumber();
            var isEmailAddress = ValidateEmailAddress();

            return isNameNndLasName && isBirthday && isPersonalCode && isPhoneNumber && isEmailAddress;
        }

        private bool ValidateFirstAndLastName()
        {
            var isName = Regex.IsMatch(Name, nameAndLastNameCheck);
            var isLastName = Regex.IsMatch(LastName, nameAndLastNameCheck);

            return isName && isLastName;
        }

        private bool ValidatePersonalCode()
        {
            List<int> firstRound = [1, 2, 3, 4, 5, 6, 7, 8, 9, 1];
            List<int> secondRound = [3, 4, 5, 6, 7, 8, 9, 1, 2, 3];
            Dictionary<int, List<int>> rounds = new()
            {
                { 0, firstRound},
                { 1, secondRound}
            };
            int personalCodeLength = 11;
            int roundsNumber = 2;
            int sum;
            int controlNumber;
            bool validPersonalCode = false;

            if (PersonalCode.Length < 11)
            { throw new Exception("Impossible to calculate."); }

            List<int> personalCodeToNumList = ToIntList(PersonalCode);

            for (int j = 0; j < roundsNumber; j++)
            {
                if (!validPersonalCode)
                {
                    sum = 0;
                    for (int i = 0; i < personalCodeLength; i++)
                    {
                        if (personalCodeLength - 1 > i)
                        { sum += personalCodeToNumList[i] * rounds[j][i]; }
                        else
                        {
                            controlNumber = personalCodeToNumList[i];

                            if (controlNumber == sum % 11 && j == 0)
                            { validPersonalCode = true; }
                            else if (controlNumber == sum % 11 && j == 1)
                            { validPersonalCode = true; }
                            else { validPersonalCode = false; }
                        }
                    }
                }
            }

            // Check if entered birthday matches personal code
            string birthDate = Birthday.ToString("yyMMdd");
            string birthDateFromPersonalCode = PersonalCode.Substring(1, 6);

            if (birthDate.Equals(birthDateFromPersonalCode) && validPersonalCode)
            { validPersonalCode = true; }
            else { validPersonalCode = false; }

            return validPersonalCode;
        }

        private List<int> ToIntList(string personalCode)
        {
            List<int> list = [];
            foreach (char s in personalCode)
            {
                int num = int.Parse(s.ToString());
                list.Add(num);
            }

            return list;
        }

        private bool ValidatePhoneNumber()
            => Regex.IsMatch(PhoneNumber, phoneNumberCheck);

        private bool ValidateEmailAddress()
            => Regex.IsMatch(EmailAddress, emailCheck);
    }
}