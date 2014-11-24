using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnumCA1.Models
{
    public enum InstanceSizeDescription { [Display(Name = "Very Small")]VerySmall, Small, Medium, Large, [Display(Name = "Very Large")] VeryLarge, A6, A7 };
    public class AzureServices
    {
        public double[] InstancePrice = {0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80};

        [Required(ErrorMessage="Required")]
        [DisplayName("Instance Size")]
        public InstanceSizeDescription ISD { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Range(2, Int32.MaxValue, ErrorMessage="Must be greater than zero!")]
        [DisplayName("No.Instances")]
        public int NumInstances { get; set; }

        [DataType(DataType.Currency)]
        public double Cost
        {
            get
            {
                int index = 0;
                double DailyRate = 0;
                // Create a DICTIONARY MAP containing the instance Size & Number of Instances
                Dictionary<InstanceSizeDescription, Double> dict = new Dictionary<InstanceSizeDescription, double>();

                /* Iterate through the ENUM collection,add each entry to the dictionary map as a key
                 and then add the NumInstances as the value price[index]*/
                foreach (InstanceSizeDescription a in Enum.GetValues(typeof(InstanceSizeDescription)))
                {
                    dict.Add(a, InstancePrice[index]);
                    index++;
                }

                /* Iterate over the Dictionary(dict) - in a foreach called kvp */
                foreach (KeyValuePair<InstanceSizeDescription, Double> kvp in dict)
                {
                    if (kvp.Key == this.ISD)
                    {
                        DailyRate = (kvp.Value * 24);
                    }
                }

                double yearlyRate = 0;
                if (DateTime.Now.Year % 4 == 0)
                {
                    yearlyRate = DailyRate * 366;
                }
                else
                {
                    yearlyRate = DailyRate * 365;
                }
                return yearlyRate;
            }
        }
    }
}