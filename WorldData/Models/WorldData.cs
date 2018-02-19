using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;


namespace WorldData.Models
{
    public class City
    {
      private int _id;
      private string _name;
      // private string _countryCode;
      // private string _district;
      private int _population;

      public City(string newName, int newId, int newPopulation)
      {
        _name = newName;
        _id = newId;
        _population = newPopulation;

      }

      public string GetCityName()
      {
        return _name;
      }
      public int GetCityPopulation()
      {
        return _population;
      }

      public static List<City> GetAll()
        {
            List<City> allCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string cityName = rdr.GetString(1);
              int cityPopulation = rdr.GetInt32(4);
              City newCity = new City(cityName, cityId, cityPopulation);
              allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }
    }

}
