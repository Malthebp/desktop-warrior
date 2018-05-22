using DesktopWarrior.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DesktopWarrior.Infrastructure.Attributes
{
    public class ZipValidAttribute : ValidationAttribute, IClientValidatable
    {

        public ZipValidAttribute()
        {
            ErrorMessage = "Zip not found - try with 8000, 8260, 8270, 8700 or 7500";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mvr = new ModelClientValidationRule();
            mvr.ErrorMessage = "Zip not found - try with 8000, 8260, 8270, 8700 or 7500";
            mvr.ValidationType = "zipvalidattribute"; //used as key
            return new[] { mvr };
        }

        public override bool IsValid(object value)
        {
            string val = Convert.ToString(value);
            int zip = Int32.Parse(val);

            if (zip == 0)
                return false;

            if (ZipCodeExist(zip))
                return true;

            return false;
        }

        private bool ZipCodeExist(int zip)
        {
            var zips = new int[]
            {
                8000,
                8260,
                8270,
                8700,
                7500
            };


            return (zips.Where(x => x == zip).Count() != 0) ? true : false;

        }
    }
}