using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor;
using MegaDeskRazor.Data;
//using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public CreateModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
            ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "DeliveryName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "MaterialName");

            return Page();
        }


        [BindProperty]
        public Desk Desk { get; set; }
        
        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            // add desk
            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            // set Quote Date
            DeskQuote.QuoteDate = DateTime.Now;

            // set deskid           
            DeskQuote.DeskId = Desk.DeskId;

            // set desk
            DeskQuote.Desk = Desk;

            // set quote Price 
            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

            DeskQuote.DeliveryId = DeskQuote.Delivery.DeliveryId;
            DeskQuote.Delivery = null;
           // DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
