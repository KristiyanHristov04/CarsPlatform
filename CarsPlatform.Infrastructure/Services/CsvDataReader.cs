using CarsPlatform.Application.Contracts;
using CarsPlatform.Core.Entities;
using CarsPlatform.Application.Models.ServiceModels;
using CsvHelper;
using System.Globalization;
using CarsPlatform.Infrastructure.Data;

namespace CarsPlatform.Infrastructure.Services
{
    public class CsvDataReader : ICsvDataReader
    {
        private readonly CarsPlatformDbContext context;
        public CsvDataReader(CarsPlatformDbContext ctx)
        {
            this.context = ctx;
        }

        public void ReadData()
        {
            if (this.context.Cars.Count() == 0)
            {
                Dictionary<string, int> models = new Dictionary<string, int>();
                Dictionary<string, int> makes = new Dictionary<string, int>();
                Dictionary<string, int> colours = new Dictionary<string, int>();
                Dictionary<string, int> fuelTypes = new Dictionary<string, int>();
                Dictionary<string, int> transmissions = new Dictionary<string, int>();

                using (var reader = new StreamReader("car_data.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<CarServiceModel>();

                        var model = new Model()
                        {
                            ModelName = record.Model
                        };

                        var make = new Make()
                        {
                            MakeName = record.Make
                        };

                        var colour = new Colour()
                        {
                            ColourName = record.Colour
                        };

                        var fuelType = new FuelType()
                        {
                            FuelTypeName = record.Fuel
                        };

                        var transmission = new Transmission()
                        {
                            TransmissionType = record.Transmission
                        };

                        var car = new Car()
                        {
                            ReleaseYear = record.Year,
                            Price = record.Price,
                        };

                        if (!makes.ContainsKey(record.Make))
                        {
                            car.Make = make;
                            context.Makes.Add(make);
                        }
                        else
                        {
                            car.MakeId = makes[record.Make];
                        }

                        if (!models.ContainsKey(record.Model))
                        {
                            car.Model = model;
                            context.Models.Add(model);
                        }
                        else
                        {
                            car.ModelId = models[record.Model];
                        }

                        if (!colours.ContainsKey(record.Colour))
                        {
                            car.Colour = colour;
                            context.Colours.Add(colour);
                        }
                        else
                        {
                            car.ColourId = colours[record.Colour];
                        }

                        if (!fuelTypes.ContainsKey(record.Fuel))
                        {
                            car.FuelType = fuelType;
                            context.FuelTypes.Add(fuelType);
                        }
                        else
                        {
                            car.FuelTypeId = fuelTypes[record.Fuel];
                        }

                        if (!transmissions.ContainsKey(record.Transmission))
                        {
                            car.Transmission = transmission;
                            context.Transmissions.Add(transmission);
                        }
                        else
                        {
                            car.TransmissionId = transmissions[record.Transmission];
                        }

                        context.Cars.Add(car);
                        context.SaveChanges();

                        if (!makes.ContainsKey(record.Make))
                        {
                            makes[record.Make] = make.Id;
                        }

                        if (!models.ContainsKey(record.Model))
                        {
                            models[record.Model] = model.Id;
                        }

                        if (!colours.ContainsKey(record.Colour))
                        {
                            colours[record.Colour] = colour.Id;
                        }

                        if (!fuelTypes.ContainsKey(record.Fuel))
                        {
                            fuelTypes[record.Fuel] = fuelType.Id;
                        }

                        if (!transmissions.ContainsKey(record.Transmission))
                        {
                            transmissions[record.Transmission] = transmission.Id;
                        }
                    }
                }
            }
        }
    }
}
