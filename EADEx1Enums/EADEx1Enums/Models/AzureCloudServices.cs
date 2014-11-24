using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EADEx1Enums.Models
{
    public enum InstanceSizeDescription { [Display(Name="Very Small")]VerySmall, Small, Medium, Large, [Display(Name="Very Large")]VeryLarge, A6, A7 }
    
    public class AzureCloudServices
    {
        public const double VerySmall = 0.02;
        public const double Small = 0.08;
        public const double Medium = 0.16;
        public const double Large = 0.32;
        public const double VeryLarge = 0.64;
        public const double A6 = 0.90;
        public const double A7 = 1.80;

        [Required(ErrorMessage="Required")]
        [Range(1, Int32.MaxValue, ErrorMessage="Must be greater than 0(zero)")]
        [DisplayName("No. Instances")]
        public int NumInstances { get; set; }

        [Required(ErrorMessage="Required")]
        [DisplayName("Instance Size")]
        public InstanceSizeDescription InstanceSizeDescription { get; set; }

        [DataType(DataType.Currency)]
        public double Cost
        {
            get
            {
                double hourlyRate = 0;
                if (InstanceSizeDescription.VerySmall == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * VerySmall;
                }
                if (InstanceSizeDescription.Small == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * Small;
                }
                if (InstanceSizeDescription.Medium == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * Medium;
                }
                if (InstanceSizeDescription.Large == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * Large;
                }
                if (InstanceSizeDescription.VeryLarge == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * VeryLarge;
                }
                if (InstanceSizeDescription.A6 == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * A6;
                }
                if (InstanceSizeDescription.A7 == this.InstanceSizeDescription)
                {
                    hourlyRate = NumInstances * A7;
                }

                double dailyRate = hourlyRate * 24;
                double yearlyRate;

                if (DateTime.Now.Year % 4 == 0)
                {
                    yearlyRate = dailyRate * 366;
                }
                else
                {
                    yearlyRate = dailyRate * 365;
                }
                return yearlyRate;
            }
        }
    }
}