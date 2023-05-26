using eBet.Core;
using eBet.Data;
using eBet.Data.Entities;
using eBet.Data.Interfaces;
using eBet.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eBet.Domain.Services
{
    public class XmlPullingService /*: BackgroundService*/
    {
        private readonly IUnitOfWork _unitOfWork;

        public XmlPullingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public /*protected override*/ async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try 
                {
                    using (var httpClient = new HttpClient())
                    {
                        Console.WriteLine("XmlPullingService started.");
                        // Make GET request to the XML file URL
                        var xmlResponse = await httpClient.GetStringAsync(GlobalConstants.xmlUrl);
                        var xmlDocument =  XDocument.Parse(xmlResponse);
                        Console.WriteLine("XmlPullingService ended.");
                        // Extract data from the XML document and map to your model or entity class
                        ICollection<Sport> data = ExtractDataFromXml(xmlDocument);

                        // Store the data using Entity Framework Core

                        //_unitOfWork.EnsureCreatedAsync(stoppingToken);
                        // Add the data to the DbSet
                        //_unitOfWork.Sports.AddRangeAsync(data);
                        // Save changes to the database
                        //_unitOfWork.CommitAsync();

                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log errors
                }

                // Wait for 60 seconds before pulling again
                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }

        private ICollection<Sport> ExtractDataFromXml(XDocument xmlDocument)
        {
            ICollection<Sport> data = new List<Sport>();

            // Extract data from the XML and populate the data list
            // Implement your XML-to-object mapping logic here

            return data;
        }
    }
}