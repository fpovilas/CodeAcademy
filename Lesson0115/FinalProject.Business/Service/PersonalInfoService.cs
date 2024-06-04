using AutoMapper;
using FinalProject.Business.Helper;
using FinalProject.Business.Service.Interface;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
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

            return allPIR;
        }

        public PersonalInformationWithIdDTO Get(int id, string username)
        {
            var personalInfo = personalInfoRepository.Get(id, username);
            if (personalInfo is null)
            { throw new Exception("Data does not exist."); }
            else { return personalInfo!; }
        }

        public void Put(PersonalInformationDTO personalInformationDTO, IFormFile file, string? username)
        {
            if (username is not null)
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

                if (personalInformationDTO.Validate() && personalInformationDTO.PlaceOfResidence.Validate())
                {
                    var personalInfo = mapper.Map<PersonalInformation>(personalInformationDTO);
                    var placeOfResidence = mapper.Map<PlaceOfResidence>(personalInformationDTO.PlaceOfResidence);
                    var user = userRepository.FindByUsername(username);
                    personalInfo.ProfilePicturePath = imageFilePath;
                    personalInfo.PlaceOfResidence = placeOfResidence;
                    personalInfo.User = user;

                    // Repository
                    personalInfoRepository.Put(personalInfo);

                    var imgData = ImageHelper.Resize(imageBytes, 200, 200);
                    ImageHelper.SaveNoteImageThumbnail(imageFilePath, imgData);
                    File.WriteAllBytes(imageFilePath, imageBytes);
                }
                else { throw new Exception("Could not validate data."); }
            }
            else { throw new Exception($"User with username {username} does not exists"); }
        }

        public void Delete(int id, string username)
        {
            bool isDeleted = false;

            var user = userRepository.FindByUsername(username) ?? throw new Exception($"User with username: {username} does not exist.");

            ICollection<PersonalInformation> personalInfoList = user.PersonalInformations ?? throw new Exception($"User does not have any personal info yet.");

            var infoToDelete = personalInfoList.FirstOrDefault(pi => pi.Id == id) ?? throw new Exception($"Personal information with supplied Id does not exist in users personal info list.");
            try { File.Delete(infoToDelete.ProfilePicturePath!); }
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
    }
}