using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    internal class Data_handler
    {
        // save, load
        public Data_handler() 
        {
            load_plant_data();
        }
        public void save_plant_data(Plant plant)
        {
            using (StreamWriter writer = new StreamWriter("plant_data.txt"))
            {
                writer.WriteLine(plant.Humidity + ";" + plant.Fertilizer + ";" + plant.Current_growth_stage);
            }
        }
        private Plant load_plant_data()
        {
            if (File.Exists("plant_data.txt"))
            {
                using (StreamReader reader = new StreamReader("plant_data.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string data = reader.ReadLine();
                        if (data != null)
                        {
                            string[] split_data = data.Split(';');
                            int humidity = int.Parse(split_data[0]);
                            int fertilizer = int.Parse(split_data[1]);
                            int growth_stage = int.Parse(split_data[2]);
                            Plant loaded_plant = new Plant(humidity, fertilizer, growth_stage);
                            return loaded_plant;
                        }
                        else
                        {
                            return new Plant(0, 0, 0); // if no data file exists, return a new plant with default values
                        }
                    }
                }
                return new Plant(0, 0, 0); // if no data file exists, return a new plant with default values
            }
            else
            {
                return new Plant(0, 0, 0); // if no data file exists, return a new plant with default values
            }

        }
    }
}
