using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;

public class GeoLookupZipRequest
{
    [Required(ErrorMessage = "ZipCode field is required")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "CountryCode field is required")]
    public string CountryCode { get; set; }
}
