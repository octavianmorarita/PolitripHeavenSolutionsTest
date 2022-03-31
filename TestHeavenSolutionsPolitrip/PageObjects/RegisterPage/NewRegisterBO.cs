using System;
namespace TestHeavenSolutionsPolitrip.PageObjects.RegisterPage
{
    public class NewRegisterBO
    {
        public string FirstName { get; set; } = "Tester";
        public string LastName { get; set; } = "Tester";
        public string Email { get; set; } = "testter@unom.test";
        public string Password { get; set; } = "Tester01";
        public string RepeatPassword { get; set; } = "Tester01";
        public string choice { get; set; } = "From a friend";
        public string LblRegister { get; set; } = "Tester Tester";
    }
}
