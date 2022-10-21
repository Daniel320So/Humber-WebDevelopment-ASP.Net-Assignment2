using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5112_Assignment2.Controllers
{
    public class J1MenuController : ApiController
    {

        /// <summary>
        ///     This APIs returns the total calories of the selected meals at Chip's Fast Food emporium.
        ///     (2006 J1)
        /// </summary>
        /// <param name="burger"> Integer value between 1-4 which represent the choice of burger </param>
        /// <param name="drink"> Integer value between 1-4 which represent the choice of drink </param>
        /// <param name="side"> Integer value between 1-4 which represent the choice of side </param>
        /// <param name="dessert"> Integer value between 1-4 which represent the choice of dessert </param>
        /// <returns> Returns the total calories of the above choices </returns>
        /// <example>
        ///     api/J1/Menu/4/4/4/4 => 0
        ///     api/J1/Menu/1/2/3/4 => 691
        /// </example>


        // GET /api/J1/Menu/{burger}/{drink}/{side}/{dessert}
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public int Get(int burger, int drink, int side, int dessert)
        {
            int[] burgers = new int[4] { 461, 431, 420, 0};
            int[] drinks = new int[4] { 130, 160, 118, 0 };
            int[] sides = new int[4] { 100, 57, 70, 0 };
            int[] desserts = new int[4] { 167, 266, 75, 0 };
            return burgers[burger-1] + drinks[drink-1] + sides[side-1] + desserts[dessert-1];
        }
    }
}
