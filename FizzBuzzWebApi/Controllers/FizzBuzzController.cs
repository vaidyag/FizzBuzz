using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FizzBuzzWebApi.Models;

namespace FizzBuzzWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        [HttpPost]
        public List<FizzBuzz> Process([FromBody] string userInput)        
        {            
            string[] arrayUserInput = string.IsNullOrWhiteSpace(userInput)? new string[] { } : userInput.Split(',');
            
            List<FizzBuzz> fizzBuzzes = new List<FizzBuzz>();
            
            foreach (var val in arrayUserInput)
            {
                FizzBuzz fizzBuzz = new FizzBuzz();
                fizzBuzz.Input = val;

                if (int.TryParse(val, out int num))
                {
                    if (num % 3 == 0 && num % 5 == 0)
                    {
                        fizzBuzz.ProcessedInput = Constants.MultipleOfThreeAndFive;
                    }
                    else if (num % 3 == 0)
                    {
                        fizzBuzz.ProcessedInput = Constants.MultipleOfThree;
                    }
                    else if (num % 5 == 0)
                    {
                        fizzBuzz.ProcessedInput = Constants.MultipleOfFive;
                    }
                    else
                    {
                        fizzBuzz.ProcessedInput = $"Divided {num} by 3, Divided {num} by 5";
                    }
                }
                else
                {
                    fizzBuzz.ProcessedInput = Constants.InvalidItem;
                }

                fizzBuzzes.Add(fizzBuzz);
            }

            return fizzBuzzes;
        }
    }
}
