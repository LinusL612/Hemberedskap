using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Pages
{
    public class HemberedskapModel : PageModel
    {
        [BindProperty]
        public Wimps Formular { get; set; } = new();

        [TempData]
        public string? Meddelande { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var sak = new List<string>();
            if (Formular.vatten) sak.Add("Vatten");
            if (Formular.mat) sak.Add("Mat");
            if (Formular.ficklampa) sak.Add("Ficklampa");
            if (Formular.batteri_radio) sak.Add("Batteridriven radio");

            var harHemma = sak.Count > 0
                ? string.Join(", ", sak)
                : "ingenting av det efterfrågade";

            var tips = string.IsNullOrWhiteSpace(Formular.tips)
                ? "inget tips lämnades"
                : Formular.tips;

            Meddelande = $"Tack, {Formular.Name}! Du har hemma: {harHemma}. " +
                         $"E-post: {Formular.email}. Tips: {tips}";

            return RedirectToPage();
        }
    }
}