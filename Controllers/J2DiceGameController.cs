using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5112_Assignment2.Controllers
{
    public class J2DiceGameController : ApiController
    {

        /// <summary>
        ///     This APIs returns the string "There are X ways to get the sum 10." where x is the number of ways that two dices with M sides and N sides respectively can roll the valut of 10.
        ///     (2006 J2)
        /// </summary>
        /// <param name="m"> Positive integer representing the number of sides on the first dice. </param>
        /// <param name="n"> Positive integer representing the number of sides on the second dice. </param>
        /// <returns> Returns the string "There are X ways to get the sum 10." where X is the number of ways that can roll the value of 10. </returns>
        /// <example>
        ///     api/J2/DiceGame/6/8 => There are 5 ways to get the sum 10.
        ///     api/J2/DiceGame/12/4 => There are 4 ways to get the sum 10.
        ///     api/J2/DiceGame/3/3 => There are 0 ways to get the sum 10.
        ///     api/J2/DiceGame/5/5 => There is 1 ways to get the sum 10.
        /// </example>


        // GET /api/J2/DiceGame/{m}/{n}
        [Route("api/J2/DiceGame/{m}/{n}")]
        [HttpGet]
        public string Get(int m, int n)
        {
            int result = 0;
            for (int i = 1; i < m + 1; i++)
            {
                int diff = 10 - i;
                if ( n >= diff && diff > 0)
                {
                    result++;
                }
            }
            if (result == 1)
            {
                return "There is " + result.ToString() + " way to get the sum 10.";
            } else
            {
                return "There are " + result.ToString() + " ways to get the sum 10.";
            }
        }
    }
}
