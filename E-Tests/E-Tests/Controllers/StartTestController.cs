using E_Tests.Data;
using E_Tests.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Tests.Controllers
{
    [Authorize]
    public class StartTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartTestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index(  Guid? ID)
        {
            var applicationDbContext = await _context.Tests.Where(z => z.id == ID).Include(z => z.Questions).Include("Questions.question").FirstOrDefaultAsync();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> Start(Guid ID)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = await _context.Tests.Where(z => z.id == ID).Include(z => z.Questions).Include("Questions.question").FirstOrDefaultAsync(); 
                TestsDTO test = new TestsDTO();
                test.test = applicationDbContext;
                foreach (var it in applicationDbContext.Questions)
                {
                    test.questions.Add(it.question);
                }
               
           
            return View(test);
        }
        //[HttpPost]
        public async Task<IActionResult> Finis(string odgovori, string prasanje, Guid test)
        {
            string [] prLista = prasanje.Split(",");
            string[] odLista = odgovori.Split(",");
            var applicationDbContext = await _context.Tests.Where(z => z.id==test ).Include(z => z.Questions).Include("Questions.question").FirstOrDefaultAsync();
            int caunt = 0;
            for(var i=0;i<prLista.Length-1;i++)
            {
                foreach(var item in applicationDbContext.Questions)
                {
                    if(item.question.id.ToString()==prLista[i])
                    {
                        
                        
                            if(item.question.correctAnswer.Equals(odLista[i]))
                            {
                                caunt++;
                            }
                        

                    }
                }
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Results rez = new Results();
            rez.id = new Guid();
            rez.points = caunt;
            rez.test = applicationDbContext;
            rez.testid = test;
            rez.userId = userId;
            rez.testName = applicationDbContext.name;
            rez.procent =(int)( ((float)caunt / (float)applicationDbContext.Questions.Count) * 100);
            _context.Add(rez);
            await _context.SaveChangesAsync();


            return View(rez);
        }
    }
}
