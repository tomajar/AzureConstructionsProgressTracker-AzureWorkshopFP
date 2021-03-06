﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzureConstructionsProgressTracker.Models;

namespace AzureConstructionsProgressTracker.Features.ProgressTracking
{
    public class ProgressTrackingController : Controller
    {
        private ConstructionsProgressTrackerContext db = new ConstructionsProgressTrackerContext();

        // GET: ProgressTracking
        public async Task<ActionResult> Index()
        {
            var progressTrackingEntries = db.ProgressTrackingEntries.Include(p => p.ConstructionProject);
            return View(await progressTrackingEntries.ToListAsync());
        }

        // GET: ProgressTracking/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgressTrackingEntry progressTrackingEntry = await db.ProgressTrackingEntries.FindAsync(id);
            if (progressTrackingEntry == null)
            {
                return HttpNotFound();
            }
            return View(progressTrackingEntry);
        }

        // GET: ProgressTracking/Create
        public ActionResult Create()
        {
            ViewBag.ConstructionProjectId = new SelectList(db.ConstructionProjects, "Id", "Name");
            return View();
        }

        // POST: ProgressTracking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Notes,PictureReference,ConstructionProjectId")] ProgressTrackingEntry progressTrackingEntry)
        {
            if (ModelState.IsValid)
            {
                progressTrackingEntry.EntryDate = DateTime.Now;
                db.ProgressTrackingEntries.Add(progressTrackingEntry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConstructionProjectId = new SelectList(db.ConstructionProjects, "Id", "Name", progressTrackingEntry.ConstructionProjectId);
            return View(progressTrackingEntry);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
