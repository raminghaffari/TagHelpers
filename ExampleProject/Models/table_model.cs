using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleProject.Models
{
    public class table_model
    {

        public List<human> GetHumen()
        {
            List<human> humen = new List<human>();
            for (int i = 1; i <= 100; i++)
            {
                humen.Add(new human
                {
                    Id = i,
                    Name = $"{i}TestName{i}",
                    Family = $"{i}TestFamily{i}",
                    phonenumber = new Random().Next(09130000, 09139999).ToString()
                }); ;
            }

            return humen;
        }
    }


    public class human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string phonenumber { get; set; }
    }
}
