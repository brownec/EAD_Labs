using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EADCA2.Models
{
    public enum VehicleCategory { Car, [Display(Name="Public Service Vehicle")] PublicServiceVehicle, Bus, Goods};
    public class M50
    {
        const double CarTollCharge = 2.00;
        const double PSVTollCharge = 2.00;
        const double BusTollCharge = 2.80;
        const double GoodsTollCharge = 4.10;

        public VehicleCategory VehicleCategory { get; set; }

        public Boolean Tag { get; set; }

        public double Toll
        {
            get
            {
                double toll = 0;
                if (VehicleCategory.Car == this.VehicleCategory)
                {
                    if (Tag == true)
                    {
                        toll = CarTollCharge * 0.8;
                    }
                    else
                    {
                        toll = CarTollCharge;
                    }
                }
                if (VehicleCategory.PublicServiceVehicle == this.VehicleCategory)
                {
                    if (Tag == true)
                    {
                        toll = PSVTollCharge * 0.8;
                    }
                    else
                    {
                        toll = PSVTollCharge;
                    }
                }
                if (VehicleCategory.Bus == this.VehicleCategory)
                {
                    if (Tag == true)
                    {
                        toll = BusTollCharge * 0.8;
                    }
                    else
                    {
                        toll = BusTollCharge;
                    }
                }
                if (VehicleCategory.Goods == this.VehicleCategory)
                {
                    if (Tag == true)
                    {
                        toll = GoodsTollCharge * 0.8;
                    }
                    else
                    {
                        toll = GoodsTollCharge;
                    }
                }
                return Toll;
            }
        }
    }
}