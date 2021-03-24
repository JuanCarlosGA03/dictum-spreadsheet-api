using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sheetspread.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpreadController : ControllerBase
    {
        public class SpreadSheet
        {
            public double[] values { get; set; }
            public double rate { get; set; }

        }

        [HttpPost("vna")]
        public IActionResult SpreadVna(SpreadSheet spread)
        {
            try
            {
                return Ok(NPV(spread.values, spread.rate));

            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }

        double NPV(double[] C, double r)
        {
            double sum = 0.0;
            int N = C.Length - 1;

            for (int n = 0; n <= N; n++)
            {
                int elevator = n + 1;
                sum += C[n] / Math.Pow(1 + r, elevator);
            }

            return sum;
        }

    }
}
