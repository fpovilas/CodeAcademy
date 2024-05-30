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
        private readonly string imagePath = @"./NoteImages";

        public IEnumerable<PersonalInformationDTO> GetAll(string username)
        {
            var allPIR = personalInfoRepository.GetAll(username);
            if (allPIR is null || !allPIR.Any())
            { throw new Exception($"The user {username} has no personal information stored"); }

            return allPIR;
        }

        public void Put(PersonalInformationDTO personalInformationDTO, IFormFile file, string? username)
        {
            if (username is not null)
            {
                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();

                string imageName = file.FileName[..file.FileName.IndexOf('.')];
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string imageExtension = Path.GetExtension(file.FileName).Trim('.');

                string imageFilePath = $"{imagePath}/{imageName}_{currentTime}.{imageExtension}";

                if (!Directory.Exists(imagePath))
                { Directory.CreateDirectory(imagePath); }

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
            else { throw new Exception($"User with username {username} does not exists"); }
        }
    }
}