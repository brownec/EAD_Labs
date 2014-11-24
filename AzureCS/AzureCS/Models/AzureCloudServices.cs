using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AzureCS.Models
{
    public enum InstanceSizeDescription
    {
        [Display(Name="Very Small")]
        VerySmall, 
        Small, Medium, Large,
        [Display(Name="Very Large")]
        VeryLarge, 
        A6, A7
    }

    public class AzureCloudServices
    {
        // Directory created outside of static constructor as it will be used in Cost calculation method
        protected static Dictionary<InstanceSizeDescription, Double> dict = new Dictionary<InstanceSizeDescription, Double>();
        protected static int index = 0;
        // Array of doubles to store the price of each instance
        protected static double[] prices = { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };

        static AzureCloudServices()
        {
            foreach (InstanceSizeDescription a in Enum.GetValues(typeof(InstanceSizeDescription)))
            {
                // Directory populated and as it is in static constructor, will run once
                dict.Add(a, prices[index]);
                index++;
            }
        }

        [Required(ErrorMessage="Required")]
        [DisplayName("Instance Size")]
        public InstanceSizeDescription IDS { get; set; }

        [Required(ErrorMessage="Required")]
        [Range(2, Int32.MaxValue, ErrorMessage="Must be greater than zero!")]
        [DisplayName("No.Instances")]
        public int NumInstances { get; set; }

        [DataType(DataType.Currency)]
        public double Cost
        {
            get
            {
                double dailyPrice = 0;
                double d1 = dict[this.IDS];
                dailyPrice = d1 * 24;
         
                double yearlyPrice = 0;
                if (DateTime.Now.Year % 4 == 0)
                {
                    yearlyPrice = dailyPrice * 366;
                }
                else
                {
                    yearlyPrice = dailyPrice * 365;
                }
                yearlyPrice *= NumInstances;
                return yearlyPrice;
            }
        }
    }
}