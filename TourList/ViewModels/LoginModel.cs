using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourList.ViewModels
{
  public class LoginModel
  {
    [Required(ErrorMessage = "Не указан email")]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }
    
    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}
