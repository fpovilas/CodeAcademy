using AutoMapper;
using FinalProject.Business.Helper;
using FinalProject.Business.Service.Interface;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using FinalProject.Shared.CustomExceptions;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Business.Service
{
    public class PersonalInfoService(IPersonalInfoRepository personalInfoRepository, IUserRepository userRepository, IMapper mapper) : IPersonalInfoService
    {
        private readonly string imagePath = @"./ProfilePictures";

        public IEnumerable<PersonalInformationWithIdDTO> GetAll(string username)
        {
            var allPIR = personalInfoRepository.GetAll(username);
            if (allPIR is null || !allPIR.Any())
            { throw new Exception($"The user {username} has no personal information stored"); }

            return mapper.Map<IEnumerable<PersonalInformationWithIdDTO>>(allPIR);
        }

        public PersonalInformationWithIdDTO Get(int id, string username)
        {
            var personalInfo = personalInfoRepository.Get(id, username);
            if (personalInfo is null)
            { throw new Exception("Data does not exist."); }
            else { return mapper.Map<PersonalInformationWithIdDTO>(personalInfo); ; }
        }

        public void Put(PersonalInformationDTO personalInformationDTO, IFormFile file, string? username)
        {
            if (username is not null)
            {
                if (personalInformationDTO.Validate() && personalInformationDTO.PlaceOfResidence.Validate())
                {
                    var personalInfo = mapper.Map<PersonalInformation>(personalInformationDTO);
                    var placeOfResidence = mapper.Map<PlaceOfResidence>(personalInformationDTO.PlaceOfResidence);
                    var user = userRepository.FindByUsername(username);
                    personalInfo.ProfilePicturePath = CreateImage(file);
                    personalInfo.PlaceOfResidence = placeOfResidence;
                    personalInfo.User = user;

                    // Repository
                    personalInfoRepository.Put(personalInfo);
                }
                else { throw new Exception("Could not validate data."); }
            }
            else { throw new Exception($"User with username {username} does not exists"); }
        }

        public PersonalInformationUpdateDTO Update(PersonalInformationUpdateDTO personalInformation, IFormFile file, int idPI, string username)
        {
            var pIR = personalInfoRepository.Get(idPI, username) ?? throw new NoDataException("Data does not exist.");

            if (personalInformation is null) throw new NoDataException("There is no data given.");

            if (personalInformation.Name is not null)
            {
                if (personalInformation.ValidateFirstName())
                { pIR.Name = personalInformation.Name; }
                else { throw new BadNameException($"Given Fist name {personalInformation.Name} does not match criteria."); }
            }

            if (personalInformation.LastName is not null)
            {
                if (personalInformation.ValidateLastName()) { pIR.LastName = personalInformation.LastName; }
                else { throw new BadNameException($"Given Last name {personalInformation.LastName} does not match criteria."); }
            }

            if (personalInformation.Birthday is not null && personalInformation.PersonalCode is not null)
            {
                if (personalInformation.ValidateBirthday() && personalInformation.ValidatePersonalCode())
                {
                    pIR.Birthday = personalInformation.Birthday;
                    pIR.PersonalCode = personalInformation.PersonalCode;
                }
                else { throw new Exception($"Given Birthday and Personal code does not match criteria or are bad."); }
            }

            if (personalInformation.PhoneNumber is not null)
            {
                if (personalInformation.ValidatePhoneNumber()) { pIR.PhoneNumber = personalInformation.PhoneNumber; }
                else { throw new Exception($"Given Phone number {personalInformation.PhoneNumber} does not match criteria."); }
            }

            if (personalInformation.EmailAddress is not null)
            {
                if (personalInformation.ValidateEmailAddress()) { pIR.EmailAddress = personalInformation.EmailAddress; }
                else { throw new Exception($"Given Email address {personalInformation.EmailAddress} does not match criteria."); }
            }

            if (file is not null)
            {
                try
                {
                    File.Delete(pIR.ProfilePicturePath!);
                    pIR.ProfilePicturePath = CreateImage(file);
                }
                catch { pIR.ProfilePicturePath = CreateImage(file); }
            }

            if (personalInformation.PlaceOfResidence is not null)
            {
                if (personalInformation.PlaceOfResidence.City is not null)
                {
                    if (personalInformation.PlaceOfResidence.ValidateCity()) { pIR.PlaceOfResidence!.City = personalInformation.PlaceOfResidence.City; }
                    else { throw new Exception($"Given City {personalInformation.PlaceOfResidence.City} does not match criteria."); }
                }

                if (personalInformation.PlaceOfResidence.Street is not null)
                {
                    if (personalInformation.PlaceOfResidence.ValidateStreet()) { pIR.PlaceOfResidence!.Street = personalInformation.PlaceOfResidence.Street; }
                    else { throw new Exception($"Given Street {personalInformation.PlaceOfResidence.Street} does not match criteria."); }
                }

                if (personalInformation.PlaceOfResidence.HouseNumber is not null)
                {
                    if (personalInformation.PlaceOfResidence.ValidateHouseNumber()) { pIR.PlaceOfResidence!.HouseNumber = personalInformation.PlaceOfResidence.HouseNumber; }
                    else { throw new Exception($"Given House number {personalInformation.PlaceOfResidence.HouseNumber} does not match criteria."); }
                }

                if (personalInformation.PlaceOfResidence.ApartmentNumber is not null)
                {
                    if (personalInformation.PlaceOfResidence.ValidateApartmentNumber()) { pIR.PlaceOfResidence!.ApartmentNumber = personalInformation.PlaceOfResidence.ApartmentNumber; }
                    else { throw new Exception($"Given Apartment number {personalInformation.PlaceOfResidence.ApartmentNumber} does not match criteria."); }
                }
            }

            personalInfoRepository.Update(pIR);

            return mapper.Map<PersonalInformationUpdateDTO>(pIR);
        }

        public void Delete(int id, string username)
        {
            bool isDeleted = false;

            var user = userRepository.FindByUsername(username) ?? throw new Exception($"User with username: {username} does not exist.");

            ICollection<PersonalInformation> personalInfoList = user.PersonalInformations ?? throw new Exception($"User does not have any personal info yet.");

            var infoToDelete = personalInfoList.FirstOrDefault(pi => pi.Id == id) ?? throw new Exception($"Personal information with supplied Id does not exist in users personal info list.");
            try { DeleteImage(infoToDelete.ProfilePicturePath!); }
            catch
            {
                personalInfoRepository.Delete(infoToDelete);
                isDeleted = true;
            }

            if (!isDeleted) { personalInfoRepository.Delete(infoToDelete); }
        }

        public bool GetProfilePicture(int idPI, string username, out string msg, out string profilePicturePath)
        {
            profilePicturePath = personalInfoRepository.GetProfilePicture(idPI, username);
            msg = string.Empty;

            if (profilePicturePath is null)
            {
                msg = "Image not found.";
                return false;
            }

            if (!File.Exists(profilePicturePath))
            {
                msg = "File does not exist on disk.";
                return false;
            }

            return true;
        }

        private string CreateImage(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            string imageName = file.FileName[..file.FileName.IndexOf('.')]; // Takes everything till first character in this case '.'
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string imageExtension = Path.GetExtension(file.FileName).Trim('.');

            string imageFilePath = $"{imagePath}/{imageName}_{currentTime}.{imageExtension}";

            if (!Directory.Exists(imagePath))
            { Directory.CreateDirectory(imagePath); }

            var imgData = ImageHelper.Resize(imageBytes, 200, 200);
            ImageHelper.SaveNoteImageThumbnail(imageFilePath, imgData);
            File.WriteAllBytes(imageFilePath, imageBytes);

            return imageFilePath;
        }

        private static void DeleteImage(string picturePath)
            => File.Delete(picturePath);
    }
}