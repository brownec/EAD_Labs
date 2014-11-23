using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EADEx1Enums.Models
{
    public enum InstanceSizeDescription { Very_Small, Small, Medium, Large, Very_Large, A6, A7 }
    
    public class AzureCloudServices
    {
        public static double[] InstancePriceDescription
        {
            get
            {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };
            }
        }

        [Required(ErrorMessage="Required")]
        [Range(1, Int32.MaxValue, ErrorMessage="Must be greater than 0(zero)")]
        [DisplayName("Required Field")]
        public int NumInstances { get; set; }

        [Required(ErrorMessage="Required")]
        [DisplayName("Required Field")]
        public String InstanceSize  { get; set; }

        public double Cost
        {
            get
            {
                int size = 0;
                for (int i = 0; i < AzureCloudServices.InstancePriceDescription.Length; i++)
                {
                    if (AzureCloudServices.InstancePriceDescription[i] == this.NumInstances)
                    {
                        size = i;
                        break;
                    }
                }
                double hourlyRate = NumInstances * InstancePriceDescription[size];
                double dailyRate = hourlyRate * 24;
                double yearlyRate;

                if (DateTime.Now.Year % 4 == 0)
                {
                    // if a Leap Year
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