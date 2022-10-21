using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using System.Diagnostics;
using System.Xml.Linq;

namespace HTTP5112_Assignment2.Controllers
{
    public class J4GoodGroupsController : ApiController
    {
        /// <summary>
        ///     This APIs returns an integer which represent the number of constraintes violated 
        ///     for class grouping given that there are two sets of rules.
        ///     Rule X is a constraint that 2 students must be in the same group.
        ///     Rule Y is a constraint that 2 students must be in different group.
        ///     There are 3 students in a group
        ///     (2022 J4)
        /// </summary>
        /// <param name="X"> A non-negative integer represent the number of rule X </param>
        /// <param name="sameGroup"> A string with a list of student name in pairs that must be in the same group </param>
        /// <param name="Y"> A non-negative integer represent the number of rule Y </param>
        /// <param name="differentGroup"> A string with a list of student name in pairs that must be in different group </param>
        /// <param name="G"> A positive integer represent the number of groups </param>
        /// <param name="groups"> A string with a list of student name in groups (3 students per group) </param>
        /// <returns> Returns an integer which represent the number of constraintes violated </returns>
        /// <example>
        ///     api/J4/GoodGroups/1/A%20B/1/A%20C/1/A%20C => 2
        ///     api/J4/GoodGroups/0/%20/0/%20/1/A%20C => 0
        ///     api/J4/GoodGroups/1/ELODIE%20CHI/0/%20/2/DWAYNE%20BEN%20ANJALI%20CHI%20FRANCOIS%20ELODIE => 0
        ///     api/J4/GoodGroups/3/A%20B%20G%20L%20J%20K/2/D%20F%20D%20G/4/A%20C%20G%20B%20D%20F%20E%20H%20I%20J%20K%20L=> 3  
        /// </example>


        // GET /api/J4/GoodGroups/X/sameGroup/Y/differentGroup/G/groups
        [Route("api/J4/GoodGroups/{X}/{sameGroup}/{Y}/{differentGroup}/{G}/{groups}")]
        [HttpGet]
        public int Get(int X, string sameGroup, int Y, string differentGroup, int G, string groups)
        {;

            int violations = 0;
            string[,] ruleX = new string[X, 2];
            string[,] ruleY = new string[Y, 2];

            //Converts input into array
            string[] sameGroupArr = (X > 0)? sameGroup.Split(' ') : null;
            string[] differentGroupArr = (Y > 0)? differentGroup.Split(' ') : null;

            //Converts constraint on X into a 2 dimension array ruleX
            for (int i = 0; i < X; i++)
            {
                ruleX[i, 0] = sameGroupArr[2* (i + 1) - 2];
                ruleX[i, 1] = sameGroupArr[2* (i + 1) - 1];

            }

            //Converts constraint on Y into a 2 dimension array ruleY
            for (int i = 0; i < Y; i++)
            {
                ruleY[i, 0] = differentGroupArr[2 * (i + 1) - 2];
                ruleY[i, 1] = differentGroupArr[2 * (i + 1) - 1];

            }

            string[] groupsArr = groups.Split(' ');
            for (int i = 0; i < G; i++)
            {   //Loop Each Group
                string[] group = { groupsArr[ 3 * (i + 1) - 3], groupsArr[3 * (i + 1) - 2], groupsArr[3 * (i + 1) - 1] };

                // Check is rule X violated
                for (int j = 0; j < X; j++)
                    //Loop Each rule X
                {
                    string name1 = ruleX[j,0];
                    string name2 = ruleX[j,1];

                    if (group.Contains(name1) && !group.Contains(name2))
                    {
                        violations++;
                        break;
                    } 
                    else if (!group.Contains(name1) && group.Contains(name2))
                    {
                        violations++;
                        break;
                    }
                }

                // Check is rule Y violated
                for (int j = 0; j < Y; j++)
                //Loop Each rule Y
                {
                    string name1 = ruleY[j, 0];
                    string name2 = ruleY[j, 0];
                    if (group.Contains(name1) && group.Contains(name2))
                    {
                        violations++;
                        break;
                    }
                }

            }

            return violations;
        }
    }
}
