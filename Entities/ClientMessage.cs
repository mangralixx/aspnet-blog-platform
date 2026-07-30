using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities
{
    public class ClientMessage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я є обов'язковим для заповнення")]
        [StringLength(128, MinimumLength = 2, ErrorMessage = "Текст занадто малий. Ім'я повинно бути від 2 до 128 символів")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ' ]+$", ErrorMessage = "Ім'я не може містити цифри або спецсимволи")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        [StringLength(255)]
        public string UserEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вкажіть тему повідомлення")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Тема занадто коротка. Мінімальна довжина — 5 символів")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле повідомлення не може бути порожнім")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Повідомлення занадто коротке. Напишіть хоча б 10 символів")]
        public string Message { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime DateofCreated { get; set; } = DateTime.Now;

        [Required]
        public MessageStatus Status { get; set; } = MessageStatus.New;
    }
}