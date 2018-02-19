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
      private string _countryCode;
      private int _population;

      public City(string newName, int newId, int newPopulation, string newCountryCode)
      {
        _name = newName;
        _id = newId;
        _population = newPopulation;
        _countryCode = newCountryCode;

      }

      public string GetCityName()
      {
        return _name;
      }

      public string GetCountryCode()
      {
        return _countryCode;
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
              string countryCode = rdr.GetString(2);
              int cityPopulation = rdr.GetInt32(4);
              City newCity = new City(cityName, cityId, cityPopulation, countryCode);
              allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }
        //
        // public static List<City> PopDescending()
        //   {
        //       List<City> allCities = new List<City> {};
        //       MySqlConnection conn = DB.Connection();
        //       conn.Open();
        //       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //       cmd.CommandText = @"SELECT * FROM city ORDER BY population DESC;";
        //       MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //       while(rdr.Read())
        //       {
        //         int cityId = rdr.GetInt32(0);
        //         string cityName = rdr.GetString(1);
        //         string countryCode = rdr.GetString(2);
        //         int cityPopulation = rdr.GetInt32(4);
        //         City newCity = new City(cityName, cityId, cityPopulation, countryCode);
        //         allCities.Add(newCity);
        //       }
        //       conn.Close();
        //       if (conn != null)
        //       {
        //           conn.Dispose();
        //       }
        //       return allCities;
        //   }

          public static List<City> FilterPop(string beginsWith, string operators, int popNumber, string namePop, string order)
            {
                List<City> allCities = new List<City> {};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT * FROM city WHERE name LIKE " + "'"+ beginsWith +"%"+"'" +" AND population " + operators +" "+ popNumber + " ORDER BY " + namePop + " " + order +";" ;
                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                  int cityId = rdr.GetInt32(0);
                  string cityName = rdr.GetString(1);
                  string countryCode = rdr.GetString(2);
                  int cityPopulation = rdr.GetInt32(4);
                  City newCity = new City(cityName, cityId, cityPopulation, countryCode);
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
