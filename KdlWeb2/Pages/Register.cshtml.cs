using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KdlWeb.Pages
{
    public class RegisterModel : PageModel
    {
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public Dictionary<string, string> Errors { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost(string FullName, string Phone, string Analysis)
        {
            if (string.IsNullOrWhiteSpace(FullName))
                Errors["FullName"] = "Введите ФИО";

            if (string.IsNullOrWhiteSpace(Phone))
                Errors["Phone"] = "Введите телефон";

            if (string.IsNullOrWhiteSpace(Analysis))
                Errors["Analysis"] = "Выберите анализ";

            if (Errors.Count > 0)
            {
                this.FullName = FullName;
                this.Phone = Phone;
                return Page();
            }

            TempData["Success"] = $"Пациент {FullName} успешно записан на анализ: {Analysis}";
            return RedirectToPage("/Index");
        }
    }
}
