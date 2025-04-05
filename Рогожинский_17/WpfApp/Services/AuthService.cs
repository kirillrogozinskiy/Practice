﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.Services
{
    public class AuthService
    {
        private const string UsersPath = "users.json";

        public async Task<List<UserModel>> LoadUsersAsync()
        {
            return await Task.Run(() =>
            {
                if (File.Exists(UsersPath))
                {
                    var json = File.ReadAllText(UsersPath);
                    return JsonConvert.DeserializeObject<List<UserModel>>(json) ?? new List<UserModel>();
                }
                return new List<UserModel>();
            });
        }

        public async Task SaveUsersAsync(List<UserModel> users)
        {
            await Task.Run(() =>
            {
                File.WriteAllText(UsersPath, JsonConvert.SerializeObject(users, Formatting.Indented));
            });
        }

        public async Task<UserModel> LoginAsync(string username, string password)
        {
            var users = await LoadUsersAsync();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public async Task<bool> RegisterUserAsync(string username, string password, string department)
        {
            var users = await LoadUsersAsync();
            if (users.Any(u => u.Username == username))
                return false;

            users.Add(new UserModel { Username = username, Password = password, Department = department });
            await SaveUsersAsync(users);
            return true;
        }
    }
}