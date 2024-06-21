﻿using Microsoft.AspNetCore.Mvc;
using CRM.WebApp.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CRM.WebApp.Site.Controllers
{
    public class LeadController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LeadController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRM.API");
            var response = await client.GetAsync("api/lead");
            response.EnsureSuccessStatusCode();

            var leads = await response.Content.ReadFromJsonAsync<IEnumerable<LeadViewModel>>();
            return View(leads);
        }

        // GET: Leads/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var client = _httpClientFactory.CreateClient("CRM.API");
            var response = await client.GetAsync($"api/lead/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var lead = await response.Content.ReadFromJsonAsync<LeadViewModel>();
            return View(lead);
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeadViewModel leadViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("CRM.API");
                var response = await client.PostAsJsonAsync("api/lead", leadViewModel);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View(leadViewModel);
        }

        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient("CRM.API");
            var response = await client.GetAsync($"api/lead/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var lead = await response.Content.ReadFromJsonAsync<LeadViewModel>();
            return View(lead);
        }

        // POST: Leads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LeadViewModel leadViewModel)
        {
            if (id != leadViewModel.LeadID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("CRM.API");
                var response = await client.PutAsJsonAsync($"api/lead/{id}", leadViewModel);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(leadViewModel);
        }

        // GET: Leads/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient("CRM.API");
            var response = await client.GetAsync($"api/lead/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var lead = await response.Content.ReadFromJsonAsync<LeadViewModel>();
            return View(lead);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = _httpClientFactory.CreateClient("CRM.API");
            var response = await client.DeleteAsync($"api/lead/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}