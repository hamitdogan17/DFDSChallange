using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DFDS.Challange.Customer.Data.EF
{
    public class CustomerContextSeed
    {
        public static void Seed(CustomerDbContext customerDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                customerDbContext.Database.Migrate();

                if (!customerDbContext.tb_Status.Any())
                {
                    customerDbContext.tb_Status.AddRange(GetPreconfiguredStatuses());
                    customerDbContext.SaveChanges();
                }
                if (!customerDbContext.tb_Nationality.Any())
                {
                    customerDbContext.tb_Nationality.AddRange(GetPreconfiguredNationalities());
                    customerDbContext.SaveChanges();
                }
                if (!customerDbContext.tb_Customer.Any())
                {
                    customerDbContext.tb_Customer.AddRange(GetPreconfiguredCustomer());
                    customerDbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CustomerContextSeed>();
                    log.LogError(ex.Message);
                    Seed(customerDbContext, loggerFactory, retryForAvailability);
                }

                throw;
            }
        }

        private static IEnumerable<tb_Status> GetPreconfiguredStatuses()
        {
            return new List<tb_Status>
            {
                new tb_Status()
                {
                    Status = "Taken for processing"
                },
                new tb_Status()
                {
                    Status = "Qualified"
                },
                new tb_Status()
                {
                    Status = "Out of scope"
                }
            };
        }

        private static IEnumerable<tb_Nationality> GetPreconfiguredNationalities()
        {
            return new List<tb_Nationality>
            {
                new tb_Nationality() { Country = "Turkey", Code = "TR" },
                new tb_Nationality() { Country = "Germany", Code = "DE" },
                new tb_Nationality() { Country = "Greece", Code = "GR" },
                new tb_Nationality() { Country = "Italy", Code = "IT" },
                new tb_Nationality() { Country = "Netherkands", Code = "NL" },
                new tb_Nationality() { Country = "Russia", Code = "RU" }
            };
        }

        private static IEnumerable<tb_Customer> GetPreconfiguredCustomer()
        {
            return new List<tb_Customer>
            {
                new tb_Customer()
                {
                    Name = "Hamit",
                    Surname = "Dogan",
                    Mail = "hamitdogan17@gmail.com",
                    Address = "Sultangazi",
                    Age = 29,
                    NationalityRef = 1,
                    StatusRef = 2
                },
                new tb_Customer()
                {
                    Name = "Serdar",
                    Surname = "Aslan",
                    Mail = "serdaraslan@gmail.com",
                    Address = "Bayrampasa",
                    Age = 34,
                    NationalityRef = 1,
                    StatusRef = 1
                }, 
                new tb_Customer()
                {
                    Name = "Giorgio",
                    Surname = "Chiellini",
                    Mail = "chiellini@gmail.com",
                    Address = "Italy",
                    Age = 39,
                    NationalityRef = 4,
                    StatusRef = 2
                },
                new tb_Customer()
                {
                    Name = "Manuel",
                    Surname = "Neuer",
                    Mail = "neuer@gmail.com",
                    Address = "Italy",
                    Age = 27,
                    NationalityRef = 2,
                    StatusRef = 3
                },
            };
        }
    }
}
