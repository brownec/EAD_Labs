using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EADCAEx1.Models
{
    public class AzureCloudServices
    {
        public static String[] InstanceSizeDescription
        {
            get
            {
                return new String[] { "Very Small", "Small", "Medium", "Large", "Very Large", "A6", "A7" };
            }
        }
        public static double[] InstancePriceDescription
        {
            get
            {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };
            }
        }

        // Add validation
        [Required(ErrorMessage="Required")]
        [Range(1, Int32.MaxValue, ErrorMessage="Must be greater than 0(zero)")]
        [DisplayName("Required Field")]
        public int NumInstances { get; set; }

        [Required(ErrorMessage="Required")]
        [DisplayName("Required Field")]
        public String InstanceSize { get; set; }

        // Calculation
        [DataType(DataType.Currency)]
        public double Cost
        {
            get
            {
                int size = 0;
                for (int i = 0; i < AzureCloudServices.InstanceSizeDescription.Length; i++)
                {
                    if (AzureCloudServices.InstanceSizeDescription[i] == this.InstanceSize)
                    {
                        size = i;
                        break;
                    }
                }
                double hourlyRate = NumInstances * InstancePriceDescription[size];
                double dailyRate = hourlyRate * 24;
                double yearlyRate;

                // Calculation to determine cost if it a Leap year
                if (DateTime.Now.Year %4 == 0)
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