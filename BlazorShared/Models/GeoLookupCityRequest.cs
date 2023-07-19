using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;

public class GeoLookupCityRequest
{
    [Required(ErrorMessage = "City field is required")]
    public string City { get; set; }

    [Required(ErrorMessage = "StateCode field is required")]
    public string StateCode { get; set; }

    [Required(ErrorMessage = "CountryCode field is required")]
    public string CountryCode { get; set; }
}
