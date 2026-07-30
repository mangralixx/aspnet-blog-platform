using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities
{
  
    public enum MessageStatus
    {
        [Display(Name = "Нове")]
        New,

        [Display(Name = "В процесі")]
        InProgress,

        [Display(Name = "Відповідь надана")]
        Answered,

        [Display(Name = "Закрито")]
        Closed,

        [Display(Name = "Архів")]
        Archived,

        [Display(Name = "Спам")]
        Spam
    }
}