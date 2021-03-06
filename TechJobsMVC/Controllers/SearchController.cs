﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.searchType = "all";
            return View();

        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;
            List<Job> jobs;

            if (String.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.searchType = "all";
                
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ViewBag.columns[searchType] + ": " + searchTerm;
                ViewBag.searchType = searchType;
            }
            
            ViewBag.searchTerm = searchTerm;
            ViewBag.jobs = jobs;
            ViewBag.count = jobs.Count;


            return View("Index");
        }
    }
}
