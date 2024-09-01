using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterDetailsInCoreDataFirst.Models;



public class Experience
{
    public Experience()
    {
    }

    [Key]
    public int ExperienceId { get; set; }

    [ForeignKey("Applicant")]
    public int ApplicantId { get; set; }

    // Navigation property
    public virtual Applicant Applicant { get; set; }

    public string CompanyName { get; set; }

    public string Designation { get; set; }

    [Range(1, 25, ErrorMessage = "Years Must Be Between 1 and 25!!!")]
    [Required]
    public int YearsWorked { get; set; }
}
