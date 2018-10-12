using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.DataAccessLayer;
using Demo_FileIO_NTier.BusinessLogicLayer;
using Demo_FileIO_NTier.PresentationLayer;
using Demo_FileIO_NTier.Models;

namespace Demo_FileIO_NTier
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDataService dataService = new CsvDataService();
            //IDataService dataService = new XmlDataService();
            //IDataService dataService = new JsonDataService();
            IDataService dataService = new MongoDBDataService();

            //
            // Required to test the MongoDB data service
            // refresh MongoDB collection 
            //
            dataService.WriteAll(GenerateListOfCharacters());

            CharacterBLL characterBLL = new CharacterBLL(dataService);
            Presenter presenter = new Presenter(characterBLL);
        }

        private static List<Character> GenerateListOfCharacters()
        {
            List<Character> characters = new List<Character>()
            {
                new Character()
                {
                    Id = 1,
                    LastName = "Flintstone",
                    FirstName = "Fred",
                    Address = "301 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 28,
                    Gender = Character.GenderType.MALE
                },
                new Character()
                {
                    Id = 2,
                    LastName = "Rubble",
                    FirstName = "Barney",
                    Address = "303 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 28,
                    Gender = Character.GenderType.FEMALE
                },
                new Character()
                {
                    Id = 3,
                    LastName = "Flintstone",
                    FirstName = "Wilma",
                    Address = "301 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 27,
                    Gender = Character.GenderType.FEMALE
                },
                new Character()
                {
                    Id = 4,
                    LastName = "Flintstone",
                    FirstName = "Pebbles",
                    Address = "301 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 1,
                    Gender = Character.GenderType.FEMALE
                },
                new Character()
                {
                    Id = 5,
                    LastName = "Rubble",
                    FirstName = "Betty",
                    Address = "303 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 26,
                    Gender = Character.GenderType.FEMALE
                },
                new Character()
                {
                    Id = 6,
                    LastName = "Rubble",
                    FirstName = "Bamm-Bamm",
                    Address = "303 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 2,
                    Gender = Character.GenderType.MALE
                },
                                new Character()
                {
                    Id = 7,
                    LastName = "",
                    FirstName = "Dino",
                    Address = "301 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 7,
                    Gender = Character.GenderType.FEMALE
                }
            };

            return characters;
        }
    }
}
