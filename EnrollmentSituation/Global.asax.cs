using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EnrollmentSituation.Data;
using EnrollmentSituation.Models;


namespace EnrollmentSituation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SeedPrograms();
        }

        private void SeedPrograms()
        {
            try
            {
                using (var context = new EnrollmentDbContext())
                {
                    if (!context.Programs.Any())
                    {
                        context.Programs.Add(new Program { ProgName = "BS Computer Science" });
                        context.Programs.Add(new Program { ProgName = "BS Information Technology" });
                        context.Programs.Add(new Program { ProgName = "BS Business Administration" });

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or throw to see details
                System.Diagnostics.Debug.WriteLine("SeedPrograms error: " + ex.Message);
                throw;
            }
        }


    }
}
