using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OnlineMovieTicketBookingProject.Data;
using OnlineMovieTicketBookingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G4BuildingCodingExcise.WebApi.Db
{
    //public class AppDbContextDbInit
    //{
    //    public static void Seed(IApplicationBuilder applicationBuilder)
    //    {
    //        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
    //        {
    //            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    //            context?.Database.EnsureCreated();
    //            if (context != null && !context.MovieDetails.Any())
    //            {
    //                context.MovieDetails.AddRange(new List<MovieDetails>
    //                {
    //                    new MovieDetails
    //                    {
    //                         Movie_Name="Avatar",
    //                         DateAndTime=DateTime.Now.AddDays(10),
    //                         Movie_Description = "The Way of Water begins to tell the story of the Sully family (Jake, Neytiri and their kids)"
    //                    }
    //                }) ;
    //                context.SaveChanges();
    //            }
    //        }
    //    }
    //}
}
