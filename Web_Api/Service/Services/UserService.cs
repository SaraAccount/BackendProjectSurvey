using Repository.Entities;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly EmailService _emailService;


        public UserService(UserRepository userRepository, EmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Register(string email, string password)
        {
            if (await _userRepository.IsEmailExist(email))
                throw new Exception("Email already exists");

            var hashedPassword = HashPassword(password);
            var user = new User { Email = email, Password = hashedPassword };

            await _userRepository.AddItem(user);

            await _emailService.SendEmailAsync(email, "Registration", "Welcome! You have been registered.");
        }

        public async Task ForgotPassword(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
                throw new Exception("Email not found");

            string newPassword = GeneratePassword(16);
            user.Password = HashPassword(newPassword);

            await _userRepository.UpdateItem(user);

            await _emailService.SendEmailAsync(email, "Password Reset", $"Your new password is: {newPassword}");
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public string GeneratePassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
